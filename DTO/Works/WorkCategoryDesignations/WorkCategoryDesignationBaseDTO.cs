namespace DTO.Works.WorkCategoryDesignations
{
    /// <summary>
    /// A base data transfer object (DTO) that contains common properties
    /// for creating and updating a work category name.
    /// </summary>
    public class WorkCategoryDesignationBaseDTO
    {
        public string Designation { get; set; }

        public WorkCategoryDesignationBaseDTO(string Designation)
        {
            this.Designation = Designation;
        }
    }
}
