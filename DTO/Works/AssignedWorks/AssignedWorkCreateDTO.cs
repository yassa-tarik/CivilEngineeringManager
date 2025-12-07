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
        public AssignedWorkCreateDTO(int workSpec_ID, int subcontractor_ID, decimal negotiatedUnitPrice, double assignedQuantity, DateTime assignedDate, double producedQuantity, byte progress, AssignedWorkStatus status, DateTime endDate, bool isActive, bool isDeleted) : base(workSpec_ID, subcontractor_ID, negotiatedUnitPrice, assignedQuantity, assignedDate, producedQuantity, progress, status, endDate, isActive, isDeleted)
        {
        }
    }
}
