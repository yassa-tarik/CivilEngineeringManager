using Domain.Entities;
using DTO.Works.AssignedWorks;
using System;

namespace MyApplication.Mappers
{
    internal class AssignedWorkMapper
    {
        public static AssignedWorkUpdateDTO DomainToDto(AssignedWork assignedWork)
        {
            if (assignedWork == null) throw new ArgumentNullException(nameof(assignedWork) + "not found!");

            return new AssignedWorkUpdateDTO
            (
                 id: assignedWork.ID,
                 workSpec_ID: assignedWork.WorkSpec_ID,
                 subcontractor_ID: assignedWork.Subcontractor_ID,
                 negotiatedUnitPrice: assignedWork.NegotiatedUnitPrice,
                 assignedQuantity: assignedWork.AssignedQuantity,
                 assignedDate: assignedWork.AssignedDate,
                 producedQuantity: assignedWork.ProducedQuantity,
                 progress: assignedWork.Progress,
                 status: assignedWork.Status,
                 endDate: assignedWork.EndDate,
                 isActive: assignedWork.IsActive,
                 isDeleted: assignedWork.IsDeleted
            );
        }
    }
}
