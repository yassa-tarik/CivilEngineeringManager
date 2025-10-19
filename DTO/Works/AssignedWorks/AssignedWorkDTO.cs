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
        public int ID { get; set; }
        public int WorkSpec_ID { get; set; }
        public int Subcontractor_ID { get; set; }
        public double AssignedQuantity { get; set; }
        public DateTime AssignedDate { get; set; }
        public decimal NegotiatedUnitPrice { get; set; }
        public byte Progress { get; set; }
        public AssignedWorkStatus Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the AssignedWorkDTO class.
        /// </summary>
        public AssignedWorkDTO(int id, int workSpec_ID, int subcontractor_ID, double assignedQuantity, DateTime assignedDate, decimal negotiatedUnitPrice, byte progress, AssignedWorkStatus status)
        {
            ID = id;
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
