using System.Collections.Generic;

namespace DTO.TreeDTOs
{
    public class ProjectTreeDTO
    {
        public int ID { get; }
        public string Name { get; }
        public bool IsSpecComplete { get; private set; }
        /// <summary>
        /// This collection holds the WorkCategories data associated with this specific Project.
        /// </summary>
        public ICollection<WorkCategoryTreeDTO> WorkCategories { get; set; }


        public ProjectTreeDTO(int id, string name)
        {
            ID = id;
            Name = name;
            WorkCategories = new List<WorkCategoryTreeDTO>();
        }

        public ProjectTreeDTO()
        {
            WorkCategories = new List<WorkCategoryTreeDTO>();
        }
    }
}
