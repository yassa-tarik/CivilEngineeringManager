using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int WorkCategoryName_ID { get; private set; }
        public string WorkCategoryName { get; private set; }
        // Audit
        internal DateTime CreationDate { get; private set; }
        internal int CreatedBy { get; private set; }
        internal DateTime ModificationDate { get; private set; }
        internal int ModifiedBy { get; private set; }
        public WorkCategory(int id, int project_ID, int workCategoryName_ID, string workCategoryName, int createdBy)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            if (project_ID <= 0)
            {
                throw new ArgumentException("Project_ID must be greater than zero.", nameof(project_ID));
            }
            if (workCategoryName_ID <= 0)
            {
                throw new ArgumentException("WorkCategoryName_ID must be greater than zero.", nameof(workCategoryName_ID));
            }
            if (string.IsNullOrWhiteSpace(workCategoryName))
            {
                throw new ArgumentException("WorkCategoryName cannot be null or empty.", nameof(workCategoryName));
            }

            ID = id;
            Project_ID = project_ID;
            WorkCategoryName_ID = workCategoryName_ID;
            WorkCategoryName = workCategoryName;
            CreationDate = DateTime.Now;
            CreatedBy = createdBy;
            ModificationDate = DateTime.Now;
            ModifiedBy = createdBy;
        }

        /// <summary>
        /// Updates the WorkCategory's name and modification details.
        /// </summary>
        public void Update(int workCategoryName_ID, string workCategoryName, int modifiedBy)
        {
            if (workCategoryName_ID <= 0)
            {
                throw new ArgumentException("WorkCategoryName_ID must be greater than zero.", nameof(workCategoryName_ID));
            }
            if (string.IsNullOrWhiteSpace(workCategoryName))
            {
                throw new ArgumentException("WorkCategoryName cannot be null or empty.", nameof(workCategoryName));
            }

            WorkCategoryName_ID = workCategoryName_ID;
            WorkCategoryName = workCategoryName;
            ModificationDate = DateTime.Now;
            ModifiedBy = modifiedBy;
        }

    }
}
