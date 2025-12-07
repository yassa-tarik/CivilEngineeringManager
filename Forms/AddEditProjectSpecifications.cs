using BrightIdeasSoftware;
using Composition;
using DTO.TreeDTOs;
using DTO.Works.WorkCategoryDesignations;
using DTO.Works.WorkSpecs;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Trees;
using MyApplication.Abstractions.Works;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CivilEngineeringManager.Forms
{
    public partial class AddEditProjectSpecifications : Form
    {
        private readonly IProjectService _projectService;
        private readonly IProjectWorkSpecsTreeService _projectTreeService;
        private readonly IWorkCategoryDesignationService _workCategoryDesignationService;

        int categoryIDs = -10;
        int typeIDs = -10;
        int specIDs = -10;

        //bool flagContextMenuStrip = false;
        private ProjectTreeDTO _projectTreeDTO;
        private Dictionary<int, WorkCategoryDesignationUpdateDTO> _allCategoriesDesignation;

        public AddEditProjectSpecifications(IProjectService projectService, IProjectWorkSpecsTreeService projectTreeService, IWorkCategoryDesignationService workCategoryDesignationService)
        {
            InitializeComponent();
            _projectService = projectService;
            _projectTreeService = projectTreeService;
            _workCategoryDesignationService = workCategoryDesignationService;
        }

        private async void AddEditProjectSpecifications_Load(object sender, EventArgs e)
        {
            try
            {
                Task<Dictionary<int, WorkCategoryDesignationUpdateDTO>> categoriesTask = Task.Run(() => _workCategoryDesignationService.GetAllAsync());

                btnFind.Enabled = false;
                //_categories = await _workCategoryDesignationService.GetAllAsync();

                comboCategories.Enabled = false;
                btnAddNewCat.Enabled = false;
                //comboProjects.DataSource = _projectService.GetMockProjects();
                comboProjects.DataSource = await _projectService.GetAllMinAsync();
                comboProjects.DisplayMember = "Name";
                comboProjects.ValueMember = "ID";
                _allCategoriesDesignation = await categoriesTask;

                // test empty data
                //_projectTreeDTO = await _projectTreeService.GetProjectTreeAsync(0);
            }
            catch (Exception ex)
            {
                //TODO: Will check the exception type later
                _projectTreeDTO = new ProjectTreeDTO();
                //MessageBox.Show("Unable to load projects specifications!", ex.Message);
            }
        }

        private void comboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = comboProjects.Items.Count > 0;
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            //flagContextMenuStrip = true;

            _projectTreeDTO = await _projectTreeService.GetProjectTreeForSpecificationsAsync((int)comboProjects.SelectedValue);

            _allCategoriesDesignation = await _workCategoryDesignationService.GetAllAsync();

            comboBoxCategoriesDesignationDataSource(_allCategoriesDesignation);

            treeListView1.Roots = null;
            LoadTheTreeView();
            treeListView1.ExpandAll();
            btnFind.Enabled = false;
            btnSaveTree.Enabled = true;
        }

        void LoadCategories()
        {
            //_categories = _projectBuilder.ProjectTreeService();
        }

        private void LoadTheTreeView()
        {
            /*
            //treeListView1.Columns.Add(new OLVColumn
            //{
            //    Text = "Status",
            //    AspectName = "Status", // This will get the enum value
            //    AspectToStringConverter = value =>
            //    {
            //        if (value is AssignedWorkStatus status)
            //        {
            //            return EnumToStringConverter.AssignedWorkStatusToString(status);
            //        }
            //        return value?.ToString() ?? string.Empty;
            //    },
            //    Width = 120
            //});
            */

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
                    return null/*new List<object>()*/;
                }
                return null;
            };
        }

        //this method used to edit model cells(properties)
        void SetupColumnsMappingPutter()
        {
            olvDesignation.AspectPutter = (rowObject, newValue) =>
            {
                if (rowObject is WorkCategoryTreeDTO cat)
                {
                    //newValue = ((WorkCategoryDesignationUpdateDTO)comboCategories.SelectedItem).Designation;
                    //cat.Designation = newValue?.ToString() ;
                }
                else if (rowObject is WorkTypeTreeDTO type)
                {
                    type.Designation = newValue?.ToString();
                }
                else if (rowObject is WorkSpecUpdateDTO spec)
                {
                    spec.Designation = newValue?.ToString();
                }
            };
            olvUnit.AspectPutter = (rowObject3, newValue3) =>
            {
                if (rowObject3 is WorkSpecUpdateDTO spec)
                {
                    spec.Unit = newValue3?.ToString();
                }
            };
            olvUnitPrice.AspectPutter = (rowObject4, newValue4) =>
            {
                if (rowObject4 is WorkSpecUpdateDTO spec)
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
                var newChild = new WorkCategoryTreeDTO
                {
                    ID = categoryIDs,
                    Project_ID = Convert.ToInt32(comboProjects.SelectedValue),
                    WorkCategoryDesignation_ID = ((WorkCategoryDesignationUpdateDTO)comboCategories.SelectedItem).ID, //TODO: use tryparse()
                    Designation = ((WorkCategoryDesignationUpdateDTO)comboCategories.SelectedItem).Designation
                };
                //remove the categortDesignation from the list
                _allCategoriesDesignation.Remove(newChild.WorkCategoryDesignation_ID);

                comboBoxCategoriesDesignationDataSource(_allCategoriesDesignation);

                // Add to parent's children collection
                _projectTreeDTO.WorkCategories.Add(newChild);
                categoryIDs--;

                LoadTheTreeView();
                treeListView1.Expand(_projectTreeDTO.WorkCategories);
                treeListView1.SelectedObject = newChild;
            }
            else
            {
                return;
            }
            return;
        }

        void comboBoxCategoriesDesignationDataSource(Dictionary<int, WorkCategoryDesignationUpdateDTO> allCategoriesDesignation)
        {
            // select WorkCategoryDesignation_ID only
            HashSet<int> excludedSet = new HashSet<int>(_projectTreeDTO.WorkCategories.Select((c) => c.WorkCategoryDesignation_ID).ToList());

            // remove existing WorkCategoryDesignation_IDs from main list (_categories)
            _allCategoriesDesignation = _allCategoriesDesignation.Where((wc => !excludedSet.Contains(wc.Key))).ToDictionary(kv => kv.Key, kv => kv.Value);
            var list = _allCategoriesDesignation.Select(wc => wc.Value).ToList();
            BindingList<WorkCategoryDesignationUpdateDTO> bindingList = new BindingList<WorkCategoryDesignationUpdateDTO>(list);
            //bindingList.Remove((WorkCategoryDesignationUpdateDTO)comboCategories.SelectedItem);
            comboCategories.DataSource = bindingList;
            comboCategories.DisplayMember = "Designation";
            comboCategories.ValueMember = "ID";
            comboCategories.Enabled = comboProjects.SelectedIndex > -1;
        }

        private void AddNewWorkSpecRowModel()
        {
            var selectedParent = treeListView1.SelectedObject;

            if (selectedParent is WorkCategoryTreeDTO workCategory)
            {
                var newChild = new WorkSpecUpdateDTO(specIDs, workCategory.ID, null, "Enter New Specification", "unit", 00, 00, "vat", false);
                // Add to parent's children collection
                workCategory.WorkSpecs.Add(newChild);
                specIDs--;
                // Refresh the tree view
                //treeListView1.RefreshObject(workCategory);
                treeListView1.UpdateObject(workCategory);
                treeListView1.Expand(selectedParent);
                treeListView1.SelectedObject = newChild;
            }
            else if (selectedParent is WorkTypeTreeDTO workType)
            {
                var newChild = new WorkSpecUpdateDTO(typeIDs, null, workType.ID, "Enter New Specification", "unit", 00, 00, "vat", false);
                // Add to parent's children collection
                workType.WorkSpecs.Add(newChild);
                typeIDs--;
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

        // TODO: will handle its logic details later
        private void ContextMenuItemsEnableDisable()
        {
            contextMenuStrip1.Enabled = true;
            foreach (ToolStripItem item in contextMenuStrip1.Items)
            {
                item.Enabled = true;
            }
            var selectedParent = treeListView1.SelectedObject;
            if (comboCategories.Items.Count <= 0)
            {
                contextMenuStrip1.Items[0].Enabled = false;
            }
            switch (selectedParent)
            {
                case WorkCategoryTreeDTO workCategory:
                    contextMenuStrip1.Items[0].Enabled = false;
                    break;

                case WorkTypeTreeDTO workType:
                    contextMenuStrip1.Items[0].Enabled = false;
                    break;
                case WorkSpecUpdateDTO workSpec:
                    contextMenuStrip1.Enabled = false;
                    break;
                case null:
                    //MessageBox.Show("hello");
                    contextMenuStrip1.Items[1].Enabled = false;
                    contextMenuStrip1.Items[2].Enabled = false;
                    break;
            }
            /*
            if (selectedParent is WorkCategoryTreeDTO  || selectedParent is WorkTypeTreeDTO )
            {
                contextMenuStrip1.Items[0].Enabled = false;
            }
            else if (selectedParent is WorkSpecUpdateDTO )
            {
                contextMenuStrip1.Enabled = false;
            }
            else if (selectedParent == null)
            {
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
            }
            */
        }

        private void treeListView1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    var hitTest = treeListView1.HitTest(e.X, e.Y);
            //    if (hitTest.Item != null)
            //    {
            //        ContextMenuItemsEnableDisable();
            //        //treeListView1.SelectedObject = hitTest.Item[];
            //        //contextMenuStrip1.Show(treeListView1, e.Location);
            //    }
            //}
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            //contextMenuStrip1.Enabled = flagContextMenuStrip ? true : false;
            contextMenuStrip1.Items[0].Enabled = comboCategories.Items.Count > 0;
            ContextMenuItemsEnableDisable();
        }

        private void treeListView1_CellEditFinished(object sender, CellEditEventArgs e)
        {
            //_projectTreeDTO.WorkCategories = treeListView1.Roots.Cast<WorkCategoryTreeDTO>().ToList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            treeListView1.RemoveObject(treeListView1.SelectedObject);
            treeListView1.Refresh();
        }

        private async void btnSaveTree_Click(object sender, EventArgs e)
        {
            try
            {
                if (await _projectTreeService.SaveProjectTree(_projectTreeDTO))
                {
                    MessageBox.Show("Tree saved successfully :)", "save Tree");
                }
                else
                {
                    MessageBox.Show("Tree Not saved!", "save Tree");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("not saved!!!!" + ex.Message);
                //throw;
            }
            btnSaveTree.Enabled = false;
        }

        private void btnAddNewCat_Click(object sender, EventArgs e)
        {
            //TODO: for testing purposes
            WorkCategoryDesignationBuilder builder = new WorkCategoryDesignationBuilder();
            IWorkCategoryDesignationService service = builder.BuildService();
            frmAddNewCategoryDesignation frm = new frmAddNewCategoryDesignation(service);
            frm.ShowDialog();

            btnFind_Click(null, null); // to refresh the categories List after adding
        }

        private void comboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddNewCat.Enabled = comboCategories.SelectedIndex > -1;
        }

        private void treeListView1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    var hitTest = treeListView1.HitTest(e.X, e.Y);
            //    //if (hitTest.Item != null)
            //    //{
            //        ContextMenuItemsEnableDisable();
            //        //treeListView1.SelectedObject = hitTest.Item[];
            //        contextMenuStrip1.Show(treeListView1, e.Location);

            //}
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewWorkSpecRowModel();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: implement WorkSpec seletion 
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
