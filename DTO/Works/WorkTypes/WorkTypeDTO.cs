namespace DTO.Works.WorkTypes
{
    /// <summary>
    /// A data transfer object (DTO) that represents a work type for read-only operations (it doesn't inherit from the WorkTypeBaseDTO).
    /// </summary>
    public class WorkTypeDTO
    {
        public int ID { get; set; }
        public int? WorkCategory_ID { get; set; }
        public int? Parent_ID { get; set; }
        public string Designation { get; set; }

        public WorkTypeDTO(int iD, int? workCategoryID, int? parentID, string designation)
        {
            ID = iD;
            WorkCategory_ID = workCategoryID;
            Parent_ID = parentID;
            Designation = designation;
        }
    }
}
