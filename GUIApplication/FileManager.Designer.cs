namespace GUIApplication
{
    partial class FileManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManager));
            this.DirectoryTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStripDirectory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.FilelistView = new System.Windows.Forms.ListView();
            this.contextMenuStripFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DirectoryLabel = new System.Windows.Forms.Label();
            this.FilesLabel = new System.Windows.Forms.Label();
            this.NewDirectoryButton = new System.Windows.Forms.Button();
            this.NewFileButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.contextMenuStripDirectory.SuspendLayout();
            this.contextMenuStripFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectoryTreeView
            // 
            this.DirectoryTreeView.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DirectoryTreeView.ContextMenuStrip = this.contextMenuStripDirectory;
            this.DirectoryTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryTreeView.ImageIndex = 1;
            this.DirectoryTreeView.ImageList = this.imageList1;
            this.DirectoryTreeView.LabelEdit = true;
            this.DirectoryTreeView.Location = new System.Drawing.Point(14, 129);
            this.DirectoryTreeView.Name = "DirectoryTreeView";
            this.DirectoryTreeView.SelectedImageIndex = 1;
            this.DirectoryTreeView.Size = new System.Drawing.Size(311, 735);
            this.DirectoryTreeView.TabIndex = 0;
            this.DirectoryTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DirectoryTreeView_MouseClick);
            // 
            // contextMenuStripDirectory
            // 
            this.contextMenuStripDirectory.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripDirectory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteDirectoryToolStripMenuItem});
            this.contextMenuStripDirectory.Name = "contextMenuStripDirectory";
            this.contextMenuStripDirectory.Size = new System.Drawing.Size(263, 42);
            // 
            // DeleteDirectoryToolStripMenuItem
            // 
            this.DeleteDirectoryToolStripMenuItem.Name = "DeleteDirectoryToolStripMenuItem";
            this.DeleteDirectoryToolStripMenuItem.Size = new System.Drawing.Size(262, 38);
            this.DeleteDirectoryToolStripMenuItem.Text = "Delete Directory";
            this.DeleteDirectoryToolStripMenuItem.Click += new System.EventHandler(this.DeleteDirectoryToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "file.png");
            this.imageList1.Images.SetKeyName(2, "document.png");
            this.imageList1.Images.SetKeyName(3, "downloads.png");
            this.imageList1.Images.SetKeyName(4, "home.png");
            this.imageList1.Images.SetKeyName(5, "txt.png");
            this.imageList1.Images.SetKeyName(6, "docx.png");
            this.imageList1.Images.SetKeyName(7, "pdf (1).png");
            // 
            // FilelistView
            // 
            this.FilelistView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.FilelistView.AllowColumnReorder = true;
            this.FilelistView.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FilelistView.ContextMenuStrip = this.contextMenuStripFile;
            this.FilelistView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilelistView.HideSelection = false;
            this.FilelistView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FilelistView.LabelEdit = true;
            this.FilelistView.LabelWrap = false;
            this.FilelistView.Location = new System.Drawing.Point(348, 129);
            this.FilelistView.MultiSelect = false;
            this.FilelistView.Name = "FilelistView";
            this.FilelistView.Size = new System.Drawing.Size(979, 735);
            this.FilelistView.SmallImageList = this.imageList1;
            this.FilelistView.TabIndex = 1;
            this.FilelistView.UseCompatibleStateImageBehavior = false;
            this.FilelistView.View = System.Windows.Forms.View.List;
            this.FilelistView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FilelistView_MouseClick);
            // 
            // contextMenuStripFile
            // 
            this.contextMenuStripFile.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileToolStripMenuItem,
            this.DeleteFileToolStripMenuItem});
            this.contextMenuStripFile.Name = "contextMenuStripFile";
            this.contextMenuStripFile.Size = new System.Drawing.Size(203, 80);
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(202, 38);
            this.OpenFileToolStripMenuItem.Text = "Open File";
            this.OpenFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // DeleteFileToolStripMenuItem
            // 
            this.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem";
            this.DeleteFileToolStripMenuItem.Size = new System.Drawing.Size(202, 38);
            this.DeleteFileToolStripMenuItem.Text = "Delete File";
            this.DeleteFileToolStripMenuItem.Click += new System.EventHandler(this.DeleteFileToolStripMenuItem_Click);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DirectoryLabel.Location = new System.Drawing.Point(27, 46);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(216, 55);
            this.DirectoryLabel.TabIndex = 2;
            this.DirectoryLabel.Text = "Directory";
            // 
            // FilesLabel
            // 
            this.FilesLabel.AutoSize = true;
            this.FilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilesLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FilesLabel.Location = new System.Drawing.Point(338, 46);
            this.FilesLabel.Name = "FilesLabel";
            this.FilesLabel.Size = new System.Drawing.Size(124, 55);
            this.FilesLabel.TabIndex = 3;
            this.FilesLabel.Text = "Files";
            // 
            // NewDirectoryButton
            // 
            this.NewDirectoryButton.AutoSize = true;
            this.NewDirectoryButton.BackColor = System.Drawing.Color.Navy;
            this.NewDirectoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewDirectoryButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NewDirectoryButton.Location = new System.Drawing.Point(249, 40);
            this.NewDirectoryButton.Name = "NewDirectoryButton";
            this.NewDirectoryButton.Size = new System.Drawing.Size(57, 61);
            this.NewDirectoryButton.TabIndex = 4;
            this.NewDirectoryButton.Text = "+";
            this.NewDirectoryButton.UseVisualStyleBackColor = false;
            this.NewDirectoryButton.Click += new System.EventHandler(this.NewDirectoryButton_Click);
            // 
            // NewFileButton
            // 
            this.NewFileButton.AutoSize = true;
            this.NewFileButton.BackColor = System.Drawing.Color.Navy;
            this.NewFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFileButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NewFileButton.Location = new System.Drawing.Point(468, 44);
            this.NewFileButton.Name = "NewFileButton";
            this.NewFileButton.Size = new System.Drawing.Size(57, 61);
            this.NewFileButton.TabIndex = 5;
            this.NewFileButton.Text = "+";
            this.NewFileButton.UseVisualStyleBackColor = false;
            this.NewFileButton.Click += new System.EventHandler(this.NewFileButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.AutoSize = true;
            this.logoutButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.logoutButton.Location = new System.Drawing.Point(1134, 45);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(173, 68);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1374, 929);
            this.ControlBox = false;
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.NewFileButton);
            this.Controls.Add(this.NewDirectoryButton);
            this.Controls.Add(this.FilesLabel);
            this.Controls.Add(this.DirectoryLabel);
            this.Controls.Add(this.FilelistView);
            this.Controls.Add(this.DirectoryTreeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileManager";
            this.Load += new System.EventHandler(this.FileManager_Load);
            this.contextMenuStripDirectory.ResumeLayout(false);
            this.contextMenuStripFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView DirectoryTreeView;
        private System.Windows.Forms.ListView FilelistView;
        private System.Windows.Forms.Label DirectoryLabel;
        private System.Windows.Forms.Label FilesLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDirectory;
        private System.Windows.Forms.ToolStripMenuItem DeleteDirectoryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFile;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteFileToolStripMenuItem;
        private System.Windows.Forms.Button NewDirectoryButton;
        private System.Windows.Forms.Button NewFileButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.ImageList imageList1;
    }
}