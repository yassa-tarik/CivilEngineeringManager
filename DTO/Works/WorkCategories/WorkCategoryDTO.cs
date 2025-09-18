using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkCategories
{
    public class WorkCategoryDTO
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int WorkCategoryNameID { get; set; }
        public string WorkCategoryName { get; set; }

        public WorkCategoryDTO(int iD, int projectID, int workCategoryNameID, string workCategoryName)
        {
            ID = iD;
            ProjectID = projectID;
            WorkCategoryNameID = workCategoryNameID;
            WorkCategoryName = workCategoryName;
        }
    }
}
