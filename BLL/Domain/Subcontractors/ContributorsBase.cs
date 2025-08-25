using BLL.Domain.Contacts;
using System;

namespace BLL.Domain.Subcontractors
{
    abstract class ContributorsBase
    {
        public int ID { get; internal set; }
        public int ID_Contact { get; internal set; }
        public string CompanyName { get; internal set; }
        public string Representative { get; internal set; }
        public string BankAccountNumber { get; internal set; }
        public DateTime CreationDate { get; internal set; }
        public int CreatedBy { get; internal set; }
        public DateTime ModificationDate { get; internal set; }
        public int ModifiedBy { get; internal set; }
        public bool IsActive { get; internal set; }
        public Contact Contact { get; internal set; }

        protected ContributorsBase(int iD, int iD_Contact, string companyName, string representative, string bankAccountNumber, DateTime creationDate, int createdBy, DateTime modificationDate, int modifiedBy, bool isActive, Contact contact)
        {
            ID = iD;
            ID_Contact = iD_Contact;
            CompanyName = companyName;
            Representative = representative;
            BankAccountNumber = bankAccountNumber;
            CreationDate = creationDate;
            CreatedBy = createdBy;
            ModificationDate = modificationDate;
            ModifiedBy = modifiedBy;
            IsActive = isActive;
            Contact = contact;
        }
    }
}
