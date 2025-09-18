using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkCategoryNames
{
    /// <summary>
    /// A base data transfer object (DTO) that contains common properties
    /// for creating and updating a work category name.
    /// </summary>
    internal class WorkCategoryNameBaseDTO
    {
        public string Name { get; set; }

        public WorkCategoryNameBaseDTO(string name)
        {
            Name = name;
        }
    }
}
