using System;

namespace Domain.Entities
{
    /// <summary>
    /// A domain entity representing a work category within a project.
    /// This is the top level of the work breakdown structure.
    /// </summary>
    public class WorkCategory
    {
        public int ID { get; private set; }
        public int Project_ID { get; private set; }
        public int WorkCategoryDesignation_ID { get; private set; }
        //public string Designation { get; private set; }
        // Audit
        public DateTime CreationDate { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int ModifiedBy { get; private set; }

        // for creation new entity
        public WorkCategory(int project_ID, int workCategoryDesignation_ID)
        {
            if (project_ID <= 0)
            {
                throw new ArgumentException("Project_ID must be greater than zero.", nameof(project_ID));
            }
            //if (workCategoryDesignation_ID <= 0)
            //{
            //    throw new ArgumentException("WorkCategoryName_ID must be greater than zero.", nameof(workCategoryDesignation_ID));
            //}
            //if (string.IsNullOrWhiteSpace(designation))
            //{
            //    throw new ArgumentException("WorkCategoryName cannot be null or empty.", nameof(designation));
            //}

            Project_ID = project_ID;
            WorkCategoryDesignation_ID = workCategoryDesignation_ID;
            //Designation = designation;
            CreationDate = DateTime.Now;
            CreatedBy = 1;  //will be current user id
            ModificationDate = DateTime.Now;
            ModifiedBy = 1;  //will be current user id
        }

        public WorkCategory(int id, int project_ID, int workCategoryDesignation_ID)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            if (project_ID <= 0)
            {
                throw new ArgumentException("Project_ID must be greater than zero.", nameof(project_ID));
            }
            if (workCategoryDesignation_ID <= 0)
            {
                throw new ArgumentException("WorkCategoryName_ID must be greater than zero.", nameof(workCategoryDesignation_ID));
            }
            //if (string.IsNullOrWhiteSpace(designation))
            //{
            //    throw new ArgumentException("WorkCategoryName cannot be null or empty.", nameof(designation));
            //}

            ID = id;
            Project_ID = project_ID;
            WorkCategoryDesignation_ID = workCategoryDesignation_ID;
            //Designation = designation;
            CreationDate = DateTime.Now;
            CreatedBy = 1;  //will be current user id;
            ModificationDate = DateTime.Now;
            ModifiedBy = 1;  //will be current user id;
        }

        /// <summary>
        /// Updates the WorkCategory's name and modification details.
        /// </summary>
        public void Update(int workCategoryDesignation_ID/*, string designation*/)
        {
            WorkCategoryDesignation_ID = workCategoryDesignation_ID;
            //Designation = designation;
            ModificationDate = DateTime.Now;
            ModifiedBy = 1; // will be the current user ID

            Validate();
        }
        // used for Update
        private void Validate()
        {
            if (ID <= 0)
                throw new InvalidOperationException("ID must be positive.");
            // Designation validation
            //if (string.IsNullOrWhiteSpace(Designation))
            //    throw new InvalidOperationException("Designation is required.");
            //else if (Designation.Length > 255)
            //    throw new InvalidOperationException("Designation cannot exceed 255 characters.");

            // CreatedBy validation
            if (CreatedBy <= 0)
                throw new InvalidOperationException("CreatedBy must be a valid user ID.");

            if (Project_ID <= 0)
                throw new InvalidOperationException("Project_ID must be positive.");

        }

        public void AddNew(int project_ID, int workCategoryName_ID/*, string designation*/)
        {
            Validate(project_ID, workCategoryName_ID/*, designation*/);

            WorkCategoryDesignation_ID = workCategoryName_ID;
            //Designation = designation;
            ModificationDate = DateTime.Now;
            ModifiedBy = 1; // will be the current user ID

        }
        // used for Create
        private void Validate(int project_ID, int workCategoryName_ID/*, string designation*/)
        {
            if (ID >= 0)
                throw new InvalidOperationException("ID must be negative.");
            // Designation validation
            //if (string.IsNullOrWhiteSpace(Designation))
            //    throw new InvalidOperationException("Designation is required.");
            //else if (Designation.Length > 255)
            //    throw new InvalidOperationException("Designation cannot exceed 255 characters.");

            //if (Project_ID <= 0)
            //    throw new InvalidOperationException("Project_ID must be positive.");
        }
    }
}
