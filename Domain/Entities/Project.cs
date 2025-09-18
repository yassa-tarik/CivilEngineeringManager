using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project
    {
        public int ID { get; }
        public string Name { get; private set; }
        public string ProjectCode { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime StartDate { get; private set; }
        public int Duration { get; private set; }
        public string ProjectType { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }        
        public string LandRegistry { get; private set; }
        public string SubdivisionPermitNumber { get; private set; }
        public DateTime? SubdivisionPermitDate { get; private set; }
        public string ConstructionPermitNumber { get; private set; }
        public DateTime ConstructionPermitDate { get; private set; }
        public string DeedVolume { get; private set; }
        public string DeedNumber { get; private set; }
        public string DeedFolio { get; private set; }
        public string LandBook { get; private set; }
        public DateTime? LandBookDate { get; private set; }
        public string LandBookBy { get; private set; }
        public bool IsSpecComplete { get; private set; }
        public byte Progress { get; private set; }
        public int Address_ID { get; private set; }
        // audit
        public DateTime CreatedDate { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int ModifiedBy { get; private set; }

        internal Project(int id, string name, string projectCode, DateTime startDate, int duration, string projectType, string description, bool isActive, string landRegistry, string subdivisionPermitNumber, DateTime? subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, DateTime? landBookDate, string landBookBy, bool isSpecComplete, byte progress, int address_ID, DateTime createdDate, int createdBy, DateTime modificationDate, int modifiedBy, bool isDeleted)
        {
            ID = id;
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
            Address_ID = address_ID;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            ModificationDate = modificationDate;
            ModifiedBy = modifiedBy;
            IsDeleted = isDeleted;
        }

        // Constructor for creating a new Project entity
        public Project(string name, string projectCode, DateTime startDate, int duration, string projectType, string description, string landRegistry, string subdivisionPermitNumber, Nullable<DateTime> subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, Nullable<DateTime> landBookDate, string landBookBy, bool isSpecComplete, byte progress, int createdBy)
        {
            Validate(name, projectCode, startDate, duration, projectType, description, landRegistry, subdivisionPermitNumber, subdivisionPermitDate, constructionPermitNumber, constructionPermitDate, deedVolume, deedNumber, deedFolio, landBook, landBookDate, landBookBy);

            this.Name = name;
            this.ProjectCode = projectCode;
            this.StartDate = startDate;
            this.Duration = duration;
            this.ProjectType = projectType;
            this.Description = description;
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
            this.Address_ID = -1;   //will be generated by database
            this.IsDeleted = false; // New projects are not deleted
            this.IsActive = true; // New projects are active by default
            this.CreatedDate = DateTime.Now;
            this.CreatedBy = createdBy;
            this.ModifiedBy = createdBy;
            this.ModificationDate = DateTime.Now;
        }

        public Project(int iD)
        {
            ID = iD;
        }


        /// <summary>
        /// Validates the state of the Project model.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if any validation check fails.</exception>
        public void Validate()
        {
            // Validate required integer properties
            if (ID <= 0)
            {
                throw new InvalidOperationException("Project ID must be greater than zero.");
            }
            if (CreatedBy <= 0)
            {
                throw new InvalidOperationException("CreatedBy must be greater than zero.");
            }
            if (ModifiedBy <= 0)
            {
                throw new InvalidOperationException("ModifiedBy must be greater than zero.");
            }
            if (Duration < 0)
            {
                throw new InvalidOperationException("Duration cannot be a negative number.");
            }

            // Validate required string properties
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new InvalidOperationException("Project Name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(ProjectCode))
            {
                throw new InvalidOperationException("Project Code cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(ProjectType))
            {
                throw new InvalidOperationException("Project Type cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new InvalidOperationException("Description cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(LandRegistry))
            {
                throw new InvalidOperationException("Land Registry cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(SubdivisionPermitNumber))
            {
                throw new InvalidOperationException("Subdivision Permit Number cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(ConstructionPermitNumber))
            {
                throw new InvalidOperationException("Construction Permit Number cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(DeedVolume))
            {
                throw new InvalidOperationException("Deed Volume cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(DeedNumber))
            {
                throw new InvalidOperationException("Deed Number cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(DeedFolio))
            {
                throw new InvalidOperationException("Deed Folio cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(LandBook))
            {
                throw new InvalidOperationException("Land Book cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(LandBookBy))
            {
                throw new InvalidOperationException("Land Book By cannot be null or empty.");
            }

            // Validate required DateTime properties
            if (StartDate == default)
            {
                throw new InvalidOperationException("Start Date cannot be a default value.");
            }
            if (ConstructionPermitDate == default)
            {
                throw new InvalidOperationException("Construction Permit Date cannot be a default value.");
            }
            if (CreatedDate == default)
            {
                throw new InvalidOperationException("Created Date cannot be a default value.");
            }
            if (ModificationDate == default)
            {
                throw new InvalidOperationException("Modification Date cannot be a default value.");
            }

            // Validate nested object
            if (Address_ID <= 0)
            {
                throw new InvalidOperationException("Address ID cannot be negative.");
            }            
        }

        // for create new
        private void Validate(string name, string projectCode, DateTime startDate, int duration, string projectType, string description, string landRegistry, string subdivisionPermitNumber, Nullable<DateTime> subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, Nullable<DateTime> landBookDate, string landBookBy)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Project name is required.");
            if (string.IsNullOrWhiteSpace(projectCode))
                throw new InvalidOperationException("Project code is required.");
            if (startDate == DateTime.MinValue)
                throw new InvalidOperationException("Start date is required.");
            if (duration <= 0)
                throw new InvalidOperationException("Duration must be a positive value.");
            if (string.IsNullOrWhiteSpace(projectType))
                throw new InvalidOperationException("Project type is required.");
            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidOperationException("Description is required.");
            if (string.IsNullOrWhiteSpace(landRegistry))
                throw new InvalidOperationException("Land registry is required.");
            if (string.IsNullOrWhiteSpace(subdivisionPermitNumber))
                throw new InvalidOperationException("Subdivision permit number is required.");
            if (string.IsNullOrWhiteSpace(constructionPermitNumber))
                throw new InvalidOperationException("Construction permit number is required.");
            if (string.IsNullOrWhiteSpace(deedVolume))
                throw new InvalidOperationException("Deed volume is required.");
            if (string.IsNullOrWhiteSpace(deedNumber))
                throw new InvalidOperationException("Deed number is required.");
            if (string.IsNullOrWhiteSpace(deedFolio))
                throw new InvalidOperationException("Deed folio is required.");
            if (string.IsNullOrWhiteSpace(landBook))
                throw new InvalidOperationException("Land book is required.");
            if (string.IsNullOrWhiteSpace(landBookBy))
                throw new InvalidOperationException("Land book by is required.");
        }

        /// <summary>
        /// Updates the project properties and validates the new state.
        /// </summary>
        public void Update(string name, string projectCode, DateTime startDate, int duration, string projectType, string description, bool isActive, string landRegistry, string subdivisionPermitNumber, DateTime? subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, DateTime? landBookDate, string landBookBy, bool isSpecComplete, byte progress, int address_ID, int createdBy, int modifienBY)
        {
            // Update all mutable properties
            Name = name;
            ProjectCode = projectCode;
            // IsDeleted = isDeleted;  TODO
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
            Address_ID = address_ID;
            ModificationDate = DateTime.Now;
            CreatedBy = createdBy;
            ModifiedBy = modifienBY;         // TODO: will be currentUserID

            Validate(); // Validate the updated state
        }

        public bool MarkAsArchived(int modifiedBy)
        {            
            IsDeleted = true;
            IsActive = false; // Deactivated upon deletion
            this.SetAuditFields(ModifiedBy);
            return true;
        }

        //************** Smaller Update methods ***************************
        public void UpdateGeneralDetails(string name, string projectCode, bool isActive, string projectType, string description)
        {
            // General details validation
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Project name is required.");
            if (string.IsNullOrWhiteSpace(projectCode))
                throw new InvalidOperationException("Project code is required.");
            this.Name = name;
            this.ProjectCode = projectCode;
            this.IsActive = isActive;
            this.ProjectType = projectType;
            this.Description = description;
        }

        public void UpdateProjectStatus(bool isDeleted, bool isSpecComplete, byte progress)
        {
            this.IsDeleted = isDeleted;
            this.IsSpecComplete = isSpecComplete;
            this.Progress = progress;
        }

        public void UpdateLegalDetails(string landRegistry, string subdivisionPermitNumber, Nullable<DateTime> subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, Nullable<DateTime> landBookDate, string landBookBy)
        {
            // Legal details validation
            if (string.IsNullOrWhiteSpace(landRegistry))
                throw new InvalidOperationException("Land registry is required.");
            if (string.IsNullOrWhiteSpace(subdivisionPermitNumber))
                throw new InvalidOperationException("Subdivision permit number is required.");
            if (string.IsNullOrWhiteSpace(constructionPermitNumber))
                throw new InvalidOperationException("Construction permit number is required.");
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
        }

        public void SetAuditFields(int modifiedBy)
        {
            this.ModifiedBy = modifiedBy;
            this.ModificationDate = DateTime.Now;
        }
    }
}
