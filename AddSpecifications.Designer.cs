namespace CivilEngineeringManager
{
    partial class AddSpecifications
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
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvColumn2);
            this.treeListView1.AllColumns.Add(this.olvColumn1);
            this.treeListView1.AllColumns.Add(this.olvColumn3);
            this.treeListView1.AllColumns.Add(this.olvColumn4);
            this.treeListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.treeListView1.CellEditUseWholeCell = false;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2,
            this.olvColumn1,
            this.olvColumn3,
            this.olvColumn4});
            this.treeListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView1.FullRowSelect = true;
            this.treeListView1.HideSelection = false;
            this.treeListView1.Location = new System.Drawing.Point(200, 61);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(853, 433);
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            this.treeListView1.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.treeListView1_CellRightClick);
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Designation";
            this.olvColumn2.Text = "Designation";
            this.olvColumn2.Width = 400;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "ID";
            this.olvColumn1.CellEditUseWholeCell = true;
            this.olvColumn1.Text = "ID";
            this.olvColumn1.Width = 74;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Unit";
            this.olvColumn3.Text = "Unit";
            this.olvColumn3.Width = 95;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "UnitPrice";
            this.olvColumn4.Text = "Unit Price";
            this.olvColumn4.Width = 132;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryToolStripMenuItem,
            this.typeToolStripMenuItem,
            this.specToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 97);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.typeToolStripMenuItem.Text = "Type";
            // 
            // specToolStripMenuItem
            // 
            this.specToolStripMenuItem.Name = "specToolStripMenuItem";
            this.specToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.specToolStripMenuItem.Text = "Spec";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Category 1",
            "Category 2"});
            this.comboBox2.Location = new System.Drawing.Point(24, 61);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(139, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Project 1",
            "Project 2"});
            this.comboBox1.Location = new System.Drawing.Point(200, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(232, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Choose a Project";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(476, 7);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(117, 29);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Items.AddRange(new object[] {
            "Item 1",
            "Item 2",
            "Item 3"});
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(180, 23);
            this.categoryToolStripMenuItem.Text = "Category";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // AddSpecifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 580);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.treeListView1);
            this.Name = "AddSpecifications";
            this.Text = "AddSpecifications";
            this.Load += new System.EventHandler(this.AddSpecifications_Load);
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
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specToolStripMenuItem;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ToolStripComboBox categoryToolStripMenuItem;
    }
}