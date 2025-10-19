namespace DTO.Works.WorkTypes
{
    /// <summary>
    /// A data transfer object (DTO) used to create a new work type.
    /// Inherits common properties from WorkTypeBaseDTO.
    /// </summary>
    public class WorkTypeCreateDTO : WorkTypeBaseDTO
    {
        public WorkTypeCreateDTO(int? workCategory_ID, int? parent_ID, string designation)
            : base(workCategory_ID, parent_ID, designation)
        {
        }
    }
}
