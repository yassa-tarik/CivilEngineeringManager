using Domain.Abstractions.Works;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Works
{
    public class WorkCategoryRepository : IWorkCategoryRepository
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

        public Task <IEnumerable<WorkCategory>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<WorkCategory>>(_categories);
        }

        public Task<WorkCategory> AddAsync(WorkCategory category)
        {
            throw new NotImplementedException();
            //category.ID = _nextId++;
            //_workCategories.Add(category);
            //return Task.FromResult(category);
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

        // ********************** Mock Data ****************************

        private readonly List<WorkCategory> _categories;
        public WorkCategoryRepository()
        {
            _categories = new List<WorkCategory>
            {
                new WorkCategory(id: 1, project_ID: 101, workCategoryName_ID: 1, workCategoryName: "Construction", createdBy:10 ),
                new WorkCategory(id: 2, project_ID: 101, workCategoryName_ID: 2, workCategoryName: "IT and Technology",createdBy:10 ),
                new WorkCategory(id: 3, project_ID: 102, workCategoryName_ID: 3, workCategoryName: "Marketing",createdBy:10 )
            };
        }
    }
}
