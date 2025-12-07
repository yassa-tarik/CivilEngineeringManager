using System;

namespace Domain.Entities
{
    /// <summary>
    /// A domain entity representing a type of work in the hierarchy.
    /// It is self-referencing to create a tree structure.
    /// </summary>
    public class WorkType
    {
        public int ID { get; private set; }
        public int? WorkCategory_ID { get; private set; }
        public int? Parent_ID { get; private set; }
        public string Designation { get; private set; }
        // Audit
        public DateTime CreationDate { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int ModifiedBy { get; private set; }

        // Constructor for creating a new WorkType entity
        public WorkType(int id, int? workCategory_ID, int? parent_ID, string designation)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            if (string.IsNullOrWhiteSpace(designation))
            {
                throw new ArgumentException("Designation cannot be null or empty.", nameof(designation));
            }

            ID = id;
            WorkCategory_ID = workCategory_ID;
            Parent_ID = parent_ID;
            Designation = designation;
            CreationDate = DateTime.Now;
            CreatedBy = 1; //will be the current userID
            ModificationDate = DateTime.Now;
            ModifiedBy = 1; //will be the current userID
        }

        public WorkType(int? workCategory_ID, int? parent_ID, string designation)
        {
            Validate(workCategory_ID, parent_ID, designation);

            WorkCategory_ID = workCategory_ID;
            Parent_ID = parent_ID;
            Designation = designation;
            CreationDate = DateTime.Now;
            CreatedBy = 1; //will be the current userID
            ModificationDate = DateTime.Now;
            ModifiedBy = 1; //will be the current userID
        }

        /// <summary>
        /// Updates the WorkType's properties and modification details.
        /// </summary>
        public void Update(int? workCategory_ID, int? parent_ID, string designation)
        {
            WorkCategory_ID = workCategory_ID;
            Parent_ID = parent_ID;
            Designation = designation;
            ModificationDate = DateTime.Now;
            ModifiedBy = 1; //will be the current userID

            Validate();
        }
        // used for Update
        private void Validate()
        {
            if (ID <= 0)
                throw new InvalidOperationException("ID must be positive.");
            // Designation validation
            if (string.IsNullOrWhiteSpace(Designation))
                throw new InvalidOperationException("Designation is required.");
            else if (Designation.Length > 255)
                throw new InvalidOperationException("Designation cannot exceed 255 characters.");

            // CreatedBy validation
            if (CreatedBy <= 0)
                throw new InvalidOperationException("CreatedBy must be a valid user ID.");

            // WorkType_ID validation (if provided)
            if (WorkCategory_ID == null && Parent_ID == null)
                throw new InvalidOperationException("WorkType_ID must have a Parent (shouldn't be orphand).");
        }

        // used for create new
        private void Validate(int? workCategory_ID, int? parent_ID, string designation)
        {
            if (workCategory_ID == null && parent_ID == null)
            {
                throw new ArgumentException("WorkType must have a Parent!.", nameof(workCategory_ID));
            }
            if (workCategory_ID.HasValue && parent_ID.HasValue)
            {
                throw new ArgumentException("WorkType must have only one Parent!", nameof(designation));
            }

            if (string.IsNullOrWhiteSpace(designation))
            {
                throw new ArgumentException("Designation cannot be empty or whitespace.", nameof(designation));
            }

            // If the method reaches this point, all parameters are considered valid based on these rules.
        }
    }
}
