using Domain.Entities;
using DTO.Projects;
using DTO.Works.WorkCategories;
using System;

namespace MyApplication.Mappers
{
    internal class WorkCategoryMapper
    {
        public static WorkCategoryDTO DomainToDto(WorkCategory workCat)
        {
            if (workCat == null) throw new ArgumentNullException(nameof(workCat) + "not found!");
           
            return new WorkCategoryDTO
            (
                workCat.ID,
                workCat.Project_ID,
                workCat.WorkCategoryName_ID,
                workCat.WorkCategoryName
            );
        }
    }
}
