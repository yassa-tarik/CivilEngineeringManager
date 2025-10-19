using System;

namespace Domain.Entities
{
    /// <summary>
    /// A domain entity representing a specific work category name.
    /// This is used as a lookup table to avoid redundant strings in the database.
    /// </summary>
    public class WorkCategoryDesignation
    {
        public int ID { get; internal set; } = default;
        public string Designation { get; private set; }

        // Audit
        public DateTime CreationDate { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int ModifiedBy { get; private set; }

        public WorkCategoryDesignation(int id, string designation)
        {
            if (string.IsNullOrWhiteSpace(designation))
            {
                throw new ArgumentException("Category name cannot be null or empty.", nameof(designation));
            }

            ID = id;
            Designation = designation;
            CreationDate = DateTime.Now;
            CreatedBy = 1;   //will be the current user id
            ModificationDate = DateTime.Now;
            ModifiedBy = 1;   //will be the current user id
        }

        // for create new
        public WorkCategoryDesignation(string designation)
        {
            Validate(designation);

            Designation = designation;
            CreationDate = DateTime.Now;
            CreatedBy = 1;   // will be the current user ID
            ModificationDate = DateTime.Now;
            ModifiedBy = 1; // will be the current user ID
        }
        // used for Create
        private void Validate(string designation)
        {
            if (ID >= 0)
                throw new InvalidOperationException("ID must be negative.");
            //Designation validation
            if (string.IsNullOrWhiteSpace(Designation))
                throw new InvalidOperationException("Designation is required.");
            else if (Designation.Length > 100)
                throw new InvalidOperationException("Designation cannot exceed 100 characters.");
        }

        public void Update(int id, string designation)
        {
            ID = id;
            Designation = designation;
            ModificationDate = DateTime.Now;
            ModifiedBy = 1; // will be the current user ID

            Validate();
        }

        // used for Update
        private void Validate()
        {
            if (ID <= 0)
                throw new InvalidOperationException("ID must be positive.");
            //Designation validation
            if (string.IsNullOrWhiteSpace(Designation))
                throw new InvalidOperationException("Designation is required.");
            else if (Designation.Length > 100)
                throw new InvalidOperationException("Designation cannot exceed 100 characters.");

            // CreatedBy validation
            if (CreatedBy <= 0)
                throw new InvalidOperationException("CreatedBy must be a valid user ID.");
        }
    }
}
