using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkSpecs
{
    /// <summary>
    /// A data transfer object (DTO) used to create a new work specification.
    /// Inherits common properties from WorkSpecBaseDTO.
    /// </summary>
    public class WorkSpecCreateDTO : WorkSpecBaseDTO
    {
        public WorkSpecCreateDTO(int? workCategoryID, int? workTypeID, string designation, string unit, decimal unitPrice, double quantity, string vAT)
            : base(workCategoryID, workTypeID, designation, unit, unitPrice, quantity, vAT)
        {
        }
    }
}
