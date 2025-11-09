using Domain.Abstractions.Works;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.MockData
{
    internal class MockWorkCategoryRepo : IWorkCategoryRepository
    {
        // This in-memory list simulates a database table.
        // In a real application, this would be replaced with a database context (e.g., DbContext in Entity Framework).
        private readonly List<WorkCategory> _workCategories;
        private int _nextId = 1;

        //public WorkCategoryRepository()
        //{
        ////    _workCategories = new List<WorkCategory>
        ////{
        ////    new WorkCategory { ID = _nextId++, Name = "Architectural", Description = "Services related to architectural plans and design." },
        ////    new WorkCategory { ID = _nextId++, Name = "Electrical", Description = "Services related to electrical systems." },
        ////    new WorkCategory { ID = _nextId++, Name = "Plumbing", Description = "Services related to plumbing and drainage." }
        ////};
        //}

        public Task<WorkCategory> GetByIdAsync(int id)
        {
            var category = _workCategories.FirstOrDefault(c => c.ID == id);
            return Task.FromResult(category);
        }

        public Task<IEnumerable<WorkCategory>> GetAllForProjectAsync()
        {
            return Task.FromResult<IEnumerable<WorkCategory>>(_categories);
        }

        public Task<int> AddNewAsync(WorkCategory category)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WorkCategory category)
        {
            throw new NotImplementedException();
            //var existingCategory = _workCategories.FirstOrDefault(c => c.ID == category.ID);
            //if (existingCategory != null)
            //{
            //    existingCategory.Name = category.Name;
            //    existingCategory.Description = category.Description;
            //}
            //return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var categoryToRemove = _workCategories.FirstOrDefault(c => c.ID == id);
            if (categoryToRemove != null)
            {
                _workCategories.Remove(categoryToRemove);
            }
            return Task.CompletedTask;
        }

        Task<int> IWorkCategoryRepository.UpdateAsync(WorkCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkCategory>> GetAllWorkCategoriesForProjectAsync(int projectID)
        {
            throw new NotImplementedException();
        }

        // ********************** Mock Data ****************************

        private readonly List<WorkCategory> _categories;
        public MockWorkCategoryRepo()
        {
            /*_categories = new List<WorkCategory>
            {
                new WorkCategory(id: 1, project_ID: 101, workCategoryDesignation_ID: 1 ),
                new WorkCategory(id: 2, project_ID: 101, workCategoryDesignation_ID: 2),
                new WorkCategory(id: 3, project_ID: 102, workCategoryDesignation_ID: 3 )
            }; */
        }
    }
}
