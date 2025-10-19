using Domain.Entities;
using DTO.Works.WorkCategories;
using DTO.Works.WorkCategoryDesignations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    internal static class WorkCategoryDesignationMapper
    {
        public static WorkCategoryDesignation CreateDtoToDomain(WorkCategoryDesignationCreateDTO workCat)
        {
            if (workCat == null) throw new ArgumentNullException(nameof(workCat) + "not found!");

            return new WorkCategoryDesignation
            (
                workCat.Designation
            );
        }

        public static WorkCategoryDesignationUpdateDTO DomainToUpdateDto(WorkCategoryDesignation workCat)
        {
            if (workCat == null) throw new ArgumentNullException(nameof(workCat) + "not found!");

            return new WorkCategoryDesignationUpdateDTO
            (
                workCat.ID,
                workCat.Designation
            );
        }
    }
}
