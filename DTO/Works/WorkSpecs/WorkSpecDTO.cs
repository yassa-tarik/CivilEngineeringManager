using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkSpecs
{
    /// <summary>
    /// A data transfer object (DTO) that represents a work specification for read-only operations.
    /// </summary>
    public class WorkSpecDTO
    {
        public int ID { get; }
        public int? WorkCategory_ID { get; }
        public int? WorkType_ID { get; }
        public string Designation { get; }
        public string Unit { get; }
        public decimal UnitPrice { get; }
        public double Quantity { get; }
        public string VAT { get; }

        // Computed property: no setter, as its value is always calculated.
        public decimal Amount => UnitPrice * (decimal)Quantity;

        public WorkSpecDTO(int id, int? workCategoryID, int? workTypeID, string designation, string unit, decimal unitPrice, double quantity, string vAT)
        {
            ID = id;
            WorkCategory_ID = workCategoryID;
            WorkType_ID = workTypeID;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            VAT = vAT;
        }
    }
}
