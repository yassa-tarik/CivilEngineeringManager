namespace CivilEngineeringManager.TestProjects
{
    partial class FormTreeWithDTOs
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
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnSendTree = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvColumn1);
            this.treeListView1.AllColumns.Add(this.olvColumn2);
            this.treeListView1.AllColumns.Add(this.olvColumn3);
            this.treeListView1.AllColumns.Add(this.olvColumn4);
            this.treeListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.treeListView1.CellEditUseWholeCell = false;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4});
            this.treeListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListView1.FullRowSelect = true;
            this.treeListView1.HideSelection = false;
            this.treeListView1.Location = new System.Drawing.Point(23, 22);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(975, 530);
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Designation";
            this.olvColumn1.Text = "Designation";
            this.olvColumn1.Width = 400;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "ID";
            this.olvColumn2.Text = "ID";
            this.olvColumn2.Width = 80;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Unit";
            this.olvColumn3.Text = "Unit";
            this.olvColumn3.Width = 200;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "UnitPrice";
            this.olvColumn4.AspectToStringFormat = "";
            this.olvColumn4.Text = "Unit Price";
            this.olvColumn4.Width = 300;
            // 
            // btnSendTree
            // 
            this.btnSendTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendTree.Location = new System.Drawing.Point(1009, 216);
            this.btnSendTree.Name = "btnSendTree";
            this.btnSendTree.Size = new System.Drawing.Size(110, 73);
            this.btnSendTree.TabIndex = 1;
            this.btnSendTree.Text = "Send Tree";
            this.btnSendTree.UseVisualStyleBackColor = true;
            this.btnSendTree.Click += new System.EventHandler(this.btnSendTree_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryToolStripMenuItem,
            this.typeToolStripMenuItem,
            this.specToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 70);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.categoryToolStripMenuItem.Text = "Category";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.typeToolStripMenuItem.Text = "Type";
            // 
            // specToolStripMenuItem
            // 
            this.specToolStripMenuItem.Name = "specToolStripMenuItem";
            this.specToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.specToolStripMenuItem.Text = "Spec";
            // 
            // FormTreeWithDTOs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 617);
            this.Controls.Add(this.btnSendTree);
            this.Controls.Add(this.treeListView1);
            this.Name = "FormTreeWithDTOs";
            this.Text = "TreeWithDTOs";
            this.Load += new System.EventHandler(this.TreeWithDTOs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private System.Windows.Forms.Button btnSendTree;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specToolStripMenuItem;
    }
}