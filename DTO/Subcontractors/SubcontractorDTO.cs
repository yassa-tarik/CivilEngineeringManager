namespace DTO.Subcontractors
{
    /// <summary>
    /// A data transfer object (DTO) representing a subcontractor.
    /// </summary>
    public class SubcontractorDto
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Representative { get; set; }
        public string BankAccountNumber { get; set; }
        public bool IsActive { get; set; }

        public SubcontractorDto() { }

        public SubcontractorDto(int id, string companyName, string representative, string bankAccountNumber, bool isActive)
        {
            ID = id;
            CompanyName = companyName;
            Representative = representative;
            BankAccountNumber = bankAccountNumber;
            IsActive = isActive;
        }
    }
}
