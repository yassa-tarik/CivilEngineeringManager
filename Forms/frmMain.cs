using CivilEngineeringManager.Abstractions;
using System;
using System.Windows.Forms;

namespace CivilEngineeringManager.Forms
{
    public partial class frmMain : Form
    {
        private readonly IChildFormFactory _childFormFactory;
        Form currentForm;

        public frmMain(IChildFormFactory childFormFactory)
        {
            InitializeComponent();
            _childFormFactory = childFormFactory;
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            ChildForms(_childFormFactory.CreateForm<AddEditProjectSpecifications>(), sender);
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            ChildForms(_childFormFactory.CreateForm<frmProjects>(), sender);
        }

        void ChildForms(Form childForm, object sender)
        {
            if (currentForm != null)
                currentForm.Close();
            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            var button = sender as Button;
            lblTitle.Text = button.Text;
            this.panelMain.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnSubcontractors_Click(object sender, EventArgs e)
        {
            ChildForms(_childFormFactory.CreateForm<frmSubcontractors>(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ChildForms(_childFormFactory.CreateForm<frmAssignWorkToSubcontractor>(), sender);
        }
    }
}
