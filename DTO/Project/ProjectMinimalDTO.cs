namespace DTO.Project
{
    public class ProjectMinimalDTO
    {
        public int ID { get; }
        public string Name { get; }
        public bool isSpecComplete { get; }
        public byte Progress { get; }

        public ProjectMinimalDTO(int iD, string name, bool isSpecComplete, byte progress)
        {
            this.ID = iD;
            this.Name = name;
            this.isSpecComplete = isSpecComplete;
            this.Progress = progress;
        }
    }
}
