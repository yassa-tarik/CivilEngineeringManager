using CivilEngineeringManager.Controls;
using CivilEngineeringManager.UI.Enums;
using DTO.Addresses;
using DTO.Cities;
using DTO.Countries;
using DTO.Projects;
using MyApplication.Abstractions;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CivilEngineeringManager.Forms
{
    public partial class frmAddEditReadProject : Form
    {
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;

        private readonly IProjectService _projectService;
        private readonly FormMode _mode;
        private readonly int _projectId;
        private ProjectDTO _currentProject;

        public frmAddEditReadProject(IProjectService projectService, ICountryService countryService, ICityService cityService, FormMode mode, int projectId = 0)
        {
            InitializeComponent();
            _projectService = projectService;
            _countryService = countryService;
            _cityService = cityService;
            _mode = mode;
            _projectId = projectId;
            ctrlAddress1.CountryChanged += CtrlAddress_CountryChanged;
        }
        // event raises when country changed
        private void CtrlAddress_CountryChanged(object sender, int countryId)
        {
            ctrlAddress1.LoadCities(_cityService.GetByCountryId(countryId));
        }

        private async void frmAddEditReadProject_Load(object sender, EventArgs e)
        {
            // 1️⃣ Fetch data via BLL services
            ctrlAddress1.LoadCountries(_countryService.GetAll());

            switch (_mode)
            {
                case FormMode.Add:
                    Text = "Ajouter un Projet";
                    AddressDTO Address = new AddressDTO(0, 0, 0, string.Empty, string.Empty, string.Empty, string.Empty);

                    _currentProject = new ProjectDTO(0,string.Empty,string.Empty,DateTime.Now, 0,string.Empty,string.Empty,true, string.Empty,string.Empty,null,string.Empty,DateTime.Now,string.Empty,string.Empty,string.Empty,string.Empty,null,string.Empty,false,0,Address,DateTime.Now,0,DateTime.Now,0,false );

                    LoadProjectToUI(_currentProject);
                    break;

                case FormMode.Edit:
                    Text = "Modifier le Projet";
                    await LoadExistingProjectAsync(_projectId);
                    break;

                case FormMode.Read:
                    Text = "Consulter le Projet";
                    await LoadExistingProjectAsync(_projectId, isReadOnly: true);
                    break;
            }
        }

        private void LoadProjectToUI(ProjectDTO project)
        {
            if (project == null)
                return;

            //---Basic fields---
            txtName.Text = project.Name;
            txtProjectCode.Text = project.ProjectCode ?? string.Empty;
            txtProjectType.Text = project.ProjectType;
            txtProgress.Text = project.Progress.ToString("0.##");
            txtDuration.Text = project.Duration.ToString();
            txtDescription.Text = project.Description;
            chxIsSpecCompleted.Checked = project.IsSpecCompleted;

            // --- Dates ---
            if (project.StartDate != default)
                dtpStartDate.Value = project.StartDate;
            else
                dtpStartDate.Value = DateTime.MaxValue;

            // --- Address control ---
            if (project.Address != null)
            {
                ctrlAddress1.LoadAddress(project.Address);
            }
            else
            {
                // If no address exists (e.g. new project)
                ctrlAddress1.LoadAddress(new AddressDTO(0, 0, 0, string.Empty, string.Empty, string.Empty, string.Empty));
            }

            // --- Read-only handling ---
            bool isReadOnly = _mode == FormMode.Read;
            SetReadOnlyState(isReadOnly);
        }

        private void SetReadOnlyState(bool isReadOnly)
        {
            txtProjectCode.ReadOnly = isReadOnly;
            txtName.ReadOnly = isReadOnly;
            txtProjectType.ReadOnly = isReadOnly;
            txtProgress.ReadOnly = isReadOnly;
            txtDuration.ReadOnly = isReadOnly;
            txtDescription.ReadOnly = isReadOnly;
            chxIsSpecCompleted.Enabled = !isReadOnly;
            dtpStartDate.Enabled = !isReadOnly;

            // Address control has its own logic
            ctrlAddress1.SetReadMode(isReadOnly);
        }

        private ProjectCreateDTO BuildCreateDTOFromUI()
        {        
            var address = ctrlAddress1.GetAddressCreateDTO();

            return new ProjectCreateDTO
            (
                txtName.Text.Trim(),
                txtProjectCode.Text.Trim(),
                dtpStartDate.Value,
                int.TryParse(txtDuration.Text, out var d) ? d : 0,
                txtProjectType.Text,
                txtDescription.Text.Trim(),
                chxIsActive.Checked,
                txtLandRegistry.Text.Trim(),
                txtSubdivisionPermitNum.Text.Trim(),
                dtpSubdivisionPermitDate.Checked ? dtpSubdivisionPermitDate.Value : (DateTime?)null,
                txtConstPermitNum.Text.Trim(),
                dtpConstPermitDate.Value,
                txtDeedVolume.Text.Trim(),
                txtDeedNum.Text.Trim(),
                txtDeedFolio.Text.Trim(),
                txtLandBookNum.Text.Trim(),
                dtpLandBookDate.Checked ? dtpLandBookDate.Value : (DateTime?)null,
                txtLandBookBy.Text.Trim(),
                chxIsSpecCompleted.Checked,
                Convert.ToByte(txtProgress.Text), //TODO: will check if successful converted
                address);
        }

        private ProjectUpdateDTO BuildUpdateDTOFromUI()
        {
            var address = ctrlAddress1.GetAddressUpdateDTO();

            return new ProjectUpdateDTO
            (
                _currentProject.ID,
                txtName.Text.Trim(),
                txtProjectCode.Text.Trim(),
                dtpStartDate.Value,
                int.TryParse(txtDuration.Text, out var d) ? d : 0,
                txtProjectType.Text,
                txtDescription.Text.Trim(),
                chxIsActive.Checked,
                txtLandRegistry.Text.Trim(),
                txtSubdivisionPermitNum.Text.Trim(),
                dtpSubdivisionPermitDate.Checked ? dtpSubdivisionPermitDate.Value : (DateTime?)null,
                txtConstPermitNum.Text.Trim(),
                dtpConstPermitDate.Value,
                txtDeedVolume.Text.Trim(),
                txtDeedNum.Text.Trim(),
                txtDeedFolio.Text.Trim(),
                txtLandBookNum.Text.Trim(),
                dtpLandBookDate.Checked ? dtpLandBookDate.Value : (DateTime?)null,
                txtLandBookBy.Text.Trim(),
                chxIsSpecCompleted.Checked,
                Convert.ToByte(txtProgress.Text), //TODO: will check if successful converted
                address);           
        }

        private async Task LoadExistingProjectAsync(int projectId, bool isReadOnly = false)
        {
            if (projectId <= 0)
                return;

            try
            {
                _currentProject = await _projectService.GetByIdAsync(projectId);

                if (_currentProject == null)
                {
                    System.Windows.Forms.MessageBox.Show("Le projet n'a pas été trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                LoadProjectToUI(_currentProject);
                SetReadOnlyState(isReadOnly);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erreur lors du chargement du projet : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // --- Collect address first ---
                //var addressDto = ctrlAddress1.GetAddressDTO();

                // --- Validate basic required fields ---
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Le nom du projet est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                if (_mode == FormMode.Add)
                {
                    var createDto = BuildCreateDTOFromUI();

                    var newProjectId = await _projectService.AddNewAsync(createDto);

                    System.Windows.Forms.MessageBox.Show($"Projet ajouté avec succès (ID : {newProjectId}).", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else if (_mode == FormMode.Edit)
                {
                    var updateDto = BuildUpdateDTOFromUI();

                    await _projectService.UpdateAsync(updateDto);

                    System.Windows.Forms.MessageBox.Show("Projet modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }

                Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
