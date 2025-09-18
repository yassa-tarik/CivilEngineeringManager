using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkTypes
{
    /// <summary>
    /// A data transfer object (DTO) that represents a work type for read-only operations (it doesn't inherit from the WorkTypeBaseDTO).
    /// </summary>
    public class WorkTypeDTO
    {
        public int ID { get; set; }
        public int? WorkCategoryID { get; set; }
        public int? ParentID { get; set; }
        public string Designation { get; set; }

        public WorkTypeDTO(int iD, int? workCategoryID, int? parentID, string designation)
        {
            ID = iD;
            WorkCategoryID = workCategoryID;
            ParentID = parentID;
            Designation = designation;
        }
    }
}
