using Python.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LoSW_Corpus
{
    public partial class MainForm : Form
    {

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
        }

        ~MainForm()
        {
            PythonEngine.Shutdown();
        }

        private enum SentenceBoundaryDetectionTool
        {
            SpacySentencizer
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
                            
                            foreach (dynamic sent in sents)
                            {
                                MessageBox.Show((string)sent.text);
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
    }
}
