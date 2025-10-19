using DTO.Works.WorkSpecs;
using System.Collections.Generic;

namespace DTO.TreeDTOs
{
    /// <summary>
    /// Represents a WorkType within a hierarchical tree structure, including its nested WorkSpecs and child WorkTypes.
    /// </summary>
    public class WorkTypeTreeDTO
    {
        public int ID { get; set; }
        public int? WorkCategory_ID { get; set; }
        public int? Parent_ID { get; set; }
        public string Designation { get; set; }

        /// <summary>
        /// This self-referencing collection allows for nesting of WorkTypes to create a tree structure.
        /// </summary>
        public ICollection<WorkTypeTreeDTO> WorkTypes { get; set; }

        /// <summary>
        /// This collection holds the WorkSpec data associated with this specific WorkType.
        /// </summary>
        public ICollection<WorkSpecUpdateDTO> WorkSpecs { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkTypeTreeDTO"/> class.
        /// </summary>
        public WorkTypeTreeDTO(/*int ID, int? workCategoryID, int? parentID*/)
        {
            //this.ID = ID;
            //this.WorkCategoryID = workCategoryID;
            //this.ParentID = parentID;
            this.WorkTypes = new List<WorkTypeTreeDTO>();
            this.WorkSpecs = new List<WorkSpecUpdateDTO>();
        }
    }
}
