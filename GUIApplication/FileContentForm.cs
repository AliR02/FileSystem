using System;
using System.IO;
using System.Windows.Forms;

namespace GUIApplication
{
    public partial class FileContentForm : Form
    {
        private string filePath;

        public string Content
        {
            get { return ContentBox.Text; }
            set { ContentBox.Text = value; }
        }

        public FileContentForm(string filePath, string content, bool isPDF=false)
        {
            InitializeComponent();
            this.filePath = filePath;
            Text = Path.GetFileName(filePath);
            Content = content;

            if (isPDF)// Pdf should not have a save button 
            {
                ContentBox.ReadOnly = true;
                SaveButton.Enabled = false;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)//save content written 
        {
            if (!string.IsNullOrEmpty(filePath))//check that the file exist
            {
               
                File.WriteAllText(filePath, Content); // Save the content to the file
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("File path is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
