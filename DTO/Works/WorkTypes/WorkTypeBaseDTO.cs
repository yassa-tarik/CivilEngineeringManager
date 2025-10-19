namespace DTO.Works
{
    /// <summary>
    /// A base data transfer object (DTO) that contains common properties
    /// for creating and updating a work type.
    /// </summary>
    public abstract class WorkTypeBaseDTO
    {
        public int? WorkCategory_ID { get; set; }
        public int? Parent_ID { get; set; }
        public string Designation { get; set; }

        public WorkTypeBaseDTO(int? workCategory_ID, int? parent_ID, string designation)
        {
            WorkCategory_ID = workCategory_ID;
            Parent_ID = parent_ID;
            Designation = designation;
        }
    }
}
