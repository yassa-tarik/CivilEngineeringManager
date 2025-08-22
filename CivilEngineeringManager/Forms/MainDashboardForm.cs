using BLL.Interfaces;
using Composition;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CivilEngineeringManager.Forms
{
    public partial class MainDashboardForm : Form
    {
        private readonly ISubcontractorService _subcontractorService;
        private Panel projectPanel;
        private Panel CreateSectionPanel(string title, Point location, Size size)
        {
            var outerPanel = new Panel
            {
                Location = location,
                Size = size,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            var lbl = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
                Dock = DockStyle.Top
            };
            outerPanel.Controls.Add(lbl);

            // Content area
            var contentPanel = new Panel
            {
                Location = new Point(10, 35),
                Size = new Size(size.Width - 20, size.Height - 45),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = Color.White
            };

            outerPanel.Controls.Add(contentPanel);
            outerPanel.Tag = contentPanel; // Store reference for later

            return outerPanel;
        }

        public MainDashboardForm()
        {
            InitializeComponent();
            //DependencyBuilder.InitializeDB_Connection();
            _subcontractorService = DependencyBuilder.BuildSubcontractorService();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            // Task Progress Panel
            //var taskPanel = CreateSectionPanel("Task Progress", new Point(10, 370), new Size(950, 200));
            //taskPanel.Dock = DockStyle.Top;
            //mainPanel.Controls.Add(taskPanel);
            // Subcontractor Status Panel
            //var subStatusPanel = CreateSectionPanel("Subcontractor Status", new Point(10, 160), new Size(950, 200));
            //subStatusPanel.Dock = DockStyle.Top;
            //mainPanel.Controls.Add(subStatusPanel);
            // Project Overview Panel            
            var projectPanel = CreateSectionPanel("Project Overview", new Point(10, 0), new Size(950, 300));

            //var projectFlow = new Panel
            //{
            //    Location = new Point(10, 40),
            //    Size = new Size(900, 100),
            //    AutoScroll = true,         
            //};

            //foreach (var project in _projectService.GetAllProjects())
            //{
            var projects = await _subcontractorService.GetAllAsync();
            //var projects = await _projectService.GetAllMinimalProjectsAsync();
            //var card = new Panel
            //{
            //    Size = new Size(200, 80),
            //    BackColor = Color.LightSteelBlue,
            //    Margin = new Padding(10)
            //};

            //card.Controls.Add(new Label
            //{
            //    Text = project.Name,
            //    Font = new Font("Segoe UI", 10, FontStyle.Bold),
            //    Location = new Point(10, 10),
            //    AutoSize = true
            //});

            //card.Controls.Add(new Label
            //{
            //    Text = $"Status: {project.Status}",
            //    Location = new Point(10, 35),
            //    AutoSize = true
            //});

            //projectFlow.Controls.Add(card);

            //projectPanel.Controls.Add(projectFlow);
            DataGridView dataGridView = new DataGridView();
            dataGridView.Location = new System.Drawing.Point(200, 0);
            dataGridView.Name = "grid";
            dataGridView.Size = new System.Drawing.Size(984, 260);
            dataGridView.TabIndex = 5;
            dataGridView.DataSource = projects;
            mainPanel.Controls.Add(dataGridView);
            mainPanel.Controls["grid"].Dock = DockStyle.Bottom;
            //projectPanel.Controls.Add(projectFlow);
            //MessageBox.Show("Here");
            //****************************
            //projectPanel.Controls[1].Dock = DockStyle.Bottom;
            projectPanel.Dock = DockStyle.Top;
            mainPanel.Controls.Add(projectPanel);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var projectPanel = CreateSectionPanel("Project Overview", new Point(10, 0), new Size(950, 300));

            var subcontractors = await _subcontractorService.GetAllAsync();

            DataGridView dataGridView = new DataGridView();
            dataGridView.Location = new System.Drawing.Point(200, 0);
            dataGridView.Name = "grid";
            dataGridView.Size = new System.Drawing.Size(984, 260);
            dataGridView.TabIndex = 5;
            dataGridView.DataSource = subcontractors;
            mainPanel.Controls.Add(dataGridView);
            mainPanel.Controls["grid"].Dock = DockStyle.Bottom;

            projectPanel.Dock = DockStyle.Top;
            mainPanel.Controls.Add(projectPanel);
        }
    }
}
