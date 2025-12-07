using System;

namespace Domain.Entities
{
    /// <summary>
    /// A domain entity representing a subcontractor.
    /// </summary>
    public class Subcontractor
    {
        public int ID { get; internal set; }
        public string CompanyName { get; internal set; }
        public string Representative { get; internal set; }
        public string BankAccountNumber { get; internal set; }
        public bool IsActive { get; internal set; }
        public bool IsDeleted { get; private set; }
        public Contact Contact { get; internal set; }

        // Audit
        public DateTime CreationDate { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int ModifiedBy { get; private set; }

        public Subcontractor(int id, string companyName, string representative, string bankAccountNumber, Contact contact, DateTime createdDate, int createdBy, DateTime modificationDate, int modifiedBy, bool isActive, bool isDeleted)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            ID = id;
            CompanyName = companyName;
            Representative = representative;
            BankAccountNumber = bankAccountNumber;
            IsActive = isActive;
            Contact = contact;

            CreationDate = createdDate;
            CreatedBy = createdBy;                  // TODO: will be current user
            ModificationDate = modificationDate;
            ModifiedBy = modifiedBy;

            IsDeleted = isDeleted;
        }


        public Subcontractor(string companyName, string representative, string bankAccountNumber, Contact contact, bool isActive, bool isDeleted)
        {
            CompanyName = companyName;
            Representative = representative;
            BankAccountNumber = bankAccountNumber;
            IsActive = isActive;
            Contact = contact;

            CreationDate = DateTime.Now;
            CreatedBy = 1;                  // TODO: will be current user
            ModificationDate = DateTime.Now;
            ModifiedBy = 1;

            IsDeleted = isDeleted;
        }

        /// <summary>
        /// Updates the Subcontractor's properties and modification details.
        /// </summary>
        public void Update(string companyName, string representative, string bankAccountNumber, bool isActive, int id_contact, Contact contact)
        {
            CompanyName = companyName;
            Representative = representative;
            BankAccountNumber = bankAccountNumber;
            IsActive = isActive;
            Contact = contact;

            ModificationDate = DateTime.Now;
            ModifiedBy = 1;                  // TODO: will be current user
        }
    }
}