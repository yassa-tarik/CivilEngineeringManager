namespace DTO.Projects
{
    public class ProjectMinDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSpecComplete { get; private set; }
        public byte Progress { get; set; }
        public string ProjectType { get; set; }
        public ProjectMinDTO(int iD, string name, bool isSpecComplete, byte progress, string projectType)
        {
            ID = iD;
            Name = name;
            IsSpecComplete = isSpecComplete;
            Progress = progress;
            ProjectType = projectType;
        }
    }
}
