using System;
namespace DAL.Contract.Project
{
    public class ProjectEntityDTO
    {
        public int ID { get; }
        public int AddressID { get; }
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
        // Address part
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public string APC { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string PlaceName { get; set; }
        public string Landmark { get; set; }

        public ProjectEntityDTO(int id, int addressID, string name, string projectCode, bool isDeleted, DateTime startDate, int duration, string projectType, string description, int progression, bool isActive, int createdBy, string landRegistry, string subdivisionPermitNumber, Nullable<DateTime> subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, Nullable<DateTime> landBookDate, string landBookBy, bool isSpecComplete, byte progress, int countryID, int cityID, string apc, string street, string postalCode, string locality, string landmark)
        {
            this.ID = id;
            this.AddressID = addressID;
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
            this.CountryID = countryID;
            this.CityID = cityID;
            this.APC = apc;
            this.Street = street;
            this.PostalCode = postalCode;
            this.PlaceName = locality;
            this.Landmark = landmark;
        }
    }
}
