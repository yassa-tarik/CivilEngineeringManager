using CivilEngineeringManager.Abstractions;
using CivilEngineeringManager.Controls;
using CivilEngineeringManager.UI.Enums;
using MyApplication.Abstractions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CivilEngineeringManager.Forms
{
    public partial class frmProjects : Form
    {
        private readonly IProjectService _projectService;
        private readonly IChildFormFactory _childFormFactory;
        public frmProjects(IProjectService projectService, IChildFormFactory childFormFactory)
        {
            InitializeComponent();
            _projectService = projectService;
            _childFormFactory = childFormFactory;
        }

        private async void LoadProjectCards()
        {
            // Clear existing cards
            flowLayoutPanelProjects.Controls.Clear();

            var projects = await _projectService.GetAllMinAsync();
            //var projects = GetProjectData();

            foreach (var project in projects)
            {
                ctrlProjectCard card = new ctrlProjectCard();
                card.ProjectId = project.ID;
                card.ProjectName = project.Name;
                card.ProjectProgress = project.Progress;
                card.ProjectType = project.ProjectType;
                card.Width = 302; // Set a fixed width for your cards
                card.Height = 274; // Set a fixed height
                card.Margin = new Padding(10); // Add some spacing between cards
                card.Cursor = Cursors.Hand; // Make it look clickable

                // Subscribe to the custom click event
                card.CardClick += (sender, e) =>
                {
                    ctrlProjectCard clickedCard = sender as ctrlProjectCard;
                    if (clickedCard != null)
                    {
                        _childFormFactory.CreateForm<frmAddEditReadProject>(FormMode.Read, clickedCard.ProjectId).ShowDialog();
                        //MessageBox.Show($"Project {clickedCard.ProjectName} (ID: {clickedCard.ProjectId}) clicked!");
                        //Here you would open your "Détails du Projet" modal, passing the project ID
                        //OpenProjectDetails(int.Parse(clickedCard.ProjectId));
                    }
                };
                card.EditClick += (sender, e) => OpenAddEditReadFormForEdit(sender, e);

                flowLayoutPanelProjects.Controls.Add(card);
            }
        }

        private void frmProjects_Load(object sender, System.EventArgs e)
        {
            LoadProjectCards();
        }

        // event used for Edit project
        private void OpenAddEditReadFormForEdit(object sender, EventArgs e)
        {
            ctrlProjectCard projectCard = sender as ctrlProjectCard;
            if (projectCard != null)
            {
                _childFormFactory.CreateForm<frmAddEditReadProject>(FormMode.Edit, projectCard.ProjectId).ShowDialog();
            }
            frmProjects_Load(null, null);
        }

        private void btnAddNewProject_Click(object sender, System.EventArgs e)
        {
            _childFormFactory.CreateForm<frmAddEditReadProject>(FormMode.Add).ShowDialog();
        }

        //*********************************** Mock data **********************************
        // Placeholder for your ProjectData structure
        public class ProjectData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Progress { get; set; }
        }
        private List<ProjectData> GetProjectData()
        {
            // Example data
            return new List<ProjectData>
        {
            new ProjectData { Id = 1, Name = "El Bordj", Progress = 75 },
            new ProjectData { Id = 2, Name = "Etoile 22", Progress = 30 },
            new ProjectData { Id = 3, Name = "Form", Progress = 90 },
            new ProjectData { Id = 4, Name = "MAKOUDA", Progress = 10 },
            new ProjectData { Id = 5, Name = "NEDJMA", Progress = 55 },
            new ProjectData { Id = 6, Name = "Triangle003", Progress = 80 }
        };
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            txtSearch.Text = string.Empty;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //txtSearch.ForeColor = System.Drawing.Color.Black;
            //if (txtSearch.Text == string.Empty)
            //{
            //    txtSearch.ForeColor = System.Drawing.Color.LightGray;
            //    //txtSearch.Text = "search for project";
            //}
        }
    }
}
