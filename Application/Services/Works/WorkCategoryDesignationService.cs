using Application.Mappers;
using Domain.Abstractions.Works;
using Domain.Entities;
using DTO.Works.WorkCategories;
using DTO.Works.WorkCategoryDesignations;
using MyApplication.Abstractions.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Services.Works
{
    public class WorkCategoryDesignationService : IWorkCategoryDesignationService
    {
        private readonly IWorkCategoryDesignationRepository _workCategoryDesignationRepo;

        public WorkCategoryDesignationService(IWorkCategoryDesignationRepository workCategoryDesignationRepo)
        {
            _workCategoryDesignationRepo = workCategoryDesignationRepo;
        }

        public bool isExistsByName(string designation)
        {
            return _workCategoryDesignationRepo.isDesignationExists(designation);
        }

        //done
        public async Task<int> AddAsync(WorkCategoryDesignationCreateDTO category)
        {
            if (category == null) throw new ArgumentNullException("no data!");
            if (_workCategoryDesignationRepo.isDesignationExists(category.Designation))
                throw new ArgumentNullException("Already exists!");
            WorkCategoryDesignation workCatDesign = WorkCategoryDesignationMapper.CreateDtoToDomain(category);
            return await _workCategoryDesignationRepo.AddNewAsync(workCatDesign);
        }

        //done
        public async Task<bool> UpdateAsync(WorkCategoryDesignationUpdateDTO category)
        {
            if (category == null) throw new ArgumentNullException("no data!");
            var existing = await _workCategoryDesignationRepo.GetByIdAsync(category.ID) ?? throw new ArgumentNullException("Already exists!");
            existing.Update(category.ID, category.Designation);
            return await _workCategoryDesignationRepo.UpdateAsync(existing);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Done
        /// <summary>
        /// Retrieves all WorkCategoryDesignations and converts them into a Dictionary 
        /// where the key is the WorkCategoryDesignation.ID.
        /// </summary>
        /// <returns>A Dictionary<int, WorkCategoryDesignation>.</returns>
        public async Task<Dictionary<int, WorkCategoryDesignationUpdateDTO>> GetAllAsync()
        {
            //await Task.Delay(5000); // for test purposes

            List<WorkCategoryDesignation> list = await _workCategoryDesignationRepo.GetAllAsync();

            Dictionary<int, WorkCategoryDesignationUpdateDTO> dictionary = list
                .ToDictionary(
                    keySelector: wc => wc.ID,
                    elementSelector: (wc) => WorkCategoryDesignationMapper.DomainToUpdateDto(wc)
                );
            return dictionary;
        }

        public async Task<WorkCategoryDesignationUpdateDTO> GetByIdAsync(int id)
        {
            var workCatDesign = await _workCategoryDesignationRepo.GetByIdAsync(id);
            WorkCategoryDesignationUpdateDTO workCatDesignUpdateDTO = WorkCategoryDesignationMapper.DomainToUpdateDto(workCatDesign);
            return workCatDesignUpdateDTO;
        }

        public Task UpdateAsync(WorkCategoryDTO category)
        {
            throw new NotImplementedException();
        }
        //******************** Mock data ***********************
        //public Dictionary<int, string> GetAll()
        //{
        //    var mockWorkCategoriesDictionary = new Dictionary<int, string>
        //    {
        //        { 1, "Development" },
        //        { 2, "Marketing" },
        //        { 3, "Design" },
        //        { 4, "Sales" },
        //        { 5, "Customer Support" }
        //    };
        //    return mockWorkCategoriesDictionary;
        //}


    }
}
