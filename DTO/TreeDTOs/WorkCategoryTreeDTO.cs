using DTO.Works.WorkSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.TreeDTOs
{
    /// <summary>
    /// Represents a WorkCategory within a hierarchical tree structure, including its nested WorkTypes.
    /// </summary>
    public class WorkCategoryTreeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// This collection holds the WorkTypes data associated with this specific WorkCategory.
        /// </summary>
        public ICollection<WorkTypeTreeDTO> WorkTypes { get; set; }
        /// <summary>
        /// This collection holds the WorkSpec data associated with this specific WorkType.
        /// </summary>
        public ICollection<WorkSpecDTO> WorkSpecs { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkCategoryTreeDTO"/> class.
        /// </summary>
        public WorkCategoryTreeDTO()
        {
            WorkTypes = new List<WorkTypeTreeDTO>();
            WorkSpecs = new List<WorkSpecDTO>();
        }
    }
}
