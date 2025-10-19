namespace DTO.Works.WorkCategories
{
    /// <summary>
    /// A base data transfer object (DTO) that contains common properties
    /// for creating and updating a work category.
    /// </summary>
    public abstract class WorkCategoryBaseDTO
    {
        public int Project_ID { get; set; }
        public int WorkCategoryDesignation_ID { get; set; }
        public string WorkCategoryDesignation { get; set; }

        protected WorkCategoryBaseDTO(int project_ID, int workCategoryDesignation_ID, string workCategoryDesignation)
        {
            Project_ID = project_ID;
            WorkCategoryDesignation_ID = workCategoryDesignation_ID;
            WorkCategoryDesignation = workCategoryDesignation;
        }
    }
}
