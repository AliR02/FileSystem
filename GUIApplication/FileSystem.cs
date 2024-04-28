using GUIApplication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace GUIApplication
{
    public class FileSystem
    {
        private readonly string rootDirectory;

        public FileSystem(string rootDirectoryPath)//make sure root directory exist
        {
            rootDirectory = rootDirectoryPath;
            if (!Directory.Exists(rootDirectory))
            {
                Directory.CreateDirectory(rootDirectory);
            }
        }
        public bool CreateFile(string filePath)//crete file and return if it has been created 
        {
            try
            {
                
                string fullPath = Path.Combine(rootDirectory, filePath);//fullpath is the combination of file name  and root directory

                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

               
                File.Create(fullPath).Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file: {ex.Message}");
                return false;
            }
        }

        public bool CreateDirectory(string DirPath)//create direcotry and return if successful
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(rootDirectory, DirPath));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory: {ex.Message}");
                return false;
            }
        }

       
        public void SaveDirectoryStructure(string filePath, List<string> directories, List<string> files) // Save directory structure with image
        {
            try
            {
                XElement root = new XElement("DirectoryStructure");

                foreach (string directoryName in directories)//save directories 
                {
                    XElement directoryElement = new XElement("Directory");
                    directoryElement.Add(new XAttribute("Name", directoryName));
                    root.Add(directoryElement);
                }

                foreach (string fileName in files)//save files
                {
                    XElement fileElement = new XElement("File");
                    fileElement.Add(new XAttribute("Name", fileName));
                    root.Add(fileElement);
                }

                root.Save(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save directory structure: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDirectoryStructure(string filePath, out List<string> directories, out List<string> files)//load information saved
        {
            directories = new List<string>();
            files = new List<string>();

            try
            {
                if (File.Exists(filePath))
                {
                    XElement root = XElement.Load(filePath);

                    foreach (XElement directoryElement in root.Elements("Directory"))
                    {
                        string directoryName = directoryElement.Attribute("Name").Value;
                        directories.Add(directoryName);
                    }

                    foreach (XElement fileElement in root.Elements("File"))
                    {
                        string fileName = fileElement.Attribute("Name").Value;
                        files.Add(fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load directory structure: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }


}

