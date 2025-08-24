namespace DTO.TaskType
{
    public class TaskTypeDTO
    {
        public int ID { get; private set; }
        public int ProjectID { get; private set; }
        public int TaskTypeNameID { get; private set; }
        public string Designation { get; private set; }

        public TaskTypeDTO(int id, int projectID, int taskTypeNameID, string designation)
        {
            ID = id;
            ProjectID = projectID;
            TaskTypeNameID = taskTypeNameID;
            Designation = designation;
        }
    }
}
