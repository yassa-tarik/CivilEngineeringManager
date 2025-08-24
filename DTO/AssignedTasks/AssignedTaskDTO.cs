using DTO.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AssignedTasks
{
    public enum AssignedTaskStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }
    internal class AssignedTaskDTO : TaskBaseDTO
    {
        // Link back to catalog task
        public int TaskID { get; private set; }
        public int SubcontractorID { get; }
        public double AssignedQuantity { get; }
        public DateTime AssignedDate { get; }
        public decimal? NegotiatedUnitPrice { get; private set; }
        public decimal AssignedAmount => (NegotiatedUnitPrice ?? UnitPrice) * (decimal)AssignedQuantity;
        public AssignedTaskStatus Status { get; set; } = AssignedTaskStatus.Pending;
        public AssignedTaskDTO(int id, string designation, string unit, decimal        unitPrice, double quantity, string vat, DateTime creationDate, int createdBy,
            int subcontractorID, double assignedQuantity, DateTime assignedDate)
            : base(id, designation, unit, unitPrice, quantity, vat, creationDate, createdBy)
        {
            SubcontractorID = subcontractorID;
            AssignedQuantity = assignedQuantity;
            AssignedDate = assignedDate;
        }
    }
}
