using Common.Enums;
using Composition;
using DTO.TreeDTOs;
using DTO.Works.WorkSpecs;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Trees;
using MyApplication.Abstractions.Works;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CivilEngineeringManager.TestProjects
{
    public partial class FormTreeWithDTOs : Form
    {
        ProjectBuilder _projectBuilder;
        private readonly IProjectService _projectService;
        private readonly IProjectWorkSpecsTreeService _projectTreeService;
        public FormTreeWithDTOs()
        {
            InitializeComponent();
            _projectBuilder = new ProjectBuilder();
            //_projectService = _projectBuilder.BuildProjectService();
            //_projectTreeService = _projectBuilder.ProjectTreeService();
        }

        private async void TreeWithDTOs_Load(object sender, EventArgs e)
        {
            treeListView1.UseNotifyPropertyChanged = true;
            SetupColumnsMappingPutter();
            var roots = await _projectTreeService.GetProjectTreeForSpecificationsAsync(2);
            treeListView1.Roots = roots.WorkCategories;
            /*olvColumn1.AspectGetter = a =>
            {
                if (a is WorkCategoryTreeDTO categoryTreeDTO)
                {
                    return categoryTreeDTO.Name;
                }
                else if (a is WorkTypeTreeDTO typeTreeDTO)
                {
                    return typeTreeDTO.Designation;
                }
                else if (a is WorkSpecDTO specDTO)
                {
                    return specDTO.Designation;
                }
                else { return null; }
            };*/

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
            //treeListView1.ExpandAll();

        }

        private void btnSendTree_Click(object sender, EventArgs e)
        {
            var root = treeListView1.Roots;
            var rt = root.Cast<WorkCategoryTreeDTO>();
            AddSpecifications addSpecifications = new AddSpecifications(rt);
            addSpecifications.ShowDialog();
        }

        private void AddChildToSelectedParent()
        {
            var selectedParent = treeListView1.SelectedObject as WorkCategoryTreeDTO;
            if (selectedParent == null)
            {
                MessageBox.Show("Please select a parent node first.");
                return;
            }
            var newChild = new WorkSpecDTO(-1, selectedParent.ID, null, "new Spec", "m", 120, 20, "9%", AssignedWorkStatus.NotAssigned);
            // Add to parent's children collection
            //selectedParent.WorkSpecs.Add(newChild);
            // Refresh the tree view
            treeListView1.RefreshObject(selectedParent);

            // Optionally: Start editing the new row
            treeListView1.EditModel(treeListView1.GetModelObject(1));

            // treeListView2.EditModel(treeListView2.GetModelObject(treeListView2.SelectedIndex+1));
            treeListView1.Expand(selectedParent);
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChildToSelectedParent();
            treeListView1.Expand(treeListView1.SelectedObject);
        }

        void SetupColumnsMappingPutter()
        {
            olvColumn1.AspectPutter = (rowObject, newValue) =>
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
            olvColumn3.AspectPutter = (rowObject3, newValue3) =>
            {
                if (rowObject3 is WorkSpecDTO spec)
                {
                    spec.Unit = newValue3?.ToString();
                }
            };
            olvColumn4.AspectPutter = (rowObject4, newValue4) =>
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
    }
}
