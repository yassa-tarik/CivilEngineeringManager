using DTO.Contact;
using System;

namespace DTO.Subcontractor
{
    public class ContributorBaseDTO
    {
        public int ID { get; }
        public int ID_Contact { get; set; }
        public string RaisonSocial { get; set; }
        public string Representant { get; set; }

        public string NumCptBank { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreePar { get; set; }
        public DateTime ModificationDate { get; set; }
        public int ModifierPar { get; set; }
        public bool IsActive { get; set; }
        public ContactDTO Contact { get; }

        public ContributorBaseDTO(int iD, int iD_Contact, string raisonSocial, string representant, string numCptBank, DateTime creationDate, int creePar, DateTime modificationDate, int modifierPar, bool isActive, ContactDTO contact)
        {
            this.ID = iD;
            this.ID_Contact = iD_Contact;
            this.RaisonSocial = raisonSocial;
            this.Representant = representant;
            this.NumCptBank = numCptBank;
            this.CreationDate = creationDate;
            this.CreePar = creePar;
            this.ModificationDate = modificationDate;
            this.ModifierPar = modifierPar;
            this.IsActive = isActive;
            this.Contact = contact;
        }
    }
}
