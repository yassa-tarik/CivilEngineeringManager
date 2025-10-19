namespace DTO.Works.WorkCategoryDesignations
{
    public class WorkCategoryDesignationUpdateDTO : WorkCategoryDesignationBaseDTO
    {
        public WorkCategoryDesignationUpdateDTO(int iD, string designation) : base(designation)
        {
            this.ID = iD;
        }
        public int ID { get; set; }
    }
}
