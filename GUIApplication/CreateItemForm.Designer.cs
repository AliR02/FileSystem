namespace GUIApplication
{
    partial class CreateItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateItemForm));
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.ItemNameBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ExtensionComboBox = new System.Windows.Forms.ComboBox();
            this.ExtensionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ItemNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemNameLabel.Location = new System.Drawing.Point(12, 9);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(127, 42);
            this.ItemNameLabel.TabIndex = 0;
            this.ItemNameLabel.Text = "Name:";
            this.ItemNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ItemNameBox
            // 
            this.ItemNameBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ItemNameBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ItemNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemNameBox.Location = new System.Drawing.Point(136, 9);
            this.ItemNameBox.Name = "ItemNameBox";
            this.ItemNameBox.Size = new System.Drawing.Size(275, 44);
            this.ItemNameBox.TabIndex = 1;
            // 
            // CreateButton
            // 
            this.CreateButton.AutoSize = true;
            this.CreateButton.BackColor = System.Drawing.Color.Green;
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.Location = new System.Drawing.Point(97, 87);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(148, 58);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.AutoSize = true;
            this.CancelButton.BackColor = System.Drawing.Color.Green;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(288, 87);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(164, 58);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ExtensionComboBox
            // 
            this.ExtensionComboBox.FormattingEnabled = true;
            this.ExtensionComboBox.Items.AddRange(new object[] {
            ".txt",
            ".docx",
            ".pdf"});
            this.ExtensionComboBox.Location = new System.Drawing.Point(521, 18);
            this.ExtensionComboBox.Name = "ExtensionComboBox";
            this.ExtensionComboBox.Size = new System.Drawing.Size(121, 33);
            this.ExtensionComboBox.TabIndex = 4;
            // 
            // ExtensionLabel
            // 
            this.ExtensionLabel.AutoSize = true;
            this.ExtensionLabel.Location = new System.Drawing.Point(417, 21);
            this.ExtensionLabel.Name = "ExtensionLabel";
            this.ExtensionLabel.Size = new System.Drawing.Size(107, 25);
            this.ExtensionLabel.TabIndex = 5;
            this.ExtensionLabel.Text = "Extension";
            // 
            // CreateItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(666, 163);
            this.ControlBox = false;
            this.Controls.Add(this.ExtensionLabel);
            this.Controls.Add(this.ExtensionComboBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.ItemNameBox);
            this.Controls.Add(this.ItemNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.TextBox ItemNameBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox ExtensionComboBox;
        private System.Windows.Forms.Label ExtensionLabel;
    }
}