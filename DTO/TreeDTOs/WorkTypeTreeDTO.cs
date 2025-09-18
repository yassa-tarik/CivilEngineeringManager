using DTO.Works.WorkSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.TreeDTOs
{
    /// <summary>
    /// Represents a WorkType within a hierarchical tree structure, including its nested WorkSpecs and child WorkTypes.
    /// </summary>
    public class WorkTypeTreeDTO
    {
        public int ID { get; set; }
        public int? WorkCategoryID { get; set; }
        public int? ParentID { get; set; }
        public string Designation { get; set; }

        /// <summary>
        /// This self-referencing collection allows for nesting of WorkTypes to create a tree structure.
        /// </summary>
        public ICollection<WorkTypeTreeDTO> WorkTypes { get; set; }

        /// <summary>
        /// This collection holds the WorkSpec data associated with this specific WorkType.
        /// </summary>
        public ICollection<WorkSpecDTO> WorkSpecs { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkTypeTreeDTO"/> class.
        /// </summary>
        public WorkTypeTreeDTO()
        {
            WorkTypes = new List<WorkTypeTreeDTO>();
            WorkSpecs = new List<WorkSpecDTO>();
        }
    }
}
