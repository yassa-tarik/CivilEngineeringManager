using MyApplication.Abstractions.Works;
using DTO.Works.WorkCategories;
using DTO.Works.WorkCategoryNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services.Works
{
    public class WorkCategoryNameService : IWorkCategoryNameService
    {
        public Task<WorkCategoryDTO> AddAsync(WorkCategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> GetAllAsync()
        {
            return GetAll();
        }

        public Task<WorkCategoryDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WorkCategoryDTO category)
        {
            throw new NotImplementedException();
        }
        //******************** Mock data ***********************
        public Dictionary<int, string> GetAll()
        {
            var mockWorkCategoriesDictionary = new Dictionary<int, string>
            {
                { 1, "Development" },
                { 2, "Marketing" },
                { 3, "Design" },
                { 4, "Sales" },
                { 5, "Customer Support" }
            };
            return mockWorkCategoriesDictionary;
        }
    }
}
