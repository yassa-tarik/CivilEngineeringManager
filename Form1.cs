using CivilEngineeringManager.Helpers.Tree;
using CivilEngineeringManager.Mappers;
using CivilEngineeringManager.ViewModels;
using Composition;
using DTO.TreeDTOs;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Works;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CivilEngineeringManager
{
    public partial class Form1 : Form
    {        
        ProjectBuilder _projectBuilder;
        private readonly IProjectService _projectService;
        private readonly IProjectTreeService _projectTreeService;
        public Form1( )
        {
            InitializeComponent();
            _projectBuilder = new ProjectBuilder();
            _projectService = _projectBuilder.BuildProjectService();
            _projectTreeService = _projectBuilder.ProjectTreeService();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //var roots = await _workCategoryTreeService.GetWorkCategoryTreeAsync();
            var roots = await _projectTreeService.GetProjectTreeAsync(1);
            treeListView1.Roots = roots.WorkCategories.Select(r => WorkCategoryTreeMapper.FromWorkCategory(r));
            //treeListView1.CanExpandGetter = ((x) => ((ProjectTreeDTO)(x)).WorkCategories.Count > 0);
            treeListView1.CanExpandGetter = ((x) => ((TreeNodeViewModel)(x)).canExpand);
            treeListView1.ChildrenGetter = ((x) => TreeViewConverters.MergeTypesAndSpecsLists((TreeNodeViewModel)x));

            treeListView1.ExpandAll();
        }       
    }
}
