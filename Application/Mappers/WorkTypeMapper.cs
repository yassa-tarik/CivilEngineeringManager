using Domain.Entities;
using DTO.TreeDTOs;
using DTO.Works.WorkTypes;
using System;

namespace MyApplication.Mappers
{
    internal class WorkTypeMapper
    {
        public static WorkTypeDTO DomainToDto(WorkType workType)
        {
            if (workType == null) throw new ArgumentNullException(nameof(workType) + "not found!");

            return new WorkTypeDTO
            (
                 workType.ID,
                 workType.WorkCategory_ID,
                 workType.Parent_ID,
                 workType.Designation
            );
        }

        public static WorkTypeDTO TreeDtoToDTO(WorkTypeTreeDTO typeTreeDto)
        {
            if (typeTreeDto == null) throw new ArgumentNullException(nameof(typeTreeDto) + "not found!");

            return new WorkTypeDTO
            (
                 typeTreeDto.ID,
                 typeTreeDto.WorkCategory_ID,
                 typeTreeDto.Parent_ID,
                 typeTreeDto.Designation
            );
        }

        public static WorkTypeUpdateDTO TreeDtoToUpdateDTO(WorkTypeTreeDTO typeTreeDto)
        {
            if (typeTreeDto == null) throw new ArgumentNullException(nameof(typeTreeDto) + "not found!");

            return new WorkTypeUpdateDTO
            (
                 typeTreeDto.ID,
                 typeTreeDto.WorkCategory_ID,
                 typeTreeDto.Parent_ID,
                 typeTreeDto.Designation
            );
        }

        public static WorkTypeCreateDTO TreeDtoToCreateDTO(WorkTypeTreeDTO typeTreeDto)
        {
            if (typeTreeDto == null) throw new ArgumentNullException(nameof(typeTreeDto) + "not found!");

            return new WorkTypeCreateDTO
            (
                 typeTreeDto.WorkCategory_ID,
                 typeTreeDto.Parent_ID,
                 typeTreeDto.Designation
            );
        }
        // Map Create DTO to Domain Entity
        public static WorkType CreateDtoToDomain(WorkTypeCreateDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return new WorkType(
                workCategory_ID: dto.WorkCategory_ID,
                parent_ID: dto.Parent_ID,
                designation: dto.Designation
            );
        }
    }
}
