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
        public AssignedWorkUpdateDTO(int id, int workSpec_ID, int subcontractor_ID, decimal negotiatedUnitPrice, double assignedQuantity, DateTime assignedDate, double producedQuantity, byte progress, AssignedWorkStatus status, DateTime endDate, bool isActive, bool isDeleted) : base(workSpec_ID, subcontractor_ID, negotiatedUnitPrice, assignedQuantity, assignedDate, producedQuantity, progress, status, endDate, isActive, isDeleted)
        {
            ID = id;
        }
    }
}
