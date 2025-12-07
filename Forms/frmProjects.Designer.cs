namespace CivilEngineeringManager.Forms
{
    partial class frmProjects
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
            this.flowLayoutPanelProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddNewProject = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new PlaceholderTextBox.PlaceholderTextBox();
            this.SuspendLayout();
            // 
            // flowLayoutPanelProjects
            // 
            this.flowLayoutPanelProjects.AutoScroll = true;
            this.flowLayoutPanelProjects.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelProjects.Location = new System.Drawing.Point(0, 179);
            this.flowLayoutPanelProjects.Name = "flowLayoutPanelProjects";
            this.flowLayoutPanelProjects.Size = new System.Drawing.Size(1180, 472);
            this.flowLayoutPanelProjects.TabIndex = 1;
            // 
            // btnAddNewProject
            // 
            this.btnAddNewProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewProject.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAddNewProject.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddNewProject.IconColor = System.Drawing.Color.Black;
            this.btnAddNewProject.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnAddNewProject.IconSize = 35;
            this.btnAddNewProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewProject.Location = new System.Drawing.Point(931, 59);
            this.btnAddNewProject.Name = "btnAddNewProject";
            this.btnAddNewProject.Size = new System.Drawing.Size(237, 39);
            this.btnAddNewProject.TabIndex = 2;
            this.btnAddNewProject.Text = "Add new project";
            this.btnAddNewProject.UseVisualStyleBackColor = false;
            this.btnAddNewProject.Click += new System.EventHandler(this.btnAddNewProject_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(12, 64);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "search project";
            this.txtSearch.Size = new System.Drawing.Size(602, 29);
            this.txtSearch.TabIndex = 3;
            // 
            // frmProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 651);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAddNewProject);
            this.Controls.Add(this.flowLayoutPanelProjects);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmProjects";
            this.Text = "frmProjects";
            this.Load += new System.EventHandler(this.frmProjects_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProjects;
        private FontAwesome.Sharp.IconButton btnAddNewProject;
        private PlaceholderTextBox.PlaceholderTextBox txtSearch;
    }
}