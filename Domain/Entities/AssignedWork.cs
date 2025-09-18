using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{    
    /// <summary>
    /// A domain entity representing the assignment of a WorkSpec to a Subcontractor.
    /// This is a one-to-one relationship.
    /// </summary>
    public class AssignedWork
    {
        internal int ID { get; private set; }
        internal int WorkSpec_ID { get; private set; }
        internal int Subcontractor_ID { get; private set; }
        internal double AssignedQuantity { get; private set; }
        internal DateTime AssignedDate { get; private set; }
        internal decimal NegotiatedUnitPrice { get; private set; }
        internal byte Progress { get; private set; }
        internal AssignedWorkStatus Status { get; private set; }

        // Audit
        internal DateTime CreationDate { get; private set; }
        internal int CreatedBy { get; private set; }
        internal DateTime ModificationDate { get; private set; }
        internal int ModifiedBy { get; private set; }

        public AssignedWork(int id, int workSpec_ID, int subcontractor_ID, double assignedQuantity, DateTime assignedDate, decimal negotiatedUnitPrice, byte progress, AssignedWorkStatus status, int createdBy)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            if (workSpec_ID <= 0)
            {
                throw new ArgumentException("WorkSpec_ID must be greater than zero.", nameof(workSpec_ID));
            }
            if (subcontractor_ID <= 0)
            {
                throw new ArgumentException("Subcontractor_ID must be greater than zero.", nameof(subcontractor_ID));
            }
            if (progress > 100)
            {
                throw new ArgumentException("Progress cannot exceed 100%.", nameof(progress));
            }

            ID = id;
            WorkSpec_ID = workSpec_ID;
            Subcontractor_ID = subcontractor_ID;
            AssignedQuantity = assignedQuantity;
            AssignedDate = assignedDate;
            NegotiatedUnitPrice = negotiatedUnitPrice;
            Progress = progress;
            Status = status;
            CreationDate = DateTime.Now;
            CreatedBy = createdBy;
            ModificationDate = DateTime.Now;
            ModifiedBy = createdBy;
        }

        /// <summary>
        /// Updates the AssignedWork's properties and modification details.
        /// </summary>
        public void Update(double assignedQuantity, DateTime assignedDate, decimal negotiatedUnitPrice, byte progress, AssignedWorkStatus status, int modifiedBy)
        {
            if (progress > 100)
            {
                throw new ArgumentException("Progress cannot exceed 100%.", nameof(progress));
            }

            AssignedQuantity = assignedQuantity;
            AssignedDate = assignedDate;
            NegotiatedUnitPrice = negotiatedUnitPrice;
            Progress = progress;
            Status = status;
            ModificationDate = DateTime.Now;
            ModifiedBy = modifiedBy;
        }
    }

}
