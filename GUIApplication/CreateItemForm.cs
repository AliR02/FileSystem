using System;
using System.Windows.Forms;

namespace GUIApplication
{
    public partial class CreateItemForm : Form
    {
        public string ItemName { get; private set; }//name of the file 
        public string SelectedExtension { get; private set; }//extension of file 

        public CreateItemForm()
        {
            InitializeComponent();

        }
  
        private void CancelButton_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)//create file with given name with given extension 
        {
            
            ItemName = ItemNameBox.Text.Trim();
            SelectedExtension = ExtensionComboBox.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
