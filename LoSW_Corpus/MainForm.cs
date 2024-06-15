using Python.Runtime;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LoSW_Corpus
{
    public partial class MainForm : Form
    {

        private enum SentenceBoundaryDetectionTool
        {
            SpacySentencizer,
            PySBD
        }

        private enum SentenceMethod
        {
            ByWords,
            BySymbols,
            ByLetters,
        }

        public MainForm()
        {
            InitializeComponent();

            // TODO: Figure out the python dll at runtime.
            Runtime.PythonDLL = "python311.dll";
            PythonEngine.Initialize();

            // TODO: Try uninstalling packages.
            dynamic os = Py.Import("os");
            dynamic sys = Py.Import("sys");
            sys.path.append(os.getcwd() + "/scripts");

            m_languageDetectModule = Py.Import("LanguageDetect");
            m_sbdModule = Py.Import("SentenceBoundaryDetection");

            m_toolComboBox.Items.Add(SentenceBoundaryDetectionTool.SpacySentencizer);
            m_toolComboBox.Items.Add(SentenceBoundaryDetectionTool.PySBD);
            m_toolComboBox.SelectedItem = m_sbdTool;
        }

        ~MainForm()
        {
            PythonEngine.Shutdown();
        }

        private dynamic m_sbdModule;
        private dynamic m_languageDetectModule;

        private SentenceBoundaryDetectionTool m_sbdTool = SentenceBoundaryDetectionTool.SpacySentencizer;

        private string DetectLanguage(string filePath)
        {
            return m_languageDetectModule.detect_language(filePath);
        }

        private void PreprocessFile(string filePath)
        {
            int currentRow = m_fileGrid.Rows.Add();

            m_fileGrid[m_fileGridTextName.Index, currentRow].Value = new FilePathGridEntry(filePath);
            m_fileGrid[m_fileGridTextFileSize.Index, currentRow].Value = new FileInfo(filePath).Length;
            m_fileGrid[m_fileGridLanguage.Index, currentRow].Value = this.DetectLanguage(filePath);
        }

        private void ProcessSentences(SBDResult result, int rowIndex, string language, SentenceMethod method)
        {
            switch (method)
            {
                case SentenceMethod.ByWords:

                    int sentenceCount = 0;
                    Dictionary<int, int> sentenceSizeFrequency = new Dictionary<int, int>();

                    foreach (PyObject sentence in result)
                    {
                        dynamic doc = m_sbdModule.get_doc_text(sentence, language);

                        int size = 0;
                        foreach (dynamic token in doc)
                        {
                            if (token.is_punct)
                            {
                                continue;
                            }

                            size += 1;
                        }

                        if (!sentenceSizeFrequency.ContainsKey(size))
                        {
                            sentenceSizeFrequency[size] = 0;
                        }

                        sentenceSizeFrequency[size] += 1;

                        sentenceCount += 1;
                    }

                    // Calculate the average sentence length
                    double totalLength = 0;
                    double totalCount = 0;

                    foreach (var kvp in sentenceSizeFrequency)
                    {
                        totalLength += kvp.Key * kvp.Value;
                        totalCount += kvp.Value;
                    }

                    double averageLength = totalLength / totalCount;

                    //// Calculate the variance
                    //double varianceSum = 0;

                    //foreach (var kvp in sentenceSizeFrequency)
                    //{
                    //    varianceSum += kvp.Value * Math.Pow(kvp.Key - averageLength, 2);
                    //}

                    //double variance = varianceSum / totalCount;

                    //// Calculate the standard deviation
                    //double standardDeviation = Math.Sqrt(variance);

                    //// Calculate the standard error
                    //double standardError = standardDeviation / Math.Sqrt(totalCount);

                    m_fileGrid[m_fileGridCount.Index, rowIndex].Value = sentenceCount;
                    m_fileGrid[m_fileGridAverage.Index, rowIndex].Value = averageLength;

                    break;
            }


            MessageBox.Show("Test");
        }

        private void SentencesByWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Py.GIL())
            {
                foreach (DataGridViewRow row in m_fileGrid.Rows)
                {

                    FilePathGridEntry fileEntry = (FilePathGridEntry)m_fileGrid[m_fileGridTextName.Index, row.Index].Value;
                    string language = (string)m_fileGrid[m_fileGridLanguage.Index, row.Index].Value;

                    switch (m_sbdTool)
                    {
                        case SentenceBoundaryDetectionTool.SpacySentencizer:
                            dynamic sents = m_sbdModule.spacy_sentencizer(fileEntry.FilePath, language, this.GetPunctList(language));

                            this.ProcessSentences(new SBDSpacySentencizerResult(sents), row.Index, language, SentenceMethod.ByWords);
                            break;
                        case SentenceBoundaryDetectionTool.PySBD:

                            try
                            {
                                dynamic sentences = m_sbdModule.pysbd_segmenter(fileEntry.FilePath, language);
                                this.ProcessSentences(new SBDResult(sentences), row.Index, language, SentenceMethod.ByWords);
                            }
                            catch {
                                MessageBox.Show("Помилка", "PySBD не підтримує мову: " + language, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            break;
                    }
                }
            }
        }

        private PyList GetPunctList(string language)
        {
            PyList Convert(string[] punct)
            {
                var list = new PyList();

                foreach (string c in punct)
                    list.Append(new PyString(c));

                return list;
            }

            switch (language)
            {
                case "en":
                default:
                    return Convert([".", "!", "?", "\n"]);
            }
        }

        private void OpenFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_fileGrid.Rows.Clear();

            string[] selectedFiles;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                selectedFiles = openFileDialog.FileNames;
            }

            if (selectedFiles == null)
            {
                return;
            }

            using (Py.GIL())
            {

                foreach (var file in selectedFiles)
                {
                    this.PreprocessFile(file);
                }
            }
        }

        /**
         * The data we get from Python code can be different depending on the used library.
         * Passing around a dynamic variable can lead to a lot of unpredicteable code.
         * SBDResult wraps around the result we get and make it easy to read the data.
         */
        private class SBDResult : IEnumerable<PyObject>
        {
            protected dynamic m_result;

            public SBDResult(dynamic result)
            {
                m_result = result;
            }

            public virtual IEnumerator<PyObject> GetEnumerator()
            {
                foreach (dynamic result in m_result)
                {
                    yield return (PyObject)result;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        private class SBDSpacySentencizerResult : SBDResult
        {
            public SBDSpacySentencizerResult(dynamic result) : base(result) { }

            public override IEnumerator<PyObject> GetEnumerator()
            {
                foreach (dynamic result in m_result)
                {
                    yield return (PyObject)result.text;
                }
            }
        }

        /**
         * Used to store the full file path, but only show the name on the grid.
         */
        private class FilePathGridEntry
        {
            private string m_filePath;

            public string FilePath => m_filePath;

            public FilePathGridEntry(string filePath)
            {
                m_filePath = filePath;
            }

            public override string ToString()
            {
                return Path.GetFileName(m_filePath);
            }
        }

        private void AlgoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_sbdTool = (SentenceBoundaryDetectionTool)m_toolComboBox.SelectedItem;
        }
    }
}
