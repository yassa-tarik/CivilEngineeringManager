using CivilEngineeringManager.Abstractions;
using System;
using System.Windows.Forms;

namespace CivilEngineeringManager.Forms
{
    public partial class frmMain : Form
    {
        private readonly IChildFormFactory _childFormFactory;

        public frmMain(IChildFormFactory childFormFactory)
        {
            InitializeComponent();
            _childFormFactory = childFormFactory;
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            ChildForms(_childFormFactory.CreateForm<AddEditProjectSpecifications>());
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            ChildForms(_childFormFactory.CreateForm<frmProjects>()) ;
        }

        void ChildForms(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
