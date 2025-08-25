using DTO.Address;
using System;
using System.Collections.Generic;

namespace DTO.Project
{
    public class ProjectDTO
    {
        public int ID { get; }
        public string Name { get; }
        public string ProjectCode { get; }
        public bool IsDeleted { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string ProjectType { get; set; }
        public string Description { get; set; }
        public int Progression { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string LandRegistry { get; set; }
        public string SubdivisionPermitNumber { get; set; }
        public Nullable<DateTime> SubdivisionPermitDate { get; set; }
        public string ConstructionPermitNumber { get; set; }
        public DateTime ConstructionPermitDate { get; set; }
        public string DeedVolume { get; set; }
        public string DeedNumber { get; set; }
        public string DeedFolio { get; set; }
        public string LandBook { get; set; }
        public Nullable<DateTime> LandBookDate { get; set; }
        public string LandBookBy { get; set; }
        public bool IsSpecComplete { get; set; }
        public byte Progress { get; set; }
        public AddressDTO Address { get; }

        public ProjectDTO(int id, string name, string projectCode, bool isDeleted, DateTime startDate, int duration, string projectType, string description, int progression, bool isActive, int createdBy, string landRegistry, string subdivisionPermitNumber, Nullable<DateTime> subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, Nullable<DateTime> landBookDate, string landBookBy, bool isSpecComplete, byte progress, AddressDTO address)
        {
            this.ID = id;
            this.Name = name;
            this.ProjectCode = projectCode;
            this.IsDeleted = isDeleted;
            this.StartDate = startDate;
            this.Duration = duration;
            this.ProjectType = projectType;
            this.Description = description;
            this.Progression = progression;
            this.IsActive = isActive;
            this.CreatedBy = createdBy;
            this.LandRegistry = landRegistry;
            this.SubdivisionPermitNumber = subdivisionPermitNumber;
            this.SubdivisionPermitDate = subdivisionPermitDate;
            this.ConstructionPermitNumber = constructionPermitNumber;
            this.ConstructionPermitDate = constructionPermitDate;
            this.DeedVolume = deedVolume;
            this.DeedNumber = deedNumber;
            this.DeedFolio = deedFolio;
            this.LandBook = landBook;
            this.LandBookDate = landBookDate;
            this.LandBookBy = landBookBy;
            this.IsSpecComplete = isSpecComplete;
            this.Progress = progress;
            this.Address = address;
        }
    }
}
