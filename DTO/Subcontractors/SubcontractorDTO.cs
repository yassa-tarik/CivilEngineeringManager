using DTO.Contacts;

namespace DTO.Subcontractors
{
    /// <summary>
    /// A data transfer object (DTO) representing a subcontractor.
    /// </summary>
    public class SubcontractorDTO
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Representative { get; set; }
        public string BankAccountNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; private set; }
        public ContactDTO Contact { get; internal set; }

        public SubcontractorDTO(int iD, string companyName, string representative, string bankAccountNumber, bool isActive, bool isDeleted, ContactDTO contact)
        {
            ID = iD;
            CompanyName = companyName;
            Representative = representative;
            BankAccountNumber = bankAccountNumber;
            IsActive = isActive;
            IsDeleted = isDeleted;
            Contact = contact;
        }
    }
}
