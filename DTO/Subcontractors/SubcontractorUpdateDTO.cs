using DTO.Contacts;

namespace DTO.Subcontractors
{
    /// <summary>
    /// A data transfer object (DTO) used to update an existing subcontractor.
    /// Inherits common properties from SubcontractorBaseDto and adds an ID.
    /// </summary>
    public class SubcontractorUpdateDTO : SubcontractorBaseDTO
    {
        public int ID { get; set; }

        /// <summary>
        /// Initializes a new instance of the SubcontractorUpdateDto class.
        /// It calls the base class constructor to initialize common properties.
        /// </summary>
        public SubcontractorUpdateDTO(int id, string companyName, string representative, string bankAccountNumber, bool isActive, bool isDeleted, ContactDTO contactDTO)
            : base(companyName, representative, bankAccountNumber, isActive, isDeleted, contactDTO)
        {
            ID = id;
        }
    }
}
