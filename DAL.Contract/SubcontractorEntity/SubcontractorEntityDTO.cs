using System;

namespace DAL.Contracts.SubcontractorEntity
{
    public class SubcontractorEntityDTO : ContributorBaseEntityDTO
    {
        //Contact part
        public int ID_Address { get; } = default;
        public string Telephone { get; }
        public string Mobile { get; }
        public string Fax { get; }
        public string Email { get; }
        //Address part
        public int ID_Country { get; set; }
        public int ID_City { get; set; }
        public string APC { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string PlaceName { get; set; }
        public string Landmark { get; set; }

        public SubcontractorEntityDTO(int iD, int iD_Contact, string companyName, string representative, string bankAccountNumber, DateTime creationDate, int createdBy, DateTime modificationDate, int modifiedBy, bool isActive, int ID_Address, string telephone, string mobile, string fax, string email, int ID_Country, int ID_City, string aPC, string street, string PostalCode, string placeName, string landmark) : base(iD, iD_Contact, companyName, representative, bankAccountNumber, creationDate, createdBy, modificationDate, modifiedBy, isActive)
        {
            this.ID_Address = ID_Address;
            this.Telephone = telephone;
            this.Mobile = mobile;
            this.Fax = fax;
            this.Email = email;
            this.ID_Country = ID_Country;
            this.ID_City = ID_City;
            this.APC = aPC;
            this.Street = street;
            this.PostalCode = PostalCode;
            this.PlaceName = placeName;
            this.Landmark = landmark;
        }
    }
}
