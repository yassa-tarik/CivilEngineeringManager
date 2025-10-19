namespace CivilEngineeringManager.Forms
{
    partial class AddEditProjectSpecifications
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
            this.olvDesignation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUnit = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUnitPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTotal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFind = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSaveTree = new System.Windows.Forms.Button();
            this.btnAddNewCat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvDesignation);
            this.treeListView1.AllColumns.Add(this.olvUnit);
            this.treeListView1.AllColumns.Add(this.olvUnitPrice);
            this.treeListView1.AllColumns.Add(this.olvQuantity);
            this.treeListView1.AllColumns.Add(this.olvTotal);
            this.treeListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.treeListView1.CellEditUseWholeCell = false;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvDesignation,
            this.olvUnit,
            this.olvUnitPrice,
            this.olvQuantity,
            this.olvTotal});
            this.treeListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.treeListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListView1.FullRowSelect = true;
            this.treeListView1.GridLines = true;
            this.treeListView1.HideSelection = false;
            this.treeListView1.Location = new System.Drawing.Point(0, 160);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(1241, 582);
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            this.treeListView1.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.treeListView1_CellEditFinished);
            this.treeListView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeListView1_MouseClick);
            // 
            // olvDesignation
            // 
            this.olvDesignation.AspectName = "Designation";
            this.olvDesignation.Text = "Designation";
            this.olvDesignation.Width = 650;
            // 
            // olvUnit
            // 
            this.olvUnit.AspectName = "Unit";
            this.olvUnit.Text = "Unit";
            this.olvUnit.Width = 145;
            // 
            // olvUnitPrice
            // 
            this.olvUnitPrice.AspectName = "UnitPrice";
            this.olvUnitPrice.Text = "Unit Price";
            this.olvUnitPrice.Width = 135;
            // 
            // olvQuantity
            // 
            this.olvQuantity.AspectName = "Quantity";
            this.olvQuantity.Text = "Quantity";
            this.olvQuantity.Width = 130;
            // 
            // olvTotal
            // 
            this.olvTotal.AspectName = "Amount";
            this.olvTotal.Text = "Total";
            this.olvTotal.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryToolStripMenuItem,
            this.typeToolStripMenuItem,
            this.specToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 82);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.categoryToolStripMenuItem.Text = "Work Category";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.typeToolStripMenuItem.Text = "Work Type";
            this.typeToolStripMenuItem.Click += new System.EventHandler(this.typeToolStripMenuItem_Click);
            // 
            // specToolStripMenuItem
            // 
            this.specToolStripMenuItem.Name = "specToolStripMenuItem";
            this.specToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.specToolStripMenuItem.Text = "Work Spec";
            this.specToolStripMenuItem.Click += new System.EventHandler(this.specToolStripMenuItem_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(482, 29);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(144, 28);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(31, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(416, 28);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "Choose a Project";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Category 1",
            "Category 2"});
            this.comboBox2.Location = new System.Drawing.Point(31, 105);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(416, 28);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 10;
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(1145, 43);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(84, 30);
            this.btnExpand.TabIndex = 12;
            this.btnExpand.Text = "Expand All";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Location = new System.Drawing.Point(1145, 7);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(84, 30);
            this.btnCollapse.TabIndex = 13;
            this.btnCollapse.Text = "Collapse All";
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(683, 29);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(117, 28);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSaveTree
            // 
            this.btnSaveTree.Location = new System.Drawing.Point(1145, 88);
            this.btnSaveTree.Name = "btnSaveTree";
            this.btnSaveTree.Size = new System.Drawing.Size(84, 62);
            this.btnSaveTree.TabIndex = 15;
            this.btnSaveTree.Text = "Save Tree";
            this.btnSaveTree.UseVisualStyleBackColor = true;
            this.btnSaveTree.Click += new System.EventHandler(this.btnSaveTree_Click);
            // 
            // btnAddNewCat
            // 
            this.btnAddNewCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCat.Location = new System.Drawing.Point(482, 105);
            this.btnAddNewCat.Name = "btnAddNewCat";
            this.btnAddNewCat.Size = new System.Drawing.Size(144, 28);
            this.btnAddNewCat.TabIndex = 16;
            this.btnAddNewCat.Text = "Add new Category";
            this.btnAddNewCat.UseVisualStyleBackColor = true;
            this.btnAddNewCat.Click += new System.EventHandler(this.btnAddNewCat_Click);
            // 
            // AddEditProjectSpecifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 742);
            this.Controls.Add(this.btnAddNewCat);
            this.Controls.Add(this.btnSaveTree);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCollapse);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.treeListView1);
            this.Name = "AddEditProjectSpecifications";
            this.Text = "AddEditProjectSpecifications";
            this.Load += new System.EventHandler(this.AddEditProjectSpecifications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private BrightIdeasSoftware.OLVColumn olvDesignation;
        private BrightIdeasSoftware.OLVColumn olvUnit;
        private BrightIdeasSoftware.OLVColumn olvUnitPrice;
        private BrightIdeasSoftware.OLVColumn olvQuantity;
        private BrightIdeasSoftware.OLVColumn olvTotal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specToolStripMenuItem;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSaveTree;
        private System.Windows.Forms.Button btnAddNewCat;
    }
}