namespace LoSW_Corpus
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFolderToolStripMenuItem = new ToolStripMenuItem();
            openFilesToolStripMenuItem = new ToolStripMenuItem();
            findLengthToolStripMenuItem = new ToolStripMenuItem();
            sentencesByToolStripMenuItem = new ToolStripMenuItem();
            sentencesBySymbolsToolStripMenuItem = new ToolStripMenuItem();
            sentencesByLettersToolStripMenuItem = new ToolStripMenuItem();
            sentencesByWordsToolStripMenuItem = new ToolStripMenuItem();
            wordsByToolStripMenuItem = new ToolStripMenuItem();
            wordsBySymbolsToolStripMenuItem = new ToolStripMenuItem();
            wordsByLettersToolStripMenuItem = new ToolStripMenuItem();
            m_fileGrid = new DataGridView();
            m_fileGridTextName = new DataGridViewTextBoxColumn();
            m_fileGridTextFileSize = new DataGridViewTextBoxColumn();
            m_fileGridLanguage = new DataGridViewTextBoxColumn();
            m_fileGridCount = new DataGridViewTextBoxColumn();
            m_fileGridAverage = new DataGridViewTextBoxColumn();
            m_toolComboBox = new ComboBox();
            toolLabel = new Label();
            mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_fileGrid).BeginInit();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, findLengthToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(897, 24);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFolderToolStripMenuItem, openFilesToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // openFolderToolStripMenuItem
            // 
            openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            openFolderToolStripMenuItem.Size = new Size(161, 22);
            openFolderToolStripMenuItem.Text = "Відкрити папку";
            // 
            // openFilesToolStripMenuItem
            // 
            openFilesToolStripMenuItem.Name = "openFilesToolStripMenuItem";
            openFilesToolStripMenuItem.Size = new Size(161, 22);
            openFilesToolStripMenuItem.Text = "Відкрити файли";
            openFilesToolStripMenuItem.Click += OpenFilesToolStripMenuItem_Click;
            // 
            // findLengthToolStripMenuItem
            // 
            findLengthToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sentencesByToolStripMenuItem, wordsByToolStripMenuItem });
            findLengthToolStripMenuItem.Name = "findLengthToolStripMenuItem";
            findLengthToolStripMenuItem.Size = new Size(118, 20);
            findLengthToolStripMenuItem.Text = "Знайти довжину...";
            // 
            // sentencesByToolStripMenuItem
            // 
            sentencesByToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sentencesBySymbolsToolStripMenuItem, sentencesByLettersToolStripMenuItem, sentencesByWordsToolStripMenuItem });
            sentencesByToolStripMenuItem.Name = "sentencesByToolStripMenuItem";
            sentencesByToolStripMenuItem.Size = new Size(136, 22);
            sentencesByToolStripMenuItem.Text = "Речень за...";
            // 
            // sentencesBySymbolsToolStripMenuItem
            // 
            sentencesBySymbolsToolStripMenuItem.Name = "sentencesBySymbolsToolStripMenuItem";
            sentencesBySymbolsToolStripMenuItem.Size = new Size(140, 22);
            sentencesBySymbolsToolStripMenuItem.Text = "Символами";
            // 
            // sentencesByLettersToolStripMenuItem
            // 
            sentencesByLettersToolStripMenuItem.Name = "sentencesByLettersToolStripMenuItem";
            sentencesByLettersToolStripMenuItem.Size = new Size(140, 22);
            sentencesByLettersToolStripMenuItem.Text = "Буквами";
            // 
            // sentencesByWordsToolStripMenuItem
            // 
            sentencesByWordsToolStripMenuItem.Name = "sentencesByWordsToolStripMenuItem";
            sentencesByWordsToolStripMenuItem.Size = new Size(140, 22);
            sentencesByWordsToolStripMenuItem.Text = "Словами";
            sentencesByWordsToolStripMenuItem.Click += SentencesByWordsToolStripMenuItem_Click;
            // 
            // wordsByToolStripMenuItem
            // 
            wordsByToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { wordsBySymbolsToolStripMenuItem, wordsByLettersToolStripMenuItem });
            wordsByToolStripMenuItem.Name = "wordsByToolStripMenuItem";
            wordsByToolStripMenuItem.Size = new Size(136, 22);
            wordsByToolStripMenuItem.Text = "Слів за...";
            // 
            // wordsBySymbolsToolStripMenuItem
            // 
            wordsBySymbolsToolStripMenuItem.Name = "wordsBySymbolsToolStripMenuItem";
            wordsBySymbolsToolStripMenuItem.Size = new Size(140, 22);
            wordsBySymbolsToolStripMenuItem.Text = "Символами";
            // 
            // wordsByLettersToolStripMenuItem
            // 
            wordsByLettersToolStripMenuItem.Name = "wordsByLettersToolStripMenuItem";
            wordsByLettersToolStripMenuItem.Size = new Size(140, 22);
            wordsByLettersToolStripMenuItem.Text = "Буквами";
            // 
            // m_fileGrid
            // 
            m_fileGrid.AllowUserToAddRows = false;
            m_fileGrid.AllowUserToDeleteRows = false;
            m_fileGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_fileGrid.Columns.AddRange(new DataGridViewColumn[] { m_fileGridTextName, m_fileGridTextFileSize, m_fileGridLanguage, m_fileGridCount, m_fileGridAverage });
            m_fileGrid.Location = new Point(12, 130);
            m_fileGrid.Name = "m_fileGrid";
            m_fileGrid.Size = new Size(874, 239);
            m_fileGrid.TabIndex = 1;
            // 
            // m_fileGridTextName
            // 
            m_fileGridTextName.HeaderText = "Назва тексту";
            m_fileGridTextName.Name = "m_fileGridTextName";
            m_fileGridTextName.Width = 300;
            // 
            // m_fileGridTextFileSize
            // 
            m_fileGridTextFileSize.HeaderText = "Розмір тексту (в байтах)";
            m_fileGridTextFileSize.Name = "m_fileGridTextFileSize";
            m_fileGridTextFileSize.Width = 180;
            // 
            // m_fileGridLanguage
            // 
            m_fileGridLanguage.HeaderText = "Мова";
            m_fileGridLanguage.Name = "m_fileGridLanguage";
            m_fileGridLanguage.Width = 150;
            // 
            // m_fileGridCount
            // 
            m_fileGridCount.HeaderText = "Кількість в тексті";
            m_fileGridCount.Name = "m_fileGridCount";
            m_fileGridCount.ReadOnly = true;
            // 
            // m_fileGridAverage
            // 
            m_fileGridAverage.HeaderText = "Середня довжина";
            m_fileGridAverage.Name = "m_fileGridAverage";
            m_fileGridAverage.ReadOnly = true;
            // 
            // m_toolComboBox
            // 
            m_toolComboBox.FormattingEnabled = true;
            m_toolComboBox.Location = new Point(178, 53);
            m_toolComboBox.Name = "m_toolComboBox";
            m_toolComboBox.Size = new Size(121, 23);
            m_toolComboBox.TabIndex = 2;
            m_toolComboBox.SelectedIndexChanged += AlgoComboBox_SelectedIndexChanged;
            // 
            // toolLabel
            // 
            toolLabel.AutoSize = true;
            toolLabel.Location = new Point(12, 56);
            toolLabel.Name = "toolLabel";
            toolLabel.Size = new Size(160, 15);
            toolLabel.TabIndex = 3;
            toolLabel.Text = "Інструкмент розділу речень";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 389);
            Controls.Add(toolLabel);
            Controls.Add(m_toolComboBox);
            Controls.Add(m_fileGrid);
            Controls.Add(mainMenuStrip);
            MainMenuStrip = mainMenuStrip;
            Name = "MainForm";
            Text = "LoSW Corpus";
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)m_fileGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFolderToolStripMenuItem;
        private ToolStripMenuItem openFilesToolStripMenuItem;
        private DataGridView m_fileGrid;
        private ToolStripMenuItem findLengthToolStripMenuItem;
        private ToolStripMenuItem sentencesByToolStripMenuItem;
        private ToolStripMenuItem sentencesBySymbolsToolStripMenuItem;
        private ToolStripMenuItem sentencesByLettersToolStripMenuItem;
        private ToolStripMenuItem sentencesByWordsToolStripMenuItem;
        private ToolStripMenuItem wordsByToolStripMenuItem;
        private ToolStripMenuItem wordsBySymbolsToolStripMenuItem;
        private ToolStripMenuItem wordsByLettersToolStripMenuItem;
        private DataGridViewTextBoxColumn m_fileGridTextName;
        private DataGridViewTextBoxColumn m_fileGridTextFileSize;
        private DataGridViewTextBoxColumn m_fileGridLanguage;
        private DataGridViewTextBoxColumn m_fileGridCount;
        private DataGridViewTextBoxColumn m_fileGridAverage;
        private ComboBox m_toolComboBox;
        private Label toolLabel;
    }
}
