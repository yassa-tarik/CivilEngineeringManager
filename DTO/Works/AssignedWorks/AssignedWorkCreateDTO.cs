using Common.Enums;
using System;

namespace DTO.Works.AssignedWorks
{
    /// <summary>
    /// A data transfer object (DTO) used to create a new assigned work record.
    /// It inherits all properties from the base DTO.
    /// </summary>
    public class AssignedWorkCreateDTO : AssignedWorkBaseDTO
    {
        /// <summary>
        /// Initializes a new instance of the AssignedWorkCreateDTO class.
        /// </summary>
        public AssignedWorkCreateDTO(int workSpec_ID, int subcontractor_ID, double assignedQuantity, DateTime assignedDate, decimal negotiatedUnitPrice, byte progress, AssignedWorkStatus status)
            : base(workSpec_ID, subcontractor_ID, assignedQuantity, assignedDate, negotiatedUnitPrice, progress, status)
        {
        }
    }
}
