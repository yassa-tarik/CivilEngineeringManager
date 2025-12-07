using CivilEngineeringManager.Abstractions;
using CivilEngineeringManager.UI.Enums;
using MyApplication.Abstractions;
using System;
using System.Windows.Forms;

namespace CivilEngineeringManager.Forms
{
    public partial class frmSubcontractors : Form
    {
        private readonly IChildFormFactory _childFormFactory;

        private readonly ISubcontractorService _subcontractorService;
        public frmSubcontractors(ISubcontractorService subcontractorService, IChildFormFactory childFormFactory)
        {
            InitializeComponent();
            _subcontractorService = subcontractorService;
            _childFormFactory = childFormFactory;
        }

        private void btnAddNewSubcontractor_Click(object sender, EventArgs e)
        {
            _childFormFactory.CreateForm<frmAddEditViewSubcontractor>(FormMode.Add).ShowDialog();
        }

        private async void frmSubcontractors_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await _subcontractorService.GetAllAsync();
        }
    }
}
