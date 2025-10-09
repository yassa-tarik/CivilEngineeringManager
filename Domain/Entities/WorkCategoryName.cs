using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// A domain entity representing a specific work category name.
    /// This is used as a lookup table to avoid redundant strings in the database.
    /// </summary>
    public class WorkCategoryName
    {
        public int ID { get; internal set; }
        public string Name { get; private set; }

        // Audit
        public DateTime CreationDate { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int ModifiedBy { get; private set; }

        public WorkCategoryName(int id, string name, int createdBy)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category name cannot be null or empty.", nameof(name));
            }

            ID = id;
            Name = name;
            CreationDate = DateTime.Now;
            CreatedBy = createdBy;
            ModificationDate = DateTime.Now;
            ModifiedBy = createdBy;
        }
    }

}
