using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkSpecs
{
    /// <summary>
    /// A data transfer object (DTO) used to update an existing work specification.
    /// Inherits common properties from WorkSpecBaseDTO and adds an ID.
    /// </summary>
    public class WorkSpecUpdateDTO : WorkSpecBaseDTO
    {
        public int ID { get; set; }

        /// <summary>
        /// Initializes a new instance of the WorkSpecUpdateDTO with all properties,
        /// including a call to the base constructor.
        /// </summary>
        public WorkSpecUpdateDTO(int id, int? workCategoryID, int? workTypeID, string designation, string unit, decimal unitPrice, double quantity, string vAT)
            : base(workCategoryID, workTypeID, designation, unit, unitPrice, quantity, vAT)
        {
            ID = id;
        }
    }
}
