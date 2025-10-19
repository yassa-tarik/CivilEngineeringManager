using Domain.Entities;
using DTO.TreeDTOs;
using DTO.Works.WorkCategories;
using System;

namespace MyApplication.Mappers
{
    internal static class WorkCategoryMapper
    {
        public static WorkCategoryDTO DomainToGeneralDto(WorkCategory workCat, WorkCategoryDesignation categoryDesignation)
        {
            if (workCat == null) throw new ArgumentNullException(nameof(workCat) + "empty data!");
            if (categoryDesignation == null) throw new ArgumentNullException(nameof(workCat) + "empty data!");

            return new WorkCategoryDTO
            (
                workCat.ID,
                workCat.Project_ID,
                workCat.WorkCategoryDesignation_ID,
                categoryDesignation.Designation
            );
        }
        public static WorkCategoryDTO TreeDtoToDTO(WorkCategoryTreeDTO workCatTree)
        {
            if (workCatTree == null) throw new ArgumentNullException(nameof(workCatTree) + "not found!");

            return new WorkCategoryDTO
            (
                workCatTree.ID,
                workCatTree.Project_ID,
                workCatTree.WorkCategoryDesignation_ID,
                workCatTree.Designation
            );
        }

        public static WorkCategoryUpdateDTO TreeDtoToUpdateDTO(WorkCategoryTreeDTO workCatTree)
        {
            if (workCatTree == null) throw new ArgumentNullException(nameof(workCatTree) + "not found!");

            return new WorkCategoryUpdateDTO
            (
                workCatTree.ID,
                workCatTree.Project_ID,
                workCatTree.WorkCategoryDesignation_ID,
                workCatTree.Designation
            );
        }


        public static WorkCategoryCreateDTO TreeDtoToCreateDTO(WorkCategoryTreeDTO workCatTree)
        {
            if (workCatTree == null) throw new ArgumentNullException(nameof(workCatTree) + "not found!");

            return new WorkCategoryCreateDTO
            (
                workCatTree.Project_ID,
                workCatTree.WorkCategoryDesignation_ID,
                workCatTree.Designation
            );
        }


        public static WorkCategory CreateDtoToDomain(WorkCategoryCreateDTO workCat)
        {
            if (workCat == null) throw new ArgumentNullException(nameof(workCat) + "not found!");

            return new WorkCategory
            (
                workCat.Project_ID,
                workCat.WorkCategoryDesignation_ID                
            );
        }       
    }
}
