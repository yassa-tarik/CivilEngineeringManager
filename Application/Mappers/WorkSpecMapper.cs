using Domain.Entities;
using DTO.Works.WorkSpecs;
using System;

namespace MyApplication.Mappers
{
    internal static class WorkSpecMapper
    {
        public static WorkSpecUpdateDTO DomainToDto(WorkSpec workSpec)
        {
            if (workSpec == null) throw new ArgumentNullException(nameof(workSpec) + "not found!");

            return new WorkSpecUpdateDTO
            (
                 workSpec.ID,
                 workSpec.WorkCategory_ID,
                 workSpec.WorkType_ID,
                 workSpec.Designation,
                 workSpec.Unit,
                 workSpec.UnitPrice,
                 workSpec.Quantity,
                 workSpec.VAT
            );
        }

        // Map Create DTO to Domain Entity
        public static WorkSpec CreateDtoToDomain(WorkSpecCreateDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return new WorkSpec(
                workCategory_ID: dto.WorkCategory_ID,
                workType_ID: dto.WorkType_ID,
                designation: dto.Designation,
                unit: dto.Unit,
                unitPrice: dto.UnitPrice,
                quantity: dto.Quantity,
                vat: dto.VAT         
            );
        }
        public static WorkSpecCreateDTO UpdateDtoToCreateDto(WorkSpecUpdateDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return new WorkSpecCreateDTO(
                workCategory_ID: dto.WorkCategory_ID,
                workType_ID: dto.WorkType_ID,
                designation: dto.Designation,
                unit: dto.Unit,
                unitPrice: dto.UnitPrice,
                quantity: dto.Quantity,
                vAT: dto.VAT
            );
        }
    }
}
