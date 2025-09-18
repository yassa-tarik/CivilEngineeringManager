using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public WorkType(int id, int? workCategory_ID, int? parent_ID, string designation, int createdBy)
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
            CreatedBy = createdBy;
            ModificationDate = DateTime.Now;
            ModifiedBy = createdBy;
        }

        /// <summary>
        /// Updates the WorkType's properties and modification details.
        /// </summary>
        public void Update(int? workCategory_ID, int? parent_ID, string designation, int modifiedBy)
        {
            if (string.IsNullOrWhiteSpace(designation))
            {
                throw new ArgumentException("Designation cannot be null or empty.", nameof(designation));
            }

            WorkCategory_ID = workCategory_ID;
            Parent_ID = parent_ID;
            Designation = designation;
            ModificationDate = DateTime.Now;
            ModifiedBy = modifiedBy;
        }
    }

}
