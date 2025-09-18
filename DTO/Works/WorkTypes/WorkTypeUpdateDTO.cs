using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkTypes
{
    /// <summary>
    /// A data transfer object (DTO) used to update an existing work type.
    /// Inherits common properties from WorkTypeBaseDTO and adds an ID.
    /// </summary>
    public class WorkTypeUpdateDTO : WorkTypeBaseDTO
    {
        public int ID { get; set; }

        public WorkTypeUpdateDTO(int id, int? workCategoryID, int? parentID, string designation)
            : base(workCategoryID, parentID, designation)
        {
            ID = id;
        }
    }
}
