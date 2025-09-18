using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkSpecs
{
    /// <summary>
    /// A base data transfer object (DTO) that contains common properties
    /// for creating and updating a work specification.
    /// </summary>
    public abstract class WorkSpecBaseDTO
    {
        public int? WorkCategoryID { get; }
        public int? WorkTypeID { get; }
        public string Designation { get; }
        public string Unit { get; }
        public decimal UnitPrice { get; }
        public double Quantity { get; }
        public string VAT { get; }

        public WorkSpecBaseDTO(int? workCategoryID, int? workTypeID, string designation, string unit, decimal unitPrice, double quantity, string vAT)
        {
            WorkCategoryID = workCategoryID;
            WorkTypeID = workTypeID;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            VAT = vAT;
        }
    }
}
