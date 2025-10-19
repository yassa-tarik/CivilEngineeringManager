using DTO.Works.WorkCategories;
using DTO.Works.WorkCategoryDesignations;
using MyApplication.Abstractions.Works;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CivilEngineeringManager.Forms
{
    public partial class frmAddNewCategoryDesignation : Form
    {
        private readonly IWorkCategoryDesignationService _workCategoryDesignationService;
        private WorkCategoryDesignationCreateDTO workCategoryDesignCreateDTO;
        public frmAddNewCategoryDesignation(IWorkCategoryDesignationService workCategoryDesignationService)
        {
            InitializeComponent();
            _workCategoryDesignationService = workCategoryDesignationService;
        }

        private async void btnAddNewCatDesign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCatDesign.Text.Trim()))
            {
                MessageBox.Show("Veuillez entre un nom valide!", "Ajout nom");
                return;
            }
            workCategoryDesignCreateDTO = new WorkCategoryDesignationCreateDTO(txtCatDesign.Text);
            if (_workCategoryDesignationService.isExistsByName(txtCatDesign.Text))
            {
                MessageBox.Show("Ce nom est très similaire à un nom existant. Veuillez reverifier!", "Ajout nom", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (await _workCategoryDesignationService.AddAsync(workCategoryDesignCreateDTO) > 0)
            {
                MessageBox.Show($"Category {workCategoryDesignCreateDTO.Designation} sauvegarder avec succe", "Ajout nom", MessageBoxButtons.OK);
                this.Close();
            }            
            else
            {
                MessageBox.Show("Nom, n'est pas sauvegarder!", "Erreur");
            }
        }
    }
}
