namespace DW2_xml_name_editor
{
   partial class Form1
   {
      private System.ComponentModel.IContainer components = null;
      private System.Windows.Forms.Button buttonSelectXmlFile;
      private System.Windows.Forms.TextBox textBoxLogger; // Add a TextBox for logging
      private System.Windows.Forms.Label labelLogger; // Add a Label for the logger
      private System.Windows.Forms.ListBox listBoxXmlElements; // Add a ListBox for XML elements
      private System.Windows.Forms.TextBox textBoxArrayObjectIdElementName; // Add a TextBox for Array object ID element name
      private System.Windows.Forms.TextBox textBoxArrayObjectNameElementName; // Add a TextBox for Array object Name element name
      private System.Windows.Forms.Button buttonScanFile; // Add a Button for scanning the file
      private System.Windows.Forms.Button buttonExtractDictionary; // Rename buttonExportDictionary to buttonExtractDictionary
      private System.Windows.Forms.Button buttonUploadDictionary; // Add a Button for uploading the dictionary
      private System.Windows.Forms.Button buttonDictionarize; // Add a Button for dictionarizing
      private System.Windows.Forms.Button buttonMerge; // Add a Button for merging
      private System.Windows.Forms.DataGridView dataGridViewDictionary; // Change to DataGridView for displaying and editing the dictionary
      private string selectedXmlFilePath;
      private System.Windows.Forms.TextBox textBoxSearch; // Add a TextBox for searching
      private System.Windows.Forms.Button buttonExportDictionary; // Add a Button for exporting the dictionary

      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }
      private void InitializeComponent()
      {
         buttonSelectXmlFile = new Button();
         textBoxLogger = new TextBox();
         labelLogger = new Label();
         listBoxXmlElements = new ListBox();
         textBoxArrayObjectIdElementName = new TextBox();
         textBoxArrayObjectNameElementName = new TextBox();
         buttonScanFile = new Button();
         buttonExtractDictionary = new Button();
         buttonUploadDictionary = new Button();
         buttonDictionarize = new Button();
         buttonMerge = new Button();
         dataGridViewDictionary = new DataGridView();
         dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
         dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
         textBoxSearch = new TextBox();
         buttonExportDictionary = new Button();
         ((System.ComponentModel.ISupportInitialize)dataGridViewDictionary).BeginInit();
         SuspendLayout();
         // 
         // buttonSelectXmlFile
         // 
         buttonSelectXmlFile.AllowDrop = true;
         buttonSelectXmlFile.Location = new Point(12, 177);
         buttonSelectXmlFile.Name = "buttonSelectXmlFile";
         buttonSelectXmlFile.Size = new Size(200, 23);
         buttonSelectXmlFile.TabIndex = 0;
         buttonSelectXmlFile.Text = "Select .xml file";
         buttonSelectXmlFile.UseVisualStyleBackColor = true;
         buttonSelectXmlFile.Click += OnButtonSelectXmlFileClick;
         buttonSelectXmlFile.DragDrop += OnButtonSelectXmlFileDragDrop;
         buttonSelectXmlFile.DragEnter += OnButtonSelectXmlFileDragEnter;
         // 
         // textBoxLogger
         // 
         textBoxLogger.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         textBoxLogger.Location = new Point(12, 32);
         textBoxLogger.Multiline = true;
         textBoxLogger.Name = "textBoxLogger";
         textBoxLogger.ReadOnly = true;
         textBoxLogger.Size = new Size(1033, 139);
         textBoxLogger.TabIndex = 1;
         // 
         // labelLogger
         // 
         labelLogger.BackColor = SystemColors.Control;
         labelLogger.ForeColor = SystemColors.ActiveCaptionText;
         labelLogger.Location = new Point(12, 9);
         labelLogger.Name = "labelLogger";
         labelLogger.Size = new Size(100, 20);
         labelLogger.TabIndex = 14;
         labelLogger.Text = "Logger";
         // 
         // listBoxXmlElements
         // 
         listBoxXmlElements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
         listBoxXmlElements.ItemHeight = 15;
         listBoxXmlElements.Location = new Point(12, 288);
         listBoxXmlElements.Name = "listBoxXmlElements";
         listBoxXmlElements.Size = new Size(388, 649);
         listBoxXmlElements.TabIndex = 2;
         // 
         // textBoxArrayObjectIdElementName
         // 
         textBoxArrayObjectIdElementName.Location = new Point(12, 235);
         textBoxArrayObjectIdElementName.Name = "textBoxArrayObjectIdElementName";
         textBoxArrayObjectIdElementName.PlaceholderText = "Array object ID element name";
         textBoxArrayObjectIdElementName.Size = new Size(200, 23);
         textBoxArrayObjectIdElementName.TabIndex = 3;
         // 
         // textBoxArrayObjectNameElementName
         // 
         textBoxArrayObjectNameElementName.Location = new Point(12, 264);
         textBoxArrayObjectNameElementName.Name = "textBoxArrayObjectNameElementName";
         textBoxArrayObjectNameElementName.PlaceholderText = "Array object Name element name";
         textBoxArrayObjectNameElementName.Size = new Size(200, 23);
         textBoxArrayObjectNameElementName.TabIndex = 4;
         textBoxArrayObjectNameElementName.Text = "Name";
         // 
         // buttonScanFile
         // 
         buttonScanFile.Location = new Point(12, 206);
         buttonScanFile.Name = "buttonScanFile";
         buttonScanFile.Size = new Size(200, 23);
         buttonScanFile.TabIndex = 5;
         buttonScanFile.Text = "Scan File";
         buttonScanFile.UseVisualStyleBackColor = true;
         buttonScanFile.Click += OnButtonScanFileClick;
         // 
         // buttonExtractDictionary
         // 
         buttonExtractDictionary.Location = new Point(218, 176);
         buttonExtractDictionary.Name = "buttonExtractDictionary";
         buttonExtractDictionary.Size = new Size(182, 23);
         buttonExtractDictionary.TabIndex = 6;
         buttonExtractDictionary.Text = "Extract Dictionary";
         buttonExtractDictionary.UseVisualStyleBackColor = true;
         buttonExtractDictionary.Click += OnButtonExtractDictionaryClick;
         // 
         // buttonUploadDictionary
         // 
         buttonUploadDictionary.Location = new Point(218, 205);
         buttonUploadDictionary.Name = "buttonUploadDictionary";
         buttonUploadDictionary.Size = new Size(182, 23);
         buttonUploadDictionary.TabIndex = 7;
         buttonUploadDictionary.Text = "Upload Dictionary";
         buttonUploadDictionary.UseVisualStyleBackColor = true;
         buttonUploadDictionary.Click += OnButtonUploadDictionaryClick;
         // 
         // buttonDictionarize
         // 
         buttonDictionarize.Location = new Point(218, 263);
         buttonDictionarize.Name = "buttonDictionarize";
         buttonDictionarize.Size = new Size(182, 23);
         buttonDictionarize.TabIndex = 11;
         buttonDictionarize.Text = "Dictionarize";
         buttonDictionarize.UseVisualStyleBackColor = true;
         buttonDictionarize.Click += OnButtonDictionarizeClick;
         // 
         // buttonMerge
         // 
         buttonMerge.Location = new Point(861, 176);
         buttonMerge.Name = "buttonMerge";
         buttonMerge.Size = new Size(184, 34);
         buttonMerge.TabIndex = 12;
         buttonMerge.Text = "Merge";
         buttonMerge.UseVisualStyleBackColor = true;
         buttonMerge.Click += OnButtonMergeClick;
         // 
         // dataGridViewDictionary
         // 
         dataGridViewDictionary.AllowUserToAddRows = false;
         dataGridViewDictionary.AllowUserToDeleteRows = false;
         dataGridViewDictionary.AllowUserToResizeColumns = false;
         dataGridViewDictionary.AllowUserToResizeRows = false;
         dataGridViewDictionary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         dataGridViewDictionary.CausesValidation = false;
         dataGridViewDictionary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dataGridViewDictionary.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
         dataGridViewDictionary.EditMode = DataGridViewEditMode.EditOnEnter; // Set EditMode to EditOnEnter
         dataGridViewDictionary.Location = new Point(406, 215);
         dataGridViewDictionary.MultiSelect = false;
         dataGridViewDictionary.Name = "dataGridViewDictionary";
         dataGridViewDictionary.SelectionMode = DataGridViewSelectionMode.CellSelect;
         dataGridViewDictionary.Size = new Size(639, 722);
         dataGridViewDictionary.TabIndex = 9;
         dataGridViewDictionary.CellContentClick += dataGridViewDictionary_CellContentClick_1;
         dataGridViewDictionary.SelectionChanged += dataGridViewDictionary_SelectionChanged; // Add SelectionChanged event handler
         dataGridViewDictionary.CellEndEdit += dataGridViewDictionary_CellEndEdit; // Add CellEndEdit event handler
         // 
         // dataGridViewTextBoxColumn1
         // 
         dataGridViewTextBoxColumn1.HeaderText = "ID";
         dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
         dataGridViewTextBoxColumn1.ReadOnly = true; // Set ReadOnly to true
         dataGridViewTextBoxColumn1.Width = 50;
         // 
         // dataGridViewTextBoxColumn2
         // 
         dataGridViewTextBoxColumn2.HeaderText = "Name";
         dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
         dataGridViewTextBoxColumn2.Width = 500;
         // 
         // textBoxSearch
         // 
         textBoxSearch.Location = new Point(406, 183);
         textBoxSearch.Name = "textBoxSearch";
         textBoxSearch.PlaceholderText = "Search";
         textBoxSearch.Size = new Size(449, 23);
         textBoxSearch.TabIndex = 9;
         textBoxSearch.TextChanged += OnTextBoxSearchTextChanged;
         // 
         // buttonExportDictionary
         // 
         buttonExportDictionary.Location = new Point(218, 234);
         buttonExportDictionary.Name = "buttonExportDictionary";
         buttonExportDictionary.Size = new Size(182, 23);
         buttonExportDictionary.TabIndex = 13;
         buttonExportDictionary.Text = "Export Dictionary";
         buttonExportDictionary.UseVisualStyleBackColor = true;
         buttonExportDictionary.Click += OnButtonExportDictionaryClick;
         // 
         // Form1
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(1057, 944);
         Controls.Add(labelLogger);
         Controls.Add(buttonMerge);
         Controls.Add(buttonDictionarize);
         Controls.Add(buttonUploadDictionary);
         Controls.Add(buttonExtractDictionary);
         Controls.Add(buttonScanFile);
         Controls.Add(textBoxArrayObjectNameElementName);
         Controls.Add(textBoxArrayObjectIdElementName);
         Controls.Add(listBoxXmlElements);
         Controls.Add(textBoxLogger);
         Controls.Add(buttonSelectXmlFile);
         Controls.Add(dataGridViewDictionary);
         Controls.Add(textBoxSearch);
         Controls.Add(buttonExportDictionary);
         Name = "Form1";
         Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)dataGridViewDictionary).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      private void OnButtonSelectXmlFileClick(object sender, EventArgs e)
      {
         SelectXmlFile();
      }

      private void OnButtonSelectXmlFileDragEnter(object sender, DragEventArgs e)
      {
         HandleDragEnter(e);
      }

      private void OnButtonSelectXmlFileDragDrop(object sender, DragEventArgs e)
      {
         HandleDragDrop(e);
      }

      private void OnButtonScanFileClick(object sender, EventArgs e)
      {
         ScanFile();
      }

      private void OnButtonExtractDictionaryClick(object sender, EventArgs e)
      {
         ExtractDictionary();
      }

      private void OnButtonUploadDictionaryClick(object sender, EventArgs e)
      {
         UploadDictionary();
      }

      private void OnTextBoxSearchByIdTextChanged(object sender, EventArgs e)
      {
         FilterDictionary();
      }

      private void OnTextBoxSearchByStringTextChanged(object sender, EventArgs e)
      {
         FilterDictionary();
      }

      private void OnButtonDictionarizeClick(object sender, EventArgs e)
      {
         Dictionarize();
      }

      private void OnButtonMergeClick(object sender, EventArgs e)
      {
         MergeDictionaryWithXml();
      }

      private void OnButtonExportDictionaryClick(object sender, EventArgs e)
      {
         ExportDictionary();
      }
      private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
      private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

      private void dataGridViewDictionary_SelectionChanged(object sender, EventArgs e)
      {
         foreach (DataGridViewCell cell in dataGridViewDictionary.SelectedCells)
         {
            if (cell.ColumnIndex == dataGridViewTextBoxColumn1.Index)
            {
               cell.Selected = false;
            }
         }
      }

      private void dataGridViewDictionary_CellEndEdit(object sender, DataGridViewCellEventArgs e)
      {
         if (e.ColumnIndex == dataGridViewTextBoxColumn2.Index)
         {
            var cell = dataGridViewDictionary.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value != null)
            {
               cell.Value = cell.Value.ToString().Trim();
            }
         }
      }
   }
}