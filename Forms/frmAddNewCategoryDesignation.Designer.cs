namespace CivilEngineeringManager.Forms
{
    partial class frmAddNewCategoryDesignation
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewCatDesign = new System.Windows.Forms.Button();
            this.txtCatDesign = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(552, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "NB: Verifier soigneusement si le nom n\'existe pas avant d\'en ajouter un autre.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Entrer le nom ici:";
            // 
            // btnAddNewCatDesign
            // 
            this.btnAddNewCatDesign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCatDesign.Location = new System.Drawing.Point(600, 76);
            this.btnAddNewCatDesign.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewCatDesign.Name = "btnAddNewCatDesign";
            this.btnAddNewCatDesign.Size = new System.Drawing.Size(121, 32);
            this.btnAddNewCatDesign.TabIndex = 5;
            this.btnAddNewCatDesign.Text = "Ajouter";
            this.btnAddNewCatDesign.UseVisualStyleBackColor = true;
            this.btnAddNewCatDesign.Click += new System.EventHandler(this.btnAddNewCatDesign_Click);
            // 
            // txtCatDesign
            // 
            this.txtCatDesign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatDesign.Location = new System.Drawing.Point(158, 26);
            this.txtCatDesign.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCatDesign.Name = "txtCatDesign";
            this.txtCatDesign.Size = new System.Drawing.Size(563, 26);
            this.txtCatDesign.TabIndex = 4;
            // 
            // frmAddNewCategoryDesignation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 132);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNewCatDesign);
            this.Controls.Add(this.txtCatDesign);
            this.Name = "frmAddNewCategoryDesignation";
            this.Text = "frmAddNewCategoryDesignation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewCatDesign;
        private System.Windows.Forms.TextBox txtCatDesign;
    }
}