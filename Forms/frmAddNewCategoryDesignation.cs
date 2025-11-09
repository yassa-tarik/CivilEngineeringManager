using DTO.Works.WorkCategoryDesignations;
using MyApplication.Abstractions.Works;
using System;
using System.Windows.Forms;

namespace CivilEngineeringManager.Forms
{
    public partial class frmAddNewCategoryDesignation : Form
    {
        private readonly IWorkCategoryDesignationService _workCategoryDesignationService;
        private WorkCategoryDesignationCreateDTO workCategoryDesignCreateDTO;
        private WorkCategoryDesignationUpdateDTO workCategoryDesignUpdateDTO;
        public frmAddNewCategoryDesignation(IWorkCategoryDesignationService workCategoryDesignationService, WorkCategoryDesignationUpdateDTO updateDTO = null)
        {
            InitializeComponent();
            _workCategoryDesignationService = workCategoryDesignationService;
            workCategoryDesignUpdateDTO = updateDTO;
        }
        // done
        private async void btnAddNewCatDesign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCatDesign.Text.Trim()))
            {
                MessageBox.Show("Veuillez entre un nom valide!", "Ajout nom");
                return;
            }

            workCategoryDesignCreateDTO = new WorkCategoryDesignationCreateDTO(txtCatDesign.Text);

            try
            {
                if (await _workCategoryDesignationService.AddAsync(workCategoryDesignCreateDTO) > 0)
                {
                    MessageBox.Show($"Category {workCategoryDesignCreateDTO.Designation} sauvegarder avec succe", "Ajout nom", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Category Design, n'est pas sauvegarder!", "Erreur");
                }
            }
            catch (Exception)
            {
                //TODO: logging here
                MessageBox.Show("Category Design, Already exists!", "Erreur");                
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCatDesign.Text.Trim()))
            {
                MessageBox.Show("Veuillez entre un nom valide!", "Ajout nom");
                return;
            }
            
            if (_workCategoryDesignationService.isExistsByName(txtCatDesign.Text))
            {
                MessageBox.Show("Ce nom est très similaire à un nom existant. Veuillez reverifier!", "Ajout nom", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //if (await _workCategoryDesignationService.AddAsync(workCategoryDesignCreateDTO) > 0)
            //{
            //    MessageBox.Show($"Category {workCategoryDesignCreateDTO.Designation} sauvegarder avec succe", "Ajout nom", MessageBoxButtons.OK);
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Nom, n'est pas sauvegarder!", "Erreur");
            //}
        }
    }
}
