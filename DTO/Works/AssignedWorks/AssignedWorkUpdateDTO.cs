using Common.Enums;
using System;

namespace DTO.Works.AssignedWorks
{
    /// <summary>
    /// A data transfer object (DTO) used to update an existing assigned work record.
    /// It inherits properties from the base DTO and adds an ID.
    /// </summary>
    public class AssignedWorkUpdateDTO : AssignedWorkBaseDTO
    {
        public int ID { get; }

        /// <summary>
        /// Initializes a new instance of the AssignedWorkUpdateDTO class.
        /// </summary>
        public AssignedWorkUpdateDTO(int id, int workSpec_ID, int subcontractor_ID, double assignedQuantity, DateTime assignedDate, decimal negotiatedUnitPrice, byte progress, AssignedWorkStatus status)
            : base(workSpec_ID, subcontractor_ID, assignedQuantity, assignedDate, negotiatedUnitPrice, progress, status)
        {
            ID = id;
        }
    }
}
