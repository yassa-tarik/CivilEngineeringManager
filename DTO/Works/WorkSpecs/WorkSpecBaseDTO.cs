namespace DTO.Works.WorkSpecs
{
    /// <summary>
    /// A base data transfer object (DTO) that contains common properties
    /// for creating and updating a work specification.
    /// </summary>
    // TODO: will check if we can put properties to read only
    public abstract class WorkSpecBaseDTO
    {
        public int? WorkCategory_ID { get; set; }
        public int? WorkType_ID { get; set; }
        public string Designation { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public double Quantity { get; set; }
        public string VAT { get; set; }

        public WorkSpecBaseDTO(int? workCategory_ID, int? workType_ID, string designation, string unit, decimal unitPrice, double quantity, string vAT)
        {
            WorkCategory_ID = workCategory_ID;
            WorkType_ID = workType_ID;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            VAT = vAT;
        }
    }
}
