namespace CivilEngineeringManager.TestProjects
{
    partial class TestProject
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
            this.treeListView2 = new BrightIdeasSoftware.TreeListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView2)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListView2
            // 
            this.treeListView2.AllColumns.Add(this.olvColumn1);
            this.treeListView2.AllColumns.Add(this.olvColumn2);
            this.treeListView2.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.treeListView2.CellEditEnterChangesRows = true;
            this.treeListView2.CellEditTabChangesRows = true;
            this.treeListView2.CellEditUseWholeCell = false;
            this.treeListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2});
            this.treeListView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView2.HideSelection = false;
            this.treeListView2.Location = new System.Drawing.Point(157, 40);
            this.treeListView2.Name = "treeListView2";
            this.treeListView2.ShowGroups = false;
            this.treeListView2.Size = new System.Drawing.Size(636, 385);
            this.treeListView2.TabIndex = 0;
            this.treeListView2.UseCompatibleStateImageBehavior = false;
            this.treeListView2.View = System.Windows.Forms.View.Details;
            this.treeListView2.VirtualMode = true;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.Text = "Name";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Description";
            this.olvColumn2.Text = "Description";
            this.olvColumn2.Width = 92;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 467);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeListView2);
            this.Name = "TestProject";
            this.Text = "TestProject";
            ((System.ComponentModel.ISupportInitialize)(this.treeListView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView2;
        private System.Windows.Forms.Button button1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
    }
}