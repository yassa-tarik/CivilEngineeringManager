using CivilEngineeringManager.Helpers.Tree;
using CivilEngineeringManager.Mappers;
using CivilEngineeringManager.ViewModels;
using Composition;
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
        private readonly IProjectService _projectService;
        private readonly IWorkCategoryTreeService _workCategoryTreeService;
        public Form1( )
        {
            InitializeComponent();
            _projectService = ProjectBuilder.BuildProjectService();
            _workCategoryTreeService = ProjectBuilder.WorkCategoryTreeService();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var roots = await _workCategoryTreeService.GetWorkCategoryTreeAsync();
            treeListView1.Roots = roots.Select(r => WorkCategoryTreeMapper.FromWorkCategory(r));
            treeListView1.CanExpandGetter = ((x) => ((TreeNodeViewModel)(x)).canExpand);
            treeListView1.ChildrenGetter = ((x) => TreeViewConverters.MergeTypesAndSpecsLists((TreeNodeViewModel)x));
        }       
    }
}
