using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkCategoryNames
{
    /// <summary>
    /// A data transfer object (DTO) that represents a work category name for read-only operations.
    /// </summary>
    public class WorkCategoryNameDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
