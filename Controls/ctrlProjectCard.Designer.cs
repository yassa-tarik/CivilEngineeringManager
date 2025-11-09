namespace CivilEngineeringManager.Controls
{
    partial class ctrlProjectCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblProjectName = new System.Windows.Forms.Label();
            this.pbProjectProgress = new System.Windows.Forms.ProgressBar();
            this.lblType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProjectType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(37, 38);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(80, 24);
            this.lblProjectName.TabIndex = 1;
            this.lblProjectName.Text = "<name>";
            // 
            // pbProjectProgress
            // 
            this.pbProjectProgress.Location = new System.Drawing.Point(37, 188);
            this.pbProjectProgress.Name = "pbProjectProgress";
            this.pbProjectProgress.Size = new System.Drawing.Size(219, 25);
            this.pbProjectProgress.Step = 1;
            this.pbProjectProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProjectProgress.TabIndex = 2;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(37, 98);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(58, 24);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Progress";
            // 
            // lblProjectType
            // 
            this.lblProjectType.AutoSize = true;
            this.lblProjectType.Location = new System.Drawing.Point(107, 98);
            this.lblProjectType.Name = "lblProjectType";
            this.lblProjectType.Size = new System.Drawing.Size(67, 24);
            this.lblProjectType.TabIndex = 5;
            this.lblProjectType.Text = "<type>";
            // 
            // ctrlProjectCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.lblProjectType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.pbProjectProgress);
            this.Controls.Add(this.lblProjectName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ctrlProjectCard";
            this.Size = new System.Drawing.Size(329, 227);
            this.Load += new System.EventHandler(this.ctrlProjectCard_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctrlProjectCard_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblProjectType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ProgressBar pbProjectProgress;
        private System.Windows.Forms.Label lblProjectName;
    }
}
