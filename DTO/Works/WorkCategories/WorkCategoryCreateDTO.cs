namespace DTO.Works.WorkCategories
{
    /// <summary>
    /// A data transfer object (DTO) used to create a new work category.
    /// Inherits common properties from WorkCategoryBaseDto.
    /// </summary>
    public class WorkCategoryCreateDTO : WorkCategoryBaseDTO
    {
        public WorkCategoryCreateDTO(int project_ID, int workCategoryDesignation_ID, string workCategoryDesignation) : base(project_ID, workCategoryDesignation_ID, workCategoryDesignation)
        {
        }
    }
}
