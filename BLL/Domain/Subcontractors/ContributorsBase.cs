using BLL.Domain.Contacts;
using System;

namespace BLL.Domain.Subcontractors
{
    abstract class ContributorsBase
    {
        public int ID { get; internal set; }
        public int ID_Contact { get; internal set; }
        public string RaisonSocial { get; internal set; }
        public string Representant { get; internal set; }
        public string NumCptBank { get; internal set; }
        public DateTime CreationDate { get; internal set; }
        public int CreePar { get; internal set; }
        public DateTime ModificationDate { get; internal set; }
        public int ModifierPar { get; internal set; }
        public bool IsActive { get; internal set; }
        public Contact Contact { get; internal set; }

        protected ContributorsBase(int iD, int iD_Contact, string raisonSocial, string representant, string numCptBank, DateTime creationDate, int creePar, DateTime modificationDate, int modifierPar, bool isActive, Contact contact)
        {
            // Validate company name
            if (string.IsNullOrWhiteSpace(raisonSocial))
                throw new ArgumentException("Company name cannot be empty", nameof(raisonSocial));
            if (raisonSocial.Length > 100) // Adjust max length as needed
                throw new ArgumentException("Company name is too long", nameof(raisonSocial));

            // Validate representative name
            if (string.IsNullOrWhiteSpace(representant))
                throw new ArgumentException("Representative name cannot be empty", nameof(representant));
            if (representant.Length > 100) // Adjust max length as needed
                throw new ArgumentException("Representative name is too long", nameof(representant));

            // Validate bank account number
            if (string.IsNullOrWhiteSpace(numCptBank))
                throw new ArgumentException("Bank account number cannot be empty", nameof(numCptBank));
            if (numCptBank.Length > 34) // IBAN max length is 34 characters
                throw new ArgumentException("Bank account number is too long", nameof(numCptBank));

            // Validate creation date (not in future)
            if (creationDate > DateTime.Now)
                throw new ArgumentException("Creation date cannot be in the future", nameof(creationDate));

            // Validate creator ID
            if (creePar <= 0)
                throw new ArgumentException("Creator ID must be a positive value", nameof(creePar));

            // Validate modification date (not before creation date)
            if (modificationDate < creationDate)
                throw new ArgumentException("Modification date cannot be before creation date", nameof(modificationDate));

            // Validate modifier ID
            if (modifierPar <= 0)
                throw new ArgumentException("Modifier ID must be a positive value", nameof(modifierPar));

            // Validate contact object
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));
            if (contact.ID != iD_Contact)
                throw new ArgumentException("Contact ID mismatch between parameter and DTO", nameof(contact));

            // Assign values after all validations pass
            ID = iD;
            ID_Contact = iD_Contact;
            RaisonSocial = raisonSocial;
            Representant = representant;
            NumCptBank = numCptBank;
            CreationDate = creationDate;
            CreePar = creePar;
            ModificationDate = modificationDate;
            ModifierPar = modifierPar;
            IsActive = isActive;
            Contact = contact;
        }
    }
}
