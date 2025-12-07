using Common.Enums;
using System;

namespace DTO.Works.AssignedWorks
{
    /// <summary>
    /// A data transfer object (DTO) for AssignedWork details,
    /// used to transfer data between the service and UI layers.
    /// </summary>
    public class AssignedWorkDTO
    {
        internal int ID { get; private set; }
        internal int WorkSpec_ID { get; private set; }
        internal int Subcontractor_ID { get; private set; }
        internal decimal NegotiatedUnitPrice { get; private set; }
        internal double AssignedQuantity { get; private set; } = 0;
        internal DateTime AssignedDate { get; private set; }
        internal double ProducedQuantity { get; private set; } = 0;

        internal byte Progress { get; private set; }
        internal AssignedWorkStatus Status { get; private set; }
        internal DateTime EndDate { get; private set; }
        internal bool IsActive { get; private set; }
        internal bool IsDeleted { get; private set; }

        /// <summary>
        /// Initializes a new instance of the AssignedWorkDTO class.
        /// </summary>
        public AssignedWorkDTO(int iD, int workSpec_ID, int subcontractor_ID, decimal negotiatedUnitPrice, double assignedQuantity, DateTime assignedDate, double producedQuantity, byte progress, AssignedWorkStatus status, DateTime endDate, bool isActive, bool isDeleted)
        {
            ID = iD;
            WorkSpec_ID = workSpec_ID;
            Subcontractor_ID = subcontractor_ID;
            NegotiatedUnitPrice = negotiatedUnitPrice;
            AssignedQuantity = assignedQuantity;
            AssignedDate = assignedDate;
            ProducedQuantity = producedQuantity;
            Progress = progress;
            Status = status;
            EndDate = endDate;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }
    }
}
