using System;

namespace DAL.Contracts.SubcontractorEntity
{
    public class SubcontractorEntityDTO : ContributorBaseEntityDTO
    {
        //Contact part
        public int ID_Address { get; } = default;
        public string Telephone { get; }
        public string Mobile { get; }
        public string Telecopie { get; }
        public string Email { get; }
        //Address part
        public int ID_Country { get; set; }
        public int ID_City { get; set; }
        public string APC { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string LieuDit { get; set; }
        public string Reper { get; set; }

        public SubcontractorEntityDTO(int iD, int iD_Contact, string raisonSocial, string representant, string numCptBank, DateTime creationDate, int creePar, DateTime modificationDate, int modifierPar, bool isActive, int ID_Address, string telephone, string mobile, string telecopie, string email, int ID_Country, int ID_City, string aPC, string address, string PostalCode, string lieuDit, string reper) : base(iD, iD_Contact, raisonSocial, representant, numCptBank, creationDate, creePar, modificationDate, modifierPar, isActive)
        {
            this.ID_Address = ID_Address;
            this.Telephone = telephone;
            this.Mobile = mobile;
            this.Telecopie = telecopie;
            this.Email = email;
            this.ID_Country = ID_Country;
            this.ID_City = ID_City;
            this.APC = aPC;
            this.Address = address;
            this.PostalCode = PostalCode;
            this.LieuDit = lieuDit;
            this.Reper = reper;
        }
    }
}
