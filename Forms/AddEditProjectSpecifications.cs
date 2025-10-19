using BrightIdeasSoftware;
using Composition;
using DTO.TreeDTOs;
using DTO.Works.WorkSpecs;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Works;
using MyApplication.Services.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CivilEngineeringManager.Forms
{
    public partial class AddEditProjectSpecifications : Form
    {
        bool flagContextMenuStrip = false;
        private ProjectTreeDTO _projectTreeDTO;
        ProjectBuilder _projectBuilder;
        private readonly IProjectService _projectService;
        private readonly IProjectTreeService _projectTreeService;
        public AddEditProjectSpecifications()
        {
            InitializeComponent();
            _projectBuilder = new ProjectBuilder();
            _projectService = _projectBuilder.BuildProjectService();
            _projectTreeService = _projectBuilder.ProjectTreeService();
        }

        private async void AddEditProjectSpecifications_Load(object sender, EventArgs e)
        {
            try
            {
                btnFind.Enabled = false;
                comboBox1.DataSource = _projectService.GetMockProjects();
                //comboBox1.DataSource = await _projectService.GetAllMinAsync();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";

                _projectTreeDTO = await _projectTreeService.GetProjectTreeAsync((int)comboBox1.SelectedValue);
                // test empty data
                //_projectTreeDTO = await _projectTreeService.GetProjectTreeAsync(0);
            }
            catch (Exception)
            {
                _projectTreeDTO = new ProjectTreeDTO();
                MessageBox.Show("Unable to load projects specifications!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = comboBox1.SelectedIndex > -1;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            flagContextMenuStrip = true;
            treeListView1.Roots = null;
            LoadTheTreeView();
            treeListView1.ExpandAll();
        }

        private void LoadTheTreeView()
        {
            SetupColumnsMappingPutter();

            treeListView1.Roots = _projectTreeDTO.WorkCategories;
            treeListView1.CanExpandGetter = (x) =>
            {
                if (x is WorkCategoryTreeDTO category)
                {
                    return category.WorkTypes.Count > 0 || category.WorkSpecs.Count > 0;
                }
                if (x is WorkTypeTreeDTO type)
                {
                    return type.WorkTypes.Count > 0 || type.WorkSpecs.Count > 0;
                }
                return false;
            };
            treeListView1.ChildrenGetter = (x) =>
            {
                if (x is WorkCategoryTreeDTO categoryParent)
                {
                    var children = new List<object>();
                    if (categoryParent.WorkTypes != null)
                    {
                        children.AddRange(categoryParent.WorkTypes);
                    }
                    if (categoryParent.WorkSpecs != null)
                    {
                        children.AddRange(categoryParent.WorkSpecs);
                    }
                    return children;
                }

                if (x is WorkTypeTreeDTO typeParent)
                {
                    var children = new List<object>();
                    if (typeParent.WorkTypes != null)
                    {
                        children.AddRange(typeParent.WorkTypes);
                    }
                    if (typeParent.WorkSpecs != null)
                    {
                        children.AddRange(typeParent.WorkSpecs);
                    }
                    return children;
                }
                if (x is WorkSpecDTO)
                {
                    return new List<object>();
                }
                return null;
            };
        }

        //this method used to edit model cells(properties)
        void SetupColumnsMappingPutter()
        {
            olvDesignation.AspectPutter = (rowObject, newValue) =>
            {
                if (rowObject is WorkCategoryTreeDTO obj)
                {
                    obj.Designation = newValue?.ToString();
                }
                else if (rowObject is WorkTypeTreeDTO type)
                {
                    type.Designation = newValue?.ToString();
                }
                else if (rowObject is WorkSpecDTO spec)
                {
                    spec.Designation = newValue?.ToString();
                }
            };
            olvUnit.AspectPutter = (rowObject3, newValue3) =>
            {
                if (rowObject3 is WorkSpecDTO spec)
                {
                    spec.Unit = newValue3?.ToString();
                }
            };
            olvUnitPrice.AspectPutter = (rowObject4, newValue4) =>
            {
                if (rowObject4 is WorkSpecDTO spec)
                {
                    decimal newDecimalValue = spec.UnitPrice; // Keep old value as fallback

                    if (newValue4 != null)
                    {
                        if (newValue4 is decimal d)
                        {
                            newDecimalValue = d;
                        }
                        else if (decimal.TryParse(newValue4.ToString(), out decimal parsedValue))
                        {
                            newDecimalValue = parsedValue;
                        }
                        // Add any business logic validation here
                        if (newDecimalValue >= 0) // Example: prevent negative prices
                        {
                            spec.UnitPrice = newDecimalValue;
                        }
                    }
                }
            };
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Add the appropriate code to add WorkCategory
            AddNewWorkCategoryRowModel();
        }

        private void AddNewWorkCategoryRowModel()
        {
            var selectedParent = treeListView1.SelectedObject;
            if (selectedParent == null)
            {
                var newChild = new WorkCategoryTreeDTO { ID = -10, Designation = "New WorkCategory" };
                // Add to parent's children collection
                _projectTreeDTO.WorkCategories.Add(newChild);

                LoadTheTreeView();
                treeListView1.Expand(_projectTreeDTO.WorkCategories);
                treeListView1.SelectedObject = newChild;
            }
            else
            {
                return;
            }
            //if (selectedParent is WorkCategoryTreeDTO workCategory)
            //{
            //    return;
            //}
            //else if (selectedParent is WorkTypeTreeDTO workType)
            //{
            //    return;
            //}

        }

        private void specToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewWorkSpecRowModel();
        }

        private void AddNewWorkSpecRowModel()
        {
            var selectedParent = treeListView1.SelectedObject;

            if (selectedParent is WorkCategoryTreeDTO workCategory)
            {
                var newChild = new WorkSpecDTO(-1, workCategory.ID, null, "Enter New Specification", "unit", 00, 00, "vat");
                // Add to parent's children collection
                //workCategory.WorkSpecs.Add(newChild);
                // Refresh the tree view
                treeListView1.RefreshObject(workCategory);
                treeListView1.Expand(selectedParent);
                treeListView1.SelectedObject = newChild;
            }
            else if (selectedParent is WorkTypeTreeDTO workType)
            {
                var newChild = new WorkSpecDTO(-1, null, workType.ID, "Enter New Specification", "unit", 00, 00, "vat");
                // Add to parent's children collection
                //workType.WorkSpecs.Add(newChild);
                // Refresh the tree view
                treeListView1.RefreshObject(workType);
                treeListView1.Expand(selectedParent);
                treeListView1.SelectedObject = newChild;
            }
            else
            {
                // Handle case where selected object is neither type
                MessageBox.Show("Please select a valid parent node (Work Category or Work Type)");
                return;
            }
        }

        private void AddNewWorkTypeRowModel()
        {
            var selectedParent = treeListView1.SelectedObject;

            if (selectedParent is WorkCategoryTreeDTO workCategory)
            {
                var newChild = new WorkTypeTreeDTO { ID = -10, WorkCategory_ID = workCategory.ID, Parent_ID = null, Designation = "New WorkType" };
                // Add to parent's children collection
                workCategory.WorkTypes.Add(newChild);
                // Refresh the tree view
                treeListView1.RefreshObject(workCategory);
                treeListView1.Expand(workCategory);
                treeListView1.SelectedObject = newChild;
            }
            else if (selectedParent is WorkTypeTreeDTO workType)
            {
                var newChild = new WorkTypeTreeDTO { ID = -10, WorkCategory_ID = null, Parent_ID = workType.ID, Designation = "New WorkType" };
                // Add to parent's children collection
                workType.WorkTypes.Add(newChild);
                // Refresh the tree view
                treeListView1.RefreshObject(workType);
                treeListView1.Expand(selectedParent);
                treeListView1.SelectedObject = newChild;
            }
            else
            {
                // Handle case where selected object is neither type
                MessageBox.Show("Please select a valid parent node (Work Category or Work Type)");
                return;
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            treeListView1.ExpandAll();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            treeListView1.CollapseAll();
        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewWorkTypeRowModel();
        }

        private void ContextMenuItemsEnableDisable()
        {
            contextMenuStrip1.Enabled = true;
            var selectedParent = treeListView1.SelectedObject;

            switch (selectedParent)
            {
                case WorkCategoryTreeDTO workCategory:
                    contextMenuStrip1.Items[0].Enabled = false;
                    break;

                case WorkTypeTreeDTO workType:
                    contextMenuStrip1.Items[0].Enabled = false;
                    break;
                case WorkSpecDTO workSpec:
                    contextMenuStrip1.Enabled = false;
                    break;
                case null:
                    MessageBox.Show("hello");
                    contextMenuStrip1.Items[1].Enabled = false;
                    contextMenuStrip1.Items[2].Enabled = false;
                    break;

                default:
                    //MessageBox.Show("hello");
                    break;
            }
        }

        private void treeListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = treeListView1.HitTest(e.X, e.Y);
                if (hitTest.Item != null)
                {
                    ContextMenuItemsEnableDisable();
                    //treeListView.SelectedObject = hitTest.Item.RowObject;
                    //contextMenuStrip1.Show(treeListView, e.Location);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Enabled = flagContextMenuStrip ? true : false;
        }

        private void treeListView1_CellEditFinished(object sender, CellEditEventArgs e)
        {
            _projectTreeDTO.WorkCategories = treeListView1.Roots.Cast<WorkCategoryTreeDTO>().ToList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            treeListView1.RemoveObject(treeListView1.SelectedObject);
            treeListView1.Refresh();
        }

        private void btnSaveTree_Click(object sender, EventArgs e)
        {
            _projectTreeService.SaveProjectTree(_projectTreeDTO);
        }

        private void btnAddNewCat_Click(object sender, EventArgs e)
        {
            ////for testing purposes
            //WorkCategoryDesignationRepository
            //IWorkCategoryDesignationService repo = new WorkCategoryDesignationService WorkCategoryDesignation
            //frmAddNewCategoryDesignation frm = new frmAddNewCategoryDesignation();
            //frm.ShowDialog();
        }
    }
}
