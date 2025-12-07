using DTO.Contacts;

namespace DTO.Subcontractors
{    /// <summary>
     /// A base data transfer object (DTO) that contains common properties
     /// for both creating and updating a subcontractor.
     /// </summary>
    public class SubcontractorBaseDTO
    {
        public string CompanyName { get; set; }
        public string Representative { get; set; }
        public string BankAccountNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public ContactDTO ContactDTO { get; set; }
        /// <summary>
        /// Initializes a new instance of the SubcontractorBaseDto class.
        /// </summary>
        public SubcontractorBaseDTO(string companyName, string representative, string bankAccountNumber, bool isActive, bool isDeleted, ContactDTO contactDTO)
        {
            CompanyName = companyName;
            Representative = representative;
            BankAccountNumber = bankAccountNumber;
            IsActive = isActive;
            IsDeleted = isDeleted;
            ContactDTO = contactDTO;
        }
    }
}
