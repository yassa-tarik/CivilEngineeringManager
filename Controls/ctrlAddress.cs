using DTO.Addresses;
using DTO.Cities;
using DTO.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CivilEngineeringManager.Controls
{
    public partial class ctrlAddress : UserControl
    {
        private AddressDTO _currentAddress;
        public event EventHandler<int> CountryChanged;

        public ctrlAddress()
        {
            InitializeComponent();
        }

        #region Public Methods

        public void LoadAddress(AddressDTO dto)
        {
            if (dto == null)
                return;

            _currentAddress = dto;

            // --- Country ---
            if (cbxCountries.DataSource != null && cbxCountries.Items.Count > 0)
            {
                if (cbxCountries.Items.Cast<CountryDTO>().Any(item => item.ID == dto.Country_ID))
                {
                    cbxCountries.SelectedValue = dto.Country_ID;
                }
                else
                {
                    cbxCountries.SelectedIndex = -1; // no valid match
                }
            }

            // --- City ---
            if (cbxCities.DataSource != null && cbxCities.Items.Count > 0)
            {
                if (cbxCities.Items.Cast<CityDTO>().Any(item => item.ID == dto.City_ID))
                {
                    cbxCities.SelectedValue = dto.City_ID;
                }
                else
                {
                    cbxCities.SelectedIndex = -1;
                }
            }

            // --- Text fields ---
            txtMunicipality.Text = dto.Municipality ?? string.Empty;
            txtPostalCode.Text = dto.PostalCode ?? string.Empty;
            txtPlaceName.Text = dto.PlaceName ?? string.Empty;
            txtLandmark.Text = dto.Landmark ?? string.Empty;
        }

        public AddressDTO GetAddressDTO()
        {
            return new AddressDTO(
                Convert.ToInt32(cbxCountries.SelectedValue ?? 0),
                Convert.ToInt32(cbxCities.SelectedValue ?? 0),
                txtMunicipality.Text?.Trim(),
                txtPostalCode.Text?.Trim(),
                txtPlaceName.Text?.Trim(),
                txtLandmark.Text?.Trim()
            );
        }

        public void LoadCountries(List<CountryDTO> countries)
        {
            if (countries == null) countries = new List<CountryDTO>();
            cbxCountries.DataSource = countries;
            cbxCountries.DisplayMember = "Name";
            cbxCountries.ValueMember = "ID";
        }

        public void LoadCities(List<CityDTO> cities)
        {
            cbxCities.DataSource = cities;
            cbxCities.DisplayMember = "Name";
            cbxCities.ValueMember = "ID";
        }

        public void SetReadMode(bool isReadOnly)
        {
            cbxCountries.Enabled = !isReadOnly;
            cbxCities.Enabled = !isReadOnly;
            txtMunicipality.ReadOnly = isReadOnly;
            txtPostalCode.ReadOnly = isReadOnly;
            txtPlaceName.ReadOnly = isReadOnly;
            txtLandmark.ReadOnly = isReadOnly;
        }
        #endregion

        private void cbxCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCountries.SelectedValue is int selectedCountryId && selectedCountryId > 0)
            {
                // Raise event to notify parent form
                CountryChanged?.Invoke(this, selectedCountryId);
            }
        }
    }
}