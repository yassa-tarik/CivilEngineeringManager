using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// A domain entity representing a specific work item or task.
    /// It contains detailed pricing and quantity information.
    /// </summary>
    public class WorkSpec
    {
        public int ID { get; private set; }

        // Business properties
        public int? WorkCategory_ID { get; private set; }
        public int? WorkType_ID { get; private set; }
        public string Designation { get; private set; }
        public string Unit { get; private set; }
        public decimal UnitPrice { get; private set; }
        public double Quantity { get; private set; }
        public string VAT { get; private set; }

        // Computed
        public decimal Amount => UnitPrice * (decimal)Quantity;

        // Audit
        public DateTime CreationDate { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int ModifiedBy { get; private set; }

        public WorkSpec(int id, int? workCategory_ID, int? workType_ID, string designation, string unit, decimal unitPrice, double quantity, string vat, int createdBy)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            if (string.IsNullOrWhiteSpace(designation))
            {
                throw new ArgumentException("Designation cannot be null or empty.", nameof(designation));
            }
            if (unitPrice < 0)
            {
                throw new ArgumentException("Unit price cannot be negative.", nameof(unitPrice));
            }

            ID = id;
            WorkCategory_ID = workCategory_ID;
            WorkType_ID = workType_ID;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            VAT = vat;
            CreationDate = DateTime.Now;
            CreatedBy = createdBy;
            ModificationDate = DateTime.Now;
            ModifiedBy = createdBy;
        }

        /// <summary>
        /// Updates the WorkSpec's properties and modification details.
        /// </summary>
        public void Update(int? workCategory_ID, int? workType_ID, string designation, string unit, decimal unitPrice, double quantity, string vat, int modifiedBy)
        {
            if (string.IsNullOrWhiteSpace(designation))
            {
                throw new ArgumentException("Designation cannot be null or empty.", nameof(designation));
            }
            if (unitPrice < 0)
            {
                throw new ArgumentException("Unit price cannot be negative.", nameof(unitPrice));
            }
            WorkCategory_ID = WorkCategory_ID;
            WorkType_ID = workType_ID;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            VAT = vat;
            ModificationDate = DateTime.Now;
            ModifiedBy = modifiedBy;
        }
    }
}
