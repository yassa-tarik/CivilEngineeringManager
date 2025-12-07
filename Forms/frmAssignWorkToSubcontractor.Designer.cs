namespace CivilEngineeringManager.Forms
{
    partial class frmAssignWorkToSubcontractor
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
            this.btnAddNewCat = new System.Windows.Forms.Button();
            this.btnSaveTree = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.comboSubcontractor = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.comboProjects = new System.Windows.Forms.ComboBox();
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.olvDesignation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUnit = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUnitPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTotal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvAssignedQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvNegotiatedUnitPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewCat
            // 
            this.btnAddNewCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCat.Location = new System.Drawing.Point(961, 44);
            this.btnAddNewCat.Name = "btnAddNewCat";
            this.btnAddNewCat.Size = new System.Drawing.Size(144, 31);
            this.btnAddNewCat.TabIndex = 25;
            this.btnAddNewCat.Text = "Add new Category";
            this.btnAddNewCat.UseVisualStyleBackColor = true;
            // 
            // btnSaveTree
            // 
            this.btnSaveTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTree.Location = new System.Drawing.Point(1341, 105);
            this.btnSaveTree.Name = "btnSaveTree";
            this.btnSaveTree.Size = new System.Drawing.Size(126, 46);
            this.btnSaveTree.TabIndex = 24;
            this.btnSaveTree.Text = "Save Tree";
            this.btnSaveTree.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(961, 7);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(144, 31);
            this.btnRemove.TabIndex = 23;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnCollapse
            // 
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapse.Location = new System.Drawing.Point(1383, 24);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(84, 30);
            this.btnCollapse.TabIndex = 22;
            this.btnCollapse.Text = "Collapse All";
            this.btnCollapse.UseVisualStyleBackColor = true;
            // 
            // btnExpand
            // 
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand.Location = new System.Drawing.Point(1383, 60);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(84, 30);
            this.btnExpand.TabIndex = 21;
            this.btnExpand.Text = "Expand All";
            this.btnExpand.UseVisualStyleBackColor = true;
            // 
            // comboSubcontractor
            // 
            this.comboSubcontractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSubcontractor.FormattingEnabled = true;
            this.comboSubcontractor.Location = new System.Drawing.Point(11, 120);
            this.comboSubcontractor.Name = "comboSubcontractor";
            this.comboSubcontractor.Size = new System.Drawing.Size(416, 32);
            this.comboSubcontractor.Sorted = true;
            this.comboSubcontractor.TabIndex = 20;
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(452, 81);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(144, 31);
            this.btnFind.TabIndex = 19;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // comboProjects
            // 
            this.comboProjects.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProjects.ForeColor = System.Drawing.SystemColors.MenuText;
            this.comboProjects.FormattingEnabled = true;
            this.comboProjects.ItemHeight = 23;
            this.comboProjects.Location = new System.Drawing.Point(11, 44);
            this.comboProjects.Name = "comboProjects";
            this.comboProjects.Size = new System.Drawing.Size(416, 31);
            this.comboProjects.TabIndex = 18;
            // 
            // treeListView1
            // 
            this.treeListView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.treeListView1.AllColumns.Add(this.olvDesignation);
            this.treeListView1.AllColumns.Add(this.olvUnit);
            this.treeListView1.AllColumns.Add(this.olvUnitPrice);
            this.treeListView1.AllColumns.Add(this.olvQuantity);
            this.treeListView1.AllColumns.Add(this.olvTotal);
            this.treeListView1.AllColumns.Add(this.olvAssignedQuantity);
            this.treeListView1.AllColumns.Add(this.olvNegotiatedUnitPrice);
            this.treeListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.treeListView1.CellEditUseWholeCell = false;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvDesignation,
            this.olvUnit,
            this.olvUnitPrice,
            this.olvQuantity,
            this.olvTotal,
            this.olvAssignedQuantity,
            this.olvNegotiatedUnitPrice});
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.treeListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListView1.FullRowSelect = true;
            this.treeListView1.GridLines = true;
            this.treeListView1.HeaderUsesThemes = true;
            this.treeListView1.HideSelection = false;
            this.treeListView1.Location = new System.Drawing.Point(0, 180);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.RowHeight = 45;
            this.treeListView1.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.treeListView1.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(1479, 541);
            this.treeListView1.TabIndex = 17;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            // 
            // olvDesignation
            // 
            this.olvDesignation.AspectName = "Designation";
            this.olvDesignation.CellEditUseWholeCell = true;
            this.olvDesignation.CellVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.olvDesignation.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvDesignation.Text = "Designation";
            this.olvDesignation.Width = 650;
            // 
            // olvUnit
            // 
            this.olvUnit.AspectName = "Unit";
            this.olvUnit.CellEditUseWholeCell = true;
            this.olvUnit.CellVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.olvUnit.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvUnit.Text = "Unit";
            this.olvUnit.Width = 80;
            // 
            // olvUnitPrice
            // 
            this.olvUnitPrice.AspectName = "UnitPrice";
            this.olvUnitPrice.CellEditUseWholeCell = true;
            this.olvUnitPrice.Text = "Unit Price";
            this.olvUnitPrice.Width = 135;
            // 
            // olvQuantity
            // 
            this.olvQuantity.AspectName = "Quantity";
            this.olvQuantity.CellEditUseWholeCell = true;
            this.olvQuantity.Text = "Quantity";
            this.olvQuantity.Width = 130;
            // 
            // olvTotal
            // 
            this.olvTotal.AspectName = "Amount";
            this.olvTotal.Text = "Total";
            this.olvTotal.Width = 120;
            // 
            // olvAssignedQuantity
            // 
            this.olvAssignedQuantity.Text = "Assigned Quantity";
            this.olvAssignedQuantity.Width = 150;
            // 
            // olvNegotiatedUnitPrice
            // 
            this.olvNegotiatedUnitPrice.AspectName = "NegotiatedUnitPrice";
            this.olvNegotiatedUnitPrice.Text = "Negotiated Unit Price";
            this.olvNegotiatedUnitPrice.Width = 150;
            // 
            // frmAssignWorkToSubcontractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 721);
            this.Controls.Add(this.btnAddNewCat);
            this.Controls.Add(this.btnSaveTree);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCollapse);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.comboSubcontractor);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.comboProjects);
            this.Controls.Add(this.treeListView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAssignWorkToSubcontractor";
            this.Text = "frmAssignWorkToSubcontractor";
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewCat;
        private System.Windows.Forms.Button btnSaveTree;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.ComboBox comboSubcontractor;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox comboProjects;
        private BrightIdeasSoftware.TreeListView treeListView1;
        private BrightIdeasSoftware.OLVColumn olvDesignation;
        private BrightIdeasSoftware.OLVColumn olvUnit;
        private BrightIdeasSoftware.OLVColumn olvUnitPrice;
        private BrightIdeasSoftware.OLVColumn olvQuantity;
        private BrightIdeasSoftware.OLVColumn olvTotal;
        private BrightIdeasSoftware.OLVColumn olvAssignedQuantity;
        private BrightIdeasSoftware.OLVColumn olvNegotiatedUnitPrice;
    }
}