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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.iconDropDownButton1 = new FontAwesome.Sharp.IconDropDownButton();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.iconToolStripButton1 = new FontAwesome.Sharp.IconToolStripButton();
            this.flowLayoutPanelProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddNewProject = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(350, 29);
            this.textBox1.TabIndex = 0;
            // 
            // iconDropDownButton1
            // 
            this.iconDropDownButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconDropDownButton1.IconColor = System.Drawing.Color.Black;
            this.iconDropDownButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDropDownButton1.Name = "iconDropDownButton1";
            this.iconDropDownButton1.Size = new System.Drawing.Size(23, 23);
            this.iconDropDownButton1.Text = "iconDropDownButton1";
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(32, 19);
            this.iconMenuItem1.Text = "iconMenuItem1";
            // 
            // iconToolStripButton1
            // 
            this.iconToolStripButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconToolStripButton1.IconColor = System.Drawing.Color.Black;
            this.iconToolStripButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconToolStripButton1.Name = "iconToolStripButton1";
            this.iconToolStripButton1.Size = new System.Drawing.Size(23, 23);
            this.iconToolStripButton1.Text = "iconToolStripButton1";
            // 
            // flowLayoutPanelProjects
            // 
            this.flowLayoutPanelProjects.AutoScroll = true;
            this.flowLayoutPanelProjects.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelProjects.Location = new System.Drawing.Point(0, 57);
            this.flowLayoutPanelProjects.Name = "flowLayoutPanelProjects";
            this.flowLayoutPanelProjects.Size = new System.Drawing.Size(1180, 594);
            this.flowLayoutPanelProjects.TabIndex = 1;
            // 
            // btnAddNewProject
            // 
            this.btnAddNewProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewProject.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddNewProject.IconColor = System.Drawing.Color.Black;
            this.btnAddNewProject.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnAddNewProject.IconSize = 35;
            this.btnAddNewProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewProject.Location = new System.Drawing.Point(923, 12);
            this.btnAddNewProject.Name = "btnAddNewProject";
            this.btnAddNewProject.Size = new System.Drawing.Size(254, 39);
            this.btnAddNewProject.TabIndex = 2;
            this.btnAddNewProject.Text = "Add new project";
            this.btnAddNewProject.UseVisualStyleBackColor = true;
            this.btnAddNewProject.Click += new System.EventHandler(this.btnAddNewProject_Click);
            // 
            // frmProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 651);
            this.Controls.Add(this.btnAddNewProject);
            this.Controls.Add(this.flowLayoutPanelProjects);
            this.Controls.Add(this.textBox1);
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

        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconToolStripButton iconToolStripButton1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProjects;
        private FontAwesome.Sharp.IconButton btnAddNewProject;
    }
}