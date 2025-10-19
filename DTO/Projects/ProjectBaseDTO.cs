using System;

namespace DTO.Projects
{
    public class ProjectBaseDTO
    {
        public string Name { get; }
        public string ProjectType { get; }
        public string ProjectCode { get; }
        public DateTime StartDate { get; }
        public int Duration { get; }
        public string Description { get; }
        public bool IsActive { get; }
        public bool IsDeleted { get; }

        public string LandRegistry { get; }
        public string SubdivisionPermitNumber { get; }
        public DateTime? SubdivisionPermitDate { get; }
        public string ConstructionPermitNumber { get; }
        public DateTime ConstructionPermitDate { get; }
        public string DeedVolume { get; }
        public string DeedNumber { get; }
        public string DeedFolio { get; }
        public string LandBook { get; }
        public DateTime? LandBookDate { get; }
        public string LandBookBy { get; }
        public bool IsSpecComplete { get; }
        public byte Progress { get; }

        public int CreatedBy { get; }
        public int ModifiedBy { get; }

        public ProjectBaseDTO(string name, string projectCode, DateTime startDate, int duration, string projectType, string description, bool isActive, string landRegistry, string subdivisionPermitNumber, DateTime? subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, DateTime? landBookDate, string landBookBy, bool isSpecComplete, byte progress, int createdBy, int modifiedBy)
        {
            Name = name;
            ProjectCode = projectCode;

            StartDate = startDate;
            Duration = duration;
            ProjectType = projectType;
            Description = description;
            IsActive = isActive;
            LandRegistry = landRegistry;
            SubdivisionPermitNumber = subdivisionPermitNumber;
            SubdivisionPermitDate = subdivisionPermitDate;
            ConstructionPermitNumber = constructionPermitNumber;
            ConstructionPermitDate = constructionPermitDate;
            DeedVolume = deedVolume;
            DeedNumber = deedNumber;
            DeedFolio = deedFolio;
            LandBook = landBook;
            LandBookDate = landBookDate;
            LandBookBy = landBookBy;
            IsSpecComplete = isSpecComplete;
            Progress = progress;

            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
        }
    }
}
