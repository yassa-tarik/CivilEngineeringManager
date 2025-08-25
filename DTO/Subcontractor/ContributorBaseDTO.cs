using DTO.Contact;
using System;

namespace DTO.Subcontractor
{
    public class ContributorBaseDTO
    {
        public int ID { get; }
        public int ID_Contact { get; set; }
        public string CompanyName { get; set; }
        public string Representative { get; set; }

        public string BankAccountNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public ContactDTO Contact { get; }

        public ContributorBaseDTO(int iD, int iD_Contact, string companyName, string representative, string bankAccountNumber, DateTime creationDate, int createdBy, DateTime modificationDate, int modifiedBy, bool isActive, ContactDTO contact)
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
