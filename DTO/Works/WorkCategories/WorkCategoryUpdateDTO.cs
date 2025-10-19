namespace DTO.Works.WorkCategories
{
    /// <summary>
    /// A data transfer object (DTO) used to update an existing work category.
    /// Inherits common properties from WorkCategoryBaseDto and adds an ID.
    /// </summary>
    public class WorkCategoryUpdateDTO : WorkCategoryBaseDTO
    {
        public int ID { get;}

        public WorkCategoryUpdateDTO(int iD, int projectID, int workCategoryDesignation_ID, string designation) : base(projectID, workCategoryDesignation_ID, designation)
        {
            this.ID = iD;
        }
    }
}
