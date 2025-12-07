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
            this.lblProgress = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
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
            this.lblProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.Location = new System.Drawing.Point(98, 38);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(107, 29);
            this.lblProjectName.TabIndex = 1;
            this.lblProjectName.Text = "<name>";
            this.lblProjectName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctrlProjectCard_MouseClick);
            // 
            // pbProjectProgress
            // 
            this.pbProjectProgress.Location = new System.Drawing.Point(23, 188);
            this.pbProjectProgress.Name = "pbProjectProgress";
            this.pbProjectProgress.Size = new System.Drawing.Size(257, 25);
            this.pbProjectProgress.Step = 1;
            this.pbProjectProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProjectProgress.TabIndex = 2;
            this.pbProjectProgress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctrlProjectCard_MouseClick);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(24, 98);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(58, 24);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type:";
            this.lblType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctrlProjectCard_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Progress";
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctrlProjectCard_MouseClick);
            // 
            // lblProjectType
            // 
            this.lblProjectType.AutoSize = true;
            this.lblProjectType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectType.Location = new System.Drawing.Point(94, 98);
            this.lblProjectType.Name = "lblProjectType";
            this.lblProjectType.Size = new System.Drawing.Size(77, 24);
            this.lblProjectType.TabIndex = 5;
            this.lblProjectType.Text = "<type>";
            this.lblProjectType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctrlProjectCard_MouseClick);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(231, 158);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(49, 24);
            this.lblProgress.TabIndex = 6;
            this.lblProgress.Text = "<pr>";
            this.lblProgress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctrlProjectCard_MouseClick);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.PaleGreen;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(45, 241);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(81, 30);
            this.iconButton1.TabIndex = 7;
            this.iconButton1.Text = "Edit";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.LightSalmon;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(134, 241);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(98, 30);
            this.iconButton2.TabIndex = 8;
            this.iconButton2.Text = "Delete";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // ctrlProjectCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblProjectType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.pbProjectProgress);
            this.Controls.Add(this.lblProjectName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ctrlProjectCard";
            this.Size = new System.Drawing.Size(302, 280);
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
        private System.Windows.Forms.Label lblProgress;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}
