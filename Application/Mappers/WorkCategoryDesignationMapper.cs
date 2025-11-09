using Domain.Entities;
using DTO.Works.WorkCategoryDesignations;
using System;

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

        public static WorkCategoryDesignation UpdateDtoToDomain(WorkCategoryDesignationUpdateDTO workCat)
        {
            if (workCat == null) throw new ArgumentNullException(nameof(workCat) + "not found!");

            return new WorkCategoryDesignation
            (
                workCat.ID,
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
