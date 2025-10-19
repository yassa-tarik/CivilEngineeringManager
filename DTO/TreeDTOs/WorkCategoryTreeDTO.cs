using DTO.Works.WorkSpecs;
using System.Collections.Generic;

namespace DTO.TreeDTOs
{    /// <summary>
     /// Represents a WorkCategory within a hierarchical tree structure, including its nested WorkTypes.
     /// </summary>
    public class WorkCategoryTreeDTO
    {
        public int ID { get; set; }
        public int Project_ID { get; set; }
        public int WorkCategoryDesignation_ID { get; set; }
        public string Designation { get; set; } //it was Name in WorkCategoryDTO
        /// <summary>
        /// This collection holds the WorkTypes data associated with this specific WorkCategory.
        /// </summary>
        public ICollection<WorkTypeTreeDTO> WorkTypes { get; set; }
        /// <summary>
        /// This collection holds the WorkSpec data associated with this specific WorkType.
        /// </summary>
        public ICollection<WorkSpecUpdateDTO> WorkSpecs { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkCategoryTreeDTO"/> class.
        /// </summary>
        public WorkCategoryTreeDTO()
        {
            WorkTypes = new List<WorkTypeTreeDTO>();
            WorkSpecs = new List<WorkSpecUpdateDTO>();
        }
    }
}
