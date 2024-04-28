using GUIApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIApplication
{
    public partial class FileManager : Form
    {
        private FileSystem fileSystem;
        private string rootDirectory;
        private string lastSelectedDirectory = "";
        private int leftClickCount = 0;
        private Timer leftClickTimer = new Timer();

        public string RootDirectory
        {
            get { return rootDirectory; }
            set { rootDirectory = value; }
        }

        public FileManager(string username)
        {
            InitializeComponent();
            
            
            rootDirectory = Path.Combine(@"C:\Directory", username); //root directory unique to user

            if (!Directory.Exists(rootDirectory))
            {
                Directory.CreateDirectory(rootDirectory);
            }


            
            string[] requiredDirectories = { "Desktop","Documents", "Downloads" };//default directories should always exist
           
            for (int i = 0; i < requiredDirectories.Length; i++)
            {
                string directoryName = requiredDirectories[i];
                string directoryPath = Path.Combine(rootDirectory, directoryName);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
  
                    
                }

            }

            fileSystem = new FileSystem(rootDirectory);
            
            leftClickTimer.Interval = SystemInformation.DoubleClickTime;//check for double clicking (left)
    
        }

        private void FileManager_Load(object sender, EventArgs e)//load directories and files at loading time
        {
           
            PopulateDirectoryTreeView(rootDirectory, DirectoryTreeView.Nodes);
        }
        private void PopulateDirectoryTreeView(string directoryPath, TreeNodeCollection parentNode)
        {
            try
            {
               
                parentNode.Clear();

                PopulateNode(directoryPath, parentNode);// Populate the tree view with directories and files
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to populate directory tree view: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DirectoryTreeView_MouseClick(object sender, MouseEventArgs e)//check for right and left click in direcotry view 
        {
            if (e.Button == MouseButtons.Right)//right click show menu strip 
            {
                
                TreeNode selectedNode = DirectoryTreeView.GetNodeAt(e.Location);
                if (selectedNode != null)
                {
                    DirectoryTreeView.SelectedNode = selectedNode; 
                    contextMenuStripDirectory.Show(DirectoryTreeView, e.Location);
                }
            }
            else if (e.Button == MouseButtons.Left) //left click show files in directory selected
            {
                
                TreeNode selectedNode = DirectoryTreeView.GetNodeAt(e.Location);
                if (selectedNode != null)
                {
                    string selectedDirectory = Path.Combine(rootDirectory, selectedNode.FullPath);
                    ShowFilesInDirectory(selectedDirectory);
                }
            }
        }
       
        private bool FileExistsInDirectories(string fileName)// Check for file with same name and extension
        {
            
            foreach (string directoryPath in Directory.GetDirectories(rootDirectory))
            {
                string filePath = Path.Combine(directoryPath,fileName);
                if (File.Exists(filePath)==true)
                {
                    return true;
                }
            }
            return false;
        }

        private void PopulateNode(string directoryPath, TreeNodeCollection parentNode)
        {
            
            parentNode.Clear();

            
            foreach (string directory in Directory.GetDirectories(directoryPath))// Add directories to the tree view with fiven image
            {

                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                TreeNode directoryNode = new TreeNode(dirInfo.Name);
                if (directoryNode.Text== "Documents")
                {
                    
                    directoryNode.ImageIndex = 2;
                    directoryNode.SelectedImageIndex = 2;
                   
                }
                else if (directoryNode.Text == "Downloads")
                {
                    directoryNode.ImageIndex = 3;
                    directoryNode.SelectedImageIndex = 3;
                }
                else if(directoryNode.Text== "Desktop")
                {
                    directoryNode.ImageIndex = 4;
                    directoryNode.SelectedImageIndex = 4;   
                }

                parentNode.Add(directoryNode);

                PopulateNode(directory, directoryNode.Nodes);

                foreach (string file in Directory.GetFiles(directory))
                {
                    FileInfo fileInfo = new FileInfo(file);
                   
                }
            }
        }

        private void FilelistView_MouseClick(object sender, MouseEventArgs e)//check for right clik in file list view
        {
            if (e.Button == MouseButtons.Right)//if right click show menu strip
            {
                ListViewItem clickedItem = FilelistView.GetItemAt(e.Location.X, e.Location.Y);
                if (clickedItem != null)
                {
                    clickedItem.Selected = true;
                    contextMenuStripFile.Show(FilelistView, e.Location);
                }
            }
        }
  

        private void NewDirectoryButton_Click(object sender, EventArgs e)//create new directory 
        {
            
            using (var createItemForm = new CreateItemForm())
            {
                if (createItemForm.ShowDialog() == DialogResult.OK)
                {
                    string newDirectoryName = createItemForm.ItemName;//get name from user

                    
                    if (!string.IsNullOrEmpty(newDirectoryName))//check the name is not null
                    {
                        TreeNode selectedNode = DirectoryTreeView.SelectedNode;//keep track of selected node to create directory within 

                        if (selectedNode != null)//check if there is a selected node 
                        {
                            string parentPath = Path.Combine(rootDirectory, selectedNode.FullPath);//get parent path 
                            string newDirectoryPath = Path.Combine(parentPath, newDirectoryName);//create new path for the directory with parent path and name 

                            
                            try//create new directory in the given node with given name and right image
                            {
                                
                                fileSystem.CreateDirectory(newDirectoryPath);

                                TreeNode newDirectoryNode = new TreeNode(newDirectoryName);
                                newDirectoryNode.ImageIndex = 1;
                                newDirectoryNode.SelectedImageIndex = 1;
                                selectedNode.Nodes.Add(newDirectoryName);
                                
                            }
                            catch (Exception ex)
                            {
                               
                                MessageBox.Show($"Failed to create the directory:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                               
                            }
                        }
                    }
                }
            }
        }

        private void NewFileButton_Click(object sender, EventArgs e)//create new file 
        {
            using (var createItemForm = new CreateItemForm())
            {
                if (createItemForm.ShowDialog() == DialogResult.OK)
                {
                    string newFileName = createItemForm.ItemName.Trim();//get name from user 

                    if (!string.IsNullOrEmpty(newFileName))//make sure name is not null
                    {
                        if (newFileName.Length > 8) // Check if the length of the filename is more than 8 characters
                        {
                            MessageBox.Show("File name cannot be longer than 8 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        TreeNode selectedNode = DirectoryTreeView.SelectedNode;//get the selected node for the file to be created within
                        if (selectedNode != null)
                        {
                            string selectedDirectory = selectedNode.FullPath;//get selected directory path
                            string selectedPath = Path.Combine(rootDirectory, selectedDirectory);

                            string selectedExtension = createItemForm.SelectedExtension;// Get the selected file extension from the ComboBox
                            if (selectedExtension == "")//if no extension was selected make it .txt by default
                            {
                                selectedExtension = ".txt";
                            }

                            string newFilePath = Path.Combine(selectedPath, newFileName + selectedExtension);//create path for file 
                            if (FileExistsInDirectories(newFileName + selectedExtension))
                            {
                                MessageBox.Show("File with the Same name and extension already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string fileContent = PromptForFileContent(newFilePath);//ask user for the file content 

                            if (fileContent == null)
                            {
                                return;
                            }

                            try
                            {
                                File.WriteAllText(newFilePath, fileContent);// Create the file with the provided content

                                FilelistView.SmallImageList = imageList1;
                                int imageIndex = GetImageIndexForFileExtension(selectedExtension);
                                FilelistView.Items.Add(newFileName + selectedExtension, imageIndex);
                                PopulateDirectoryTreeView(rootDirectory, DirectoryTreeView.Nodes);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Failed to create the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }


        private string PromptForFileContent(string filePath)//get the file content 
        {
            using (var fileContentForm = new FileContentForm(filePath, ""))
            {
                if (fileContentForm.ShowDialog() == DialogResult.OK)
                {
                    return fileContentForm.Content;
                }
                else
                {
                    return null;
                }
            }
        }

       
        private void ShowFilesInDirectory(string directoryPath)
        {
            try
            {
                if (directoryPath != lastSelectedDirectory)
                {
                    FilelistView.Items.Clear();

                   
                    string[] files = Directory.GetFiles(directoryPath); // Get all files from the directory

                    foreach (string file in files)
                    {
                       
                        string fileName = Path.GetFileName(file);
                        string parentDirectory = Path.GetDirectoryName(file);

                        string fileExtension=Path.GetExtension(file).ToLower();
                        int imageIndex = GetImageIndexForFileExtension(fileExtension);
                        ListViewItem item = new ListViewItem(new string[] { fileName, parentDirectory });
                        item.ImageIndex = imageIndex;
                        

;                       FilelistView.Items.Add(item);
                    }

                    lastSelectedDirectory = directoryPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load files from directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetImageIndexForFileExtension(string fileExtension)//get the right image depending on extension 
        {
            switch (fileExtension)
            {
                case ".txt":
                    return 5;
                case ".docx":
                    return 6;
                case ".pdf":
                    return 7; 
                default:
                    return 0; 
            }
        }

        private List<string> GetDirectoryNodes()
        {
            List<string> directories = new List<string>();
            foreach (TreeNode node in DirectoryTreeView.Nodes)
            {
               
                directories.Add(node.Text); // Add directory nodes to the list
            }
            return directories;
        }
        private List<string> GetFileNodes()
        {
            List<string> files = new List<string>();
            foreach (ListViewItem item in FilelistView.Items)
            {
               
                files.Add(item.Text); // Add file nodes to the list
            }
            return files;
        }
       
        private void DeleteDirectoryToolStripMenuItem_Click(object sender, EventArgs e)//delete a direcotry from menu option 
        {
            TreeNode selectedNode = DirectoryTreeView.SelectedNode;//get selected node to delete
            if (selectedNode != null)
            {
                string selectedPath = Path.Combine(rootDirectory, selectedNode.FullPath);
                if (MessageBox.Show($"Are you sure you want to delete '{selectedNode.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (File.Exists(selectedPath)) //Check if selected item is a file
                        {
                            File.Delete(selectedPath);//Delete the file
                        }
                        else if (Directory.Exists(selectedPath))// Check if selected item is a directory
                        {
                            DeleteDirectoryWithRetry(selectedPath);
                        }

                        selectedNode.Remove();//Remove node from the tree view
                        RemoveFileFromListView(selectedNode.Text);//Remove file from the list view
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RemoveFileFromListView(string fileName)//remove file from loist view 
        {
            foreach (ListViewItem item in FilelistView.Items)
            {
                if (item.Text == fileName)
                {
                    FilelistView.Items.Remove(item);
                    return;
                }
            }
        }


        private void CheckAndModifyFileAttributes(string filePath)//
        {
            try
            {
                // Get the attributes of the file
                FileAttributes attributes = File.GetAttributes(filePath);

                // Check if the file is read-only or has the system attribute
                if ((attributes & (FileAttributes.ReadOnly | FileAttributes.System)) != 0)
                {
                    // Remove read-only and system attributes
                    attributes &= ~(FileAttributes.ReadOnly | FileAttributes.System);
                    File.SetAttributes(filePath, attributes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking and modifying file attributes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DeleteDirectoryWithRetry(string directoryPath) {  const int maxRetryCount = 3;
            const int retryDelayMilliseconds = 500;

            for (int i = 0; i < maxRetryCount; i++)
            {
                try
                {
                    Directory.Delete(directoryPath, true); // Delete directory recursively
                    return; 
                }
                catch (IOException) when (i < maxRetryCount - 1) // Retry on IOException
                {
                    
                    System.Threading.Thread.Sleep(retryDelayMilliseconds);
                }
            }

            
            throw new IOException($"Failed to delete directory '{directoryPath}' after {maxRetryCount} attempts.");
        }


        private void DeleteFileToolStripMenuItem_Click(object sender, EventArgs e)//delete file using file menu option 
        {
            ListViewItem selectedItem = FilelistView.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (selectedItem != null)
            {
                string parentDirectory = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;
                string filePath = Path.Combine(rootDirectory, parentDirectory, selectedItem.Text);
                if (MessageBox.Show($"Are you sure you want to delete the file '{selectedItem.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                       
                        DeleteFileWithRetry(filePath);
                        selectedItem.Remove();
                        RemoveFileFromDirectoryTreeView(selectedItem.Text);

                        
                        PopulateDirectoryTreeView(rootDirectory, DirectoryTreeView.Nodes);// Repopulate the directory tree view after deleting the file
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void RemoveFileFromDirectoryTreeView(string fileName)//remove file from list view 
        {
            foreach (TreeNode directoryNode in DirectoryTreeView.Nodes)
            {
                
                foreach (TreeNode fileNode in directoryNode.Nodes)
                {
                    
                    if (fileNode.Text == fileName)//find file to be deleted 
                    {
                       
                        fileNode.Remove();
                        return; 
                    }
                }
            }
        }

        private void DeleteFileWithRetry(string filePath)//delete file retrying 
        {
            const int maxRetryCount = 3;
            const int retryDelayMilliseconds = 500;

            for (int i = 0; i < maxRetryCount; i++)
            {
                try
                {
                    
                    CheckAndModifyFileAttributes(filePath);

                   
                    File.Delete(filePath);
                    return;
                }
                catch (IOException ex)
                {
                   
                    Console.WriteLine($"IOException occurred while deleting file '{filePath}' (Attempt {i + 1}/{maxRetryCount}): {ex.Message}");

                    if (i < maxRetryCount - 1)
                    {
                        
                        System.Threading.Thread.Sleep(retryDelayMilliseconds);
                    }
                    else
                    {
                        throw new IOException($"Failed to delete file '{filePath}' after {maxRetryCount} attempts.", ex);
                    }
                }
            }
        }

      
        private void logoutButton_Click(object sender, EventArgs e)//save information when loging out 
        {
            string filePath = Path.Combine(rootDirectory, "directory_structure.xml");
            fileSystem.SaveDirectoryStructure(filePath, GetDirectoryNodes(), GetFileNodes());

            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)//open the file using menu strip
        {
            ListViewItem selectedItem = FilelistView.SelectedItems.Cast<ListViewItem>().FirstOrDefault();//get selescted item 
            if (selectedItem != null)
            {
                TreeNode selectedNode = DirectoryTreeView.SelectedNode;//get the directory it belongs to
                if (selectedNode != null)
                {
                    
                    while (selectedNode.Parent != null && selectedNode.Parent.Parent != null)
                    {
                        selectedNode = selectedNode.Parent;
                    }

                    string parentDirectory = selectedNode.FullPath;

                    string filePath = Path.Combine(rootDirectory, parentDirectory, selectedItem.Text);
                    try
                    {
                        string fileContent = File.ReadAllText(filePath);  
                        bool isPDF = Path.GetExtension(filePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase);// Determine if the file is a PDF based on its extension

                        ShowFileContent(filePath, fileContent, isPDF);// Show the content in the FileContentForm along with the file path
                    }
                    
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ShowFileContent(string filePath, string content, bool IsPDF)//show the content in file
        {
            using (FileContentForm fileContentForm = new FileContentForm(filePath, content, IsPDF))
            {
                if (fileContentForm.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(filePath, fileContentForm.Content);//Save the content if the user clicks "Save"
                }
            }
        }

    }
}

