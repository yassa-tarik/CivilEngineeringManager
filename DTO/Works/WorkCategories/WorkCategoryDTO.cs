namespace DTO.Works.WorkCategories
{
    public class WorkCategoryDTO
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int WorkCategoryDesignation_ID { get; set; }
        public string Designation { get; set; }

        public WorkCategoryDTO(int iD, int projectID, int workCategoryDesignation_ID, string designation)
        {
            ID = iD;
            ProjectID = projectID;
            WorkCategoryDesignation_ID = workCategoryDesignation_ID;
            Designation = designation;
        }
    }
}
