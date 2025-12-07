using DTO.Addresses;
using DTO.Cities;
using DTO.Contacts;
using DTO.Countries;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CivilEngineeringManager.Controls
{
    public partial class ctrlContact : UserControl
    {
        ContactDTO _currentContactDTO;

        public event EventHandler<int> ContactCountryChanged;

        public ctrlContact()
        {
            InitializeComponent();
            ctrlAddress1.CountryChanged += CtrlAddress_CountryChanged;
        }
        // event raises when country Address control changed
        private void CtrlAddress_CountryChanged(object sender, int e)
        {
            ContactCountryChanged?.Invoke(sender, e);
        }

        public void LoadContactInfo(ContactDTO contactDTO)
        {
            if (_currentContactDTO == null)
            {
                return;
            }
            _currentContactDTO = contactDTO;

            txtTelephone.Text = _currentContactDTO.Telephone;
            txtMobile.Text = _currentContactDTO.Mobile;
            txtTelecopy.Text = _currentContactDTO.Telecopy;
            txtEmail.Text = _currentContactDTO.Email;
            this.ctrlAddress1.LoadAddress(_currentContactDTO.Address);
        }

        internal ContactDTO GetContactInfoFromControls()
        {
            string Telephone = txtTelephone.Text;
            string Mobile = txtMobile.Text;
            string Telecopy = txtTelecopy.Text;
            string Email = txtEmail.Text;

            AddressDTO adresseDTO = ctrlAddress1.GetAddressDTO();

            return new ContactDTO(Telephone, Mobile, Telecopy, Email, adresseDTO);
        }

        public void LoadCountries(List<CountryDTO> countries)
        {
            ctrlAddress1.LoadCountries(countries);
        }

        public void LoadCities(List<CityDTO> cities)
        {
            ctrlAddress1.LoadCities(cities);
        }

        public void SetReadMode(bool isReadOnly)
        {
            txtTelephone.ReadOnly = !isReadOnly;
            txtMobile.ReadOnly = isReadOnly;
            txtTelecopy.ReadOnly = !isReadOnly;
            txtEmail.ReadOnly = isReadOnly;

            ctrlAddress1.SetReadMode(isReadOnly);
        }

        public ContactDTO GetContactDTO()
        {
            var address = ctrlAddress1.GetAddressDTO();
            var contact = new ContactDTO(txtTelephone.Text.Trim(), txtMobile.Text.Trim(), txtTelecopy.Text.Trim(), txtEmail.Text.Trim(), address);
            return contact;
        }
    }
}
