namespace DTO.Works.WorkSpecs
{
    /// <summary>
    /// A data transfer object (DTO) used to create a new work specification.
    /// Inherits common properties from WorkSpecBaseDTO.
    /// </summary>
    public class WorkSpecCreateDTO : WorkSpecBaseDTO
    {
        public WorkSpecCreateDTO(int? workCategory_ID, int? workType_ID, string designation, string unit, decimal unitPrice, double quantity, string vAT)
            : base(workCategory_ID, workType_ID, designation, unit, unitPrice, quantity, vAT)
        {
        }
    }
}
