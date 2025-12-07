using BrightIdeasSoftware;
using CivilEngineeringManager.ViewModels;
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

namespace CivilEngineeringManager
{
    public partial class AddSpecifications : Form
    {
        int nextId = 1;  // for simple ID generation
        ProjectBuilder _projectBuilder;
        private readonly IProjectService _projectService;
        private readonly IProjectWorkSpecsTreeService _projectTreeService;

        IEnumerable<WorkCategoryTreeDTO> _treeDTO;
        public AddSpecifications(IEnumerable<WorkCategoryTreeDTO> treeDTO)
        {
            InitializeComponent();
            _projectBuilder = new ProjectBuilder();
            //_projectService = _projectBuilder.BuildProjectService();
            //_projectTreeService = _projectBuilder.ProjectTreeService();
            _treeDTO = treeDTO;
        }
        private async void AddSpecifications_Load(object sender, EventArgs e)
        {
            //var roots = await _projectTreeService.GetProjectTreeAsync(1);
            //treeListView1.Roots = new List<TreeNodeViewModel>();
            //treeListView1.CanExpandGetter = x => true;
            //treeListView1.ChildrenGetter = x => ((TreeNodeViewModel)x).WorkTypes; 
            //comboBox1.DataSource = _projectService.GetMockProjects();
            //comboBox1.DisplayMember = "Name";
            //comboBox1.ValueMember = "ID";
            //**************************** test ****************************
            var list = _treeDTO.ElementAt(0).WorkTypes.ElementAt(0).Designation;
            MessageBox.Show(list);
            treeListView1.Roots = _treeDTO;
            // get Name property instead of Designation of (WorkCategoryTreeDTO)

            /*
             olvColumn2.AspectGetter = a =>
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
            }; */

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

            treeListView1.ExpandAll();
            //**************************************************************
        }
        void Fun()
        {
            ObjectListView objectListView = new ObjectListView();
            //objectListView.Edi
            TreeNodeViewModel work = new TreeNodeViewModel(nextId, null, "m2", 100, 150, 500, new List<WorkTypeTreeDTO>(), new List<WorkSpecUpdateDTO>());
            var child = new WorkTypeTreeDTO { ID = -10, WorkCategory_ID = 5, Parent_ID = null };
            child.Designation = "hello";
            work.WorkTypes.Add(child);
            var roots = treeListView1.Roots.Cast<TreeNodeViewModel>().ToList();
            roots.Add(work);
            treeListView1.Roots = roots;
            treeListView1.RefreshObject(work);
            treeListView1.EnsureModelVisible(work);
            //treeListView1.StartCellEdit(treeListView1.OverlayText, 0); // begin editing designation            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Fun();
            nextId++;
        }

        private void treeListView1_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (treeListView1.SelectedObject == null)
            {

                contextMenuStrip1.Items[1].Enabled = false;
                return;
            }
            {
                if (treeListView1.Roots.Cast<TreeNodeViewModel>().Count() <= 0)
                {
                    contextMenuStrip1.Items[1].Enabled = false;
                    contextMenuStrip1.Items[2].Enabled = false;
                    return;
                }
                //contextMenuStrip1.Enabled = false;
                //return;
            }
            contextMenuStrip1.Enabled = true;
            if (((TreeNodeViewModel)treeListView1.SelectedObject).ID > 0)
                contextMenuStrip1.Items[1].Enabled = false;
            contextMenuStrip1.Items[2].Enabled = false;
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = ((TreeNodeViewModel)treeListView1.SelectedObject).ID;
            var designation = comboBox2.SelectedItem.ToString();
            TreeNodeViewModel work = new TreeNodeViewModel(id, designation, null, null, null, null, new List<WorkTypeTreeDTO>(), new List<WorkSpecUpdateDTO>());
            //((TreeNodeViewModel)treeListView1.SelectedObject).WorkTypes.Add(((TreeNodeViewModel)treeListView1.SelectedObject));
            var roots = treeListView1.Roots.Cast<TreeNodeViewModel>().ToList();

            roots.Add(work);
            treeListView1.Roots = roots;
        }
    }
}