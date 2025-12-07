using CivilEngineeringManager.UI.Enums;
using DTO.Addresses;
using DTO.Contacts;
using DTO.Subcontractors;
using MyApplication.Abstractions;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CivilEngineeringManager.Forms
{
    public partial class frmAddEditViewSubcontractor : Form
    {
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;

        private readonly ISubcontractorService _subcontractorService;
        private readonly FormMode _mode;
        private readonly int _subcontractorId;
        private SubcontractorDTO _currentSubcontractor;
        public frmAddEditViewSubcontractor(ISubcontractorService subcontractorService, ICountryService countryService, ICityService cityService, FormMode mode, int subcontractorId = 0)
        {
            InitializeComponent();
            _subcontractorService = subcontractorService;
            _countryService = countryService;
            _cityService = cityService;
            _mode = mode;
            _subcontractorId = subcontractorId;
            ctrlContact1.ContactCountryChanged += CtrlContact1_ContactCountryChanged;
        }

        private void CtrlContact1_ContactCountryChanged(object sender, int e)
        {
            ctrlContact1.LoadCities(_cityService.GetByCountryId(e));
        }

        private async void frmAddEditViewSubcontractor_Load(object sender, System.EventArgs e)
        {
            // 1️⃣ Fetch data via BLL services
            ctrlContact1.LoadCountries(_countryService.GetAll());

            switch (_mode)
            {
                case FormMode.Add:
                    Text = "Add Subcontractor";
                    ContactDTO contactDTO = new ContactDTO(string.Empty, string.Empty, string.Empty, string.Empty, new AddressDTO(0, 0, string.Empty, string.Empty, string.Empty, string.Empty));

                    _currentSubcontractor = new SubcontractorDTO(0, string.Empty, string.Empty, string.Empty, false, false, contactDTO);

                    LoadSubcontractorToUI(_currentSubcontractor);
                    break;

                case FormMode.Edit:
                    Text = "Modifier le Projet";
                    await LoadExistingSubcontractorAsync(_subcontractorId);
                    break;

                case FormMode.Read:
                    Text = "Consulter le Projet";
                    await LoadExistingSubcontractorAsync(_subcontractorId, isReadOnly: true);
                    break;
            }
        }

        private void LoadSubcontractorToUI(SubcontractorDTO subcontractor)
        {
            if (subcontractor == null)
                return;

            //---Basic fields---
            txtID.Text = subcontractor.ID.ToString();
            txtCompanyName.Text = subcontractor.CompanyName;
            txtRepresentative.Text = subcontractor.Representative;
            txtBankAccountNum.Text = subcontractor.BankAccountNumber ?? string.Empty;

            // --- Contact control ---
            if (subcontractor.Contact != null)
            {
                ctrlContact1.LoadContactInfo(subcontractor.Contact);
            }
            else
            {
                // If no address exists (e.g. new project)
                ctrlContact1.LoadContactInfo(new ContactDTO(string.Empty, string.Empty, string.Empty, string.Empty, new AddressDTO(0, 0, string.Empty, string.Empty, string.Empty, string.Empty)));
            }
        }

        private async Task LoadExistingSubcontractorAsync(int subcontractorId, bool isReadOnly = false)
        {
            if (subcontractorId <= 0)
                return;
            try
            {
                _currentSubcontractor = await _subcontractorService.GetByIdAsync(subcontractorId);

                if (_currentSubcontractor == null)
                {
                    System.Windows.Forms.MessageBox.Show("Subcontractor not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                LoadSubcontractorToUI(_currentSubcontractor);
                SetReadOnlyState(isReadOnly);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error while loading subcontractor : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetReadOnlyState(bool isReadOnly)
        {
            txtCompanyName.ReadOnly = isReadOnly;
            txtRepresentative.ReadOnly = isReadOnly;
            txtBankAccountNum.ReadOnly = isReadOnly;
            txtID.ReadOnly = isReadOnly;

            btnSave.Visible = !isReadOnly;

            // Contact control has its own logic
            ctrlContact1.SetReadMode(isReadOnly);
        }

        private SubcontractorCreateDTO BuildCreateDTOFromUI()
        {
            var contact = ctrlContact1.GetContactDTO();

            return new SubcontractorCreateDTO
            (
                txtCompanyName.Text.Trim(),
                txtRepresentative.Text.Trim(),
                txtBankAccountNum.Text.Trim(),
                chxIsActive.Checked,
                false,   //TODO: for now we assum not deleted
                contact);
        }

        private SubcontractorUpdateDTO BuildUpdateDTOFromUI()
        {
            var contact = ctrlContact1.GetContactDTO();

            return new SubcontractorUpdateDTO
            (
                _currentSubcontractor.ID,
                txtCompanyName.Text.Trim(),
                txtRepresentative.Text.Trim(),
                txtBankAccountNum.Text.Trim(),
                chxIsActive.Checked,
                false,   //TODO: for now we assum not deleted
                contact);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // --- Validate basic required fields ---
                if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
                {
                    System.Windows.Forms.MessageBox.Show("The company name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCompanyName.Focus();
                    return;
                }

                if (_mode == FormMode.Add)
                {
                    var createDto = BuildCreateDTOFromUI();

                    if (MessageBox.Show($"Do you want to add subcontractor?", "info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (await _subcontractorService.AddNewAsync(createDto))
                        {
                            System.Windows.Forms.MessageBox.Show($"Projet added successfully :).", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }
                    }
                }
                else if (_mode == FormMode.Edit)
                {
                    var updateDto = BuildUpdateDTOFromUI();
                    if (MessageBox.Show($"Do you want to modify this Subcontractor?", "Modify projet", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //if (await _subcontractorService.UpdateAsync(updateDto))
                        //{
                        //    System.Windows.Forms.MessageBox.Show("Projet modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    DialogResult = DialogResult.OK;
                        //}
                    }
                }

                Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error while saving : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}