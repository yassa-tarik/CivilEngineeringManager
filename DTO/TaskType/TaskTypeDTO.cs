namespace DTO.TaskType
{
    public class TaskTypeDTO
    {
        public int ID { get; set; }
        public int ID_Projet { get; set; }
        public int ID_TypeTravauxNom { get; set; }
        public string Designation { get; set; }

        public TaskTypeDTO(int iD, int iD_Projet, int iD_TypeTravauxNom, string designation)
        {
            ID = iD;
            ID_Projet = iD_Projet;
            ID_TypeTravauxNom = iD_TypeTravauxNom;
            Designation = designation;
        }
    }
}
