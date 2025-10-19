namespace DTO.Works.WorkCategoryDesignations
{
    /// <summary>
    /// A data transfer object (DTO) used to create a new work category name.
    /// Inherits common properties from WorkCategoryNameBaseDto.
    /// </summary>
    public class WorkCategoryDesignationCreateDTO : WorkCategoryDesignationBaseDTO
    {
        public WorkCategoryDesignationCreateDTO(string designation) : base(designation)
        {
        }
    }
}
