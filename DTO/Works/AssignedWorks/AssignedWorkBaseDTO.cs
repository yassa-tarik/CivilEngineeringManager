using Common.Enums;
using System;

namespace DTO.Works.AssignedWorks
{
    /// <summary>
    /// A base data transfer object (DTO) for common properties of AssignedWork.
    /// </summary>
    public abstract class AssignedWorkBaseDTO
    {
        public int WorkSpec_ID { get; }
        public int Subcontractor_ID { get; }
        public double AssignedQuantity { get; }
        public DateTime AssignedDate { get; }
        public decimal NegotiatedUnitPrice { get; }
        public byte Progress { get; }
        public AssignedWorkStatus Status { get; }

        /// <summary>
        /// Initializes a new instance of the AssignedWorkBaseDTO class.
        /// </summary>
        public AssignedWorkBaseDTO(int workSpec_ID, int subcontractor_ID, double assignedQuantity, DateTime assignedDate, decimal negotiatedUnitPrice, byte progress, AssignedWorkStatus status)
        {
            WorkSpec_ID = workSpec_ID;
            Subcontractor_ID = subcontractor_ID;
            AssignedQuantity = assignedQuantity;
            AssignedDate = assignedDate;
            NegotiatedUnitPrice = negotiatedUnitPrice;
            Progress = progress;
            Status = status;
        }
    }
}
