namespace DTO.Works.WorkSpecs
{
    /// <summary>
    /// A data transfer object (DTO) used to update an existing work specification.
    /// Inherits common properties from WorkSpecBaseDTO and adds an ID.
    /// </summary>
    public class WorkSpecUpdateDTO : WorkSpecBaseDTO
    {
        public int ID { get; }

        /// <summary>
        /// Initializes a new instance of the WorkSpecUpdateDTO with all properties,
        /// including a call to the base constructor.
        /// </summary>
        public WorkSpecUpdateDTO(int id, int? workCategory_ID, int? workType_ID, string designation, string unit, decimal unitPrice, double quantity, string vAT, bool isAssigned)
            : base(workCategory_ID, workType_ID, designation, unit, unitPrice, quantity, vAT, isAssigned)
        {
            ID = id;
        }
    }
}
