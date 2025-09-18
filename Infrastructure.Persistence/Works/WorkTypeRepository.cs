using Domain.Abstractions.Works;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Works
{
    public class WorkTypeRepository : IWorkTypeRepository
    {
        public Task<WorkType> AddAsync(WorkType type)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkType>> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<WorkType>>(_workTypes);
        }

        public Task<WorkType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WorkType type)
        {
            throw new NotImplementedException();
        }
        //********************* Mock data **************************
        private readonly List<WorkType> _workTypes;

        public WorkTypeRepository()
        {
            _workTypes = new List<WorkType>
        {
            // Construction Category (WorkCategory_ID = 1)
            new WorkType(id: 1, workCategory_ID: 1, parent_ID: null, designation: "Foundations", createdBy: 10),
            new WorkType(id: 2, workCategory_ID: 1, parent_ID: 1, designation: "Poured Concrete", createdBy: 10),
            new WorkType(id: 3, workCategory_ID: 1, parent_ID: 1, designation: "Steel Reinforcement", createdBy: 10),
            
            // IT and Technology Category (WorkCategory_ID = 2)
            new WorkType(id: 4, workCategory_ID: 2, parent_ID: null, designation: "Software Development", createdBy : 10),
            new WorkType(id: 5, workCategory_ID: 2, parent_ID: 4, designation: "Frontend", createdBy : 10),
            new WorkType(id: 6, workCategory_ID: 2, parent_ID: 4, designation: "Backend", createdBy : 10),
            new WorkType(id: 7, workCategory_ID: 2, parent_ID: 5, designation: "React", createdBy : 10),
            new WorkType(id: 8, workCategory_ID: 2, parent_ID: 5, designation: "Angular", createdBy : 10),
            
            // Marketing Category (WorkCategory_ID = 3)
            new WorkType(id: 9, workCategory_ID: 3, parent_ID: null, designation: "Digital Campaigns", createdBy : 10),
            new WorkType(id: 10, workCategory_ID: 3, parent_ID: 9, designation: "PPC", createdBy : 10),
            new WorkType(id: 11, workCategory_ID: 3, parent_ID: 9, designation: "Social Media", createdBy : 10)
        };
        }
    }
}
