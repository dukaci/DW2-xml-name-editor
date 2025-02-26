using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Linq;

namespace DW2_xml_name_editor
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void SelectXmlFile()
      {
         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "Select an XML file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               selectedXmlFilePath = openFileDialog.FileName;
               LogMessage($"File selected: {selectedXmlFilePath}");

               try
               {
                  XmlDocument xmlDoc = new XmlDocument();
                  xmlDoc.Load(selectedXmlFilePath);
                  XmlNode root = xmlDoc.DocumentElement;

                  if (root != null)
                  {
                     string defaultIdElementName = FindIdElementName(root, 3);
                     if (!string.IsNullOrEmpty(defaultIdElementName))
                     {
                        textBoxArrayObjectIdElementName.Text = defaultIdElementName;
                     }
                  }

                  // Automatically scan the file after selection
                  ScanFile();
               }
               catch (Exception ex)
               {
                  LogMessage($"Error loading XML file: {ex.Message}");
               }
            }
         }
      }

      private string FindIdElementName(XmlNode node, int depth)
      {
         if (depth == 0 || node == null)
         {
            return null;
         }

         foreach (XmlNode childNode in node.ChildNodes)
         {
            if (childNode.Name.Contains("Id", StringComparison.OrdinalIgnoreCase))
            {
               return childNode.Name;
            }

            string result = FindIdElementName(childNode, depth - 1);
            if (!string.IsNullOrEmpty(result))
            {
               return result;
            }
         }

         return null;
      }

      private void HandleDragEnter(DragEventArgs e)
      {
         if (e.Data.GetDataPresent(DataFormats.FileDrop))
         {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && Path.GetExtension(files[0]).ToLower() == ".xml")
            {
               e.Effect = DragDropEffects.Copy;
            }
            else
            {
               e.Effect = DragDropEffects.None;
            }
         }
      }

      private void HandleDragDrop(DragEventArgs e)
      {
         if (e.Data.GetDataPresent(DataFormats.FileDrop))
         {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && Path.GetExtension(files[0]).ToLower() == ".xml")
            {
               selectedXmlFilePath = files[0];
               // Handle the selected file path as needed
               LogMessage($"File selected: {selectedXmlFilePath}");
               // PopulateListBoxWithXmlElements(selectedXmlFilePath); // Commented out for now
            }
         }
      }

      private void ScanFile()
      {
         string idElementName = textBoxArrayObjectIdElementName.Text;
         string nameElementName = textBoxArrayObjectNameElementName.Text;

         if (string.IsNullOrEmpty(idElementName) || string.IsNullOrEmpty(nameElementName))
         {
            LogMessage("Please enter both element names.");
            return;
         }

         if (string.IsNullOrEmpty(selectedXmlFilePath))
         {
            LogMessage("No XML file selected.");
            return;
         }

         PopulateListBoxWithXmlElements(selectedXmlFilePath, idElementName, nameElementName);

         // Check if no items are produced and log a message
         if (listBoxXmlElements.Items.Count == 0)
         {
            LogMessage("No items produced. Please ensure the correct names are entered in the text fields.");
         }
      }

      private void PopulateListBoxWithXmlElements(string filePath, string idElementName, string nameElementName)
      {
         try
         {
            LogMessage("Attempting to load XML file.");
            listBoxXmlElements.Items.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            LogMessage("XML file loaded successfully.");

            XmlNode root = xmlDoc.DocumentElement;
            if (root == null)
            {
               LogMessage("Invalid XML structure: Root element not found.");
               return;
            }

            foreach (XmlNode childNode in root.ChildNodes)
            {
               XmlNode idNode = childNode.SelectSingleNode(idElementName);
               XmlNode nameNode = childNode.SelectSingleNode(nameElementName);

               if (idNode != null && nameNode != null)
               {
                  string listItem = $"{idNode.InnerText};{nameNode.InnerText}";
                  listBoxXmlElements.Items.Add(listItem);
                  LogMessage($"Element added to ListBox: {listItem}");
               }
            }
            LogMessage("All elements processed successfully.");
         }
         catch (Exception ex)
         {
            LogMessage($"Error processing XML file: {ex.Message}");
         }
      }

      // ...existing code...
      private void ExportDictionary()
      {
         using (SaveFileDialog saveFileDialog = new SaveFileDialog())
         {
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Save Dictionary";

            if (!string.IsNullOrEmpty(selectedXmlFilePath))
            {
               string originalFileName = Path.GetFileNameWithoutExtension(selectedXmlFilePath);
               saveFileDialog.FileName = $"dict_{originalFileName}.txt";
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               string filePath = saveFileDialog.FileName;
               try
               {
                  using (StreamWriter writer = new StreamWriter(filePath))
                  {
                     foreach (DataGridViewRow row in dataGridViewDictionary.Rows)
                     {
                        if (row.Cells["dataGridViewTextBoxColumn1"].Value != null && row.Cells["dataGridViewTextBoxColumn2"].Value != null)
                        {
                           string line = $"{row.Cells["dataGridViewTextBoxColumn1"].Value};{row.Cells["dataGridViewTextBoxColumn2"].Value}";
                           writer.WriteLine(line);
                        }
                     }
                  }
                  LogMessage($"Dictionary exported to: {filePath}");
               }
               catch (Exception ex)
               {
                  LogMessage($"Error exporting dictionary: {ex.Message}");
               }
            }
         }
      }

      private void UploadDictionary()
      {
         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Upload Dictionary";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               string filePath = openFileDialog.FileName;
               try
               {
                  dataGridViewDictionary.Rows.Clear();
                  using (StreamReader reader = new StreamReader(filePath))
                  {
                     string line;
                     while ((line = reader.ReadLine()) != null)
                     {
                        var parts = line.Split(';');
                        if (parts.Length == 2)
                        {
                           dataGridViewDictionary.Rows.Add(parts[0], parts[1]);
                        }
                     }
                  }
                  LogMessage($"Dictionary uploaded from: {filePath}");
               }
               catch (Exception ex)
               {
                  LogMessage($"Error uploading dictionary: {ex.Message}");
               }
            }
         }
      }

      // ...existing code...
      private void FilterDictionary()
      {
         try
         {
            string searchText = textBoxSearch.Text;
            bool isNumber = int.TryParse(searchText, out int searchId);

            var rows = dataGridViewDictionary.Rows.Cast<DataGridViewRow>().ToList();
            List<DataGridViewRow> exactMatches;
            List<DataGridViewRow> partialMatches;

            if (isNumber)
            {
               // If the search text is a number, match against IDs
               exactMatches = rows.Where(row => row.Cells[0].Value.ToString() == searchId.ToString()).ToList();
               partialMatches = rows.Except(exactMatches).ToList();
            }
            else
            {
               // If the search text is not a number, find the closest matching strings
               exactMatches = rows.Where(row => row.Cells[1].Value.ToString().Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
               partialMatches = rows.Except(exactMatches)
                                   .OrderBy(row => LevenshteinDistance(row.Cells[1].Value.ToString(), searchText))
                                   .ToList();
            }

            dataGridViewDictionary.Rows.Clear();
            foreach (var row in exactMatches.Concat(partialMatches))
            {
               dataGridViewDictionary.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);
            }
         }
         catch (Exception ex)
         {
            LogMessage($"Error filtering dictionary: {ex.Message}");
         }
      }

      // ...existing code...

      private int LevenshteinDistance(string source, string target)
      {
         if (string.IsNullOrEmpty(source)) return target.Length;
         if (string.IsNullOrEmpty(target)) return source.Length;

         int[,] distance = new int[source.Length + 1, target.Length + 1];

         for (int i = 0; i <= source.Length; distance[i, 0] = i++) { }
         for (int j = 0; j <= target.Length; distance[0, j] = j++) { }

         for (int i = 1; i <= source.Length; i++)
         {
            for (int j = 1; j <= target.Length; j++)
            {
               int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;
               distance[i, j] = Math.Min(
                   Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                   distance[i - 1, j - 1] + cost);
            }
         }

         return distance[source.Length, target.Length];
      }

      private void OnTextBoxSearchTextChanged(object sender, EventArgs e)
      {
         FilterDictionary();
      }

      private void Dictionarize()
      {
         dataGridViewDictionary.Rows.Clear();
         foreach (var item in listBoxXmlElements.Items)
         {
            var parts = item.ToString().Split(';');
            if (parts.Length == 2)
            {
               dataGridViewDictionary.Rows.Add(parts[0], parts[1]);
            }
         }
      }

      private void MergeDictionaryWithXml()
      {
         try
         {
            if (string.IsNullOrEmpty(selectedXmlFilePath))
            {
               LogMessage("No XML file selected.");
               return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(selectedXmlFilePath);
            XmlNode root = xmlDoc.DocumentElement;
            if (root == null)
            {
               LogMessage("Invalid XML structure: Root element not found.");
               return;
            }

            var dictionary = new Dictionary<string, string>();
            foreach (DataGridViewRow row in dataGridViewDictionary.Rows)
            {
               if (row.Cells["dataGridViewTextBoxColumn1"].Value != null && row.Cells["dataGridViewTextBoxColumn2"].Value != null)
               {
                  dictionary[row.Cells["dataGridViewTextBoxColumn1"].Value.ToString()] = row.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
               }
            }

            foreach (XmlNode childNode in root.ChildNodes)
            {
               XmlNode idNode = childNode.SelectSingleNode(textBoxArrayObjectIdElementName.Text);
               XmlNode nameNode = childNode.SelectSingleNode(textBoxArrayObjectNameElementName.Text);

               if (idNode != null && nameNode != null && dictionary.ContainsKey(idNode.InnerText))
               {
                  nameNode.InnerText = dictionary[idNode.InnerText];
               }
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
               saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
               saveFileDialog.Title = "Save Merged XML File";

               string directory = Path.GetDirectoryName(selectedXmlFilePath);
               string filenameWithoutExtension = Path.GetFileNameWithoutExtension(selectedXmlFilePath);
               string extension = Path.GetExtension(selectedXmlFilePath);
               saveFileDialog.FileName = $"{filenameWithoutExtension}_Mod{extension}";

               if (saveFileDialog.ShowDialog() == DialogResult.OK)
               {
                  string newFilePath = saveFileDialog.FileName;
                  xmlDoc.Save(newFilePath);
                  LogMessage($"Merged XML file saved to: {newFilePath}");
               }
            }
         }
         catch (Exception ex)
         {
            LogMessage($"Error merging dictionary with XML: {ex.Message}");
         }
      }

      private void ExtractDictionary()
      {
         using (SaveFileDialog saveFileDialog = new SaveFileDialog())
         {
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Save Dictionary";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               string filePath = saveFileDialog.FileName;
               try
               {
                  using (StreamWriter writer = new StreamWriter(filePath))
                  {
                     foreach (var item in listBoxXmlElements.Items)
                     {
                        writer.WriteLine(item.ToString());
                     }
                  }
                  LogMessage($"Dictionary exported to: {filePath}");
               }
               catch (Exception ex)
               {
                  LogMessage($"Error exporting dictionary: {ex.Message}");
               }
            }
         }
      }

      private void LogMessage(string message)
      {
         textBoxLogger.AppendText($"{DateTime.Now}: {message}{Environment.NewLine}");
      }

      private void dataGridViewDictionary_CellContentClick(object sender, DataGridViewCellEventArgs e)
      {

      }

      private void dataGridViewDictionary_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
      {

      }

   }
}
