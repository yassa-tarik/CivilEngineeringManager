using Domain.Abstractions.Works;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Works
{
    public class WorkSpecRepository : IWorkSpecRepository
    {
        public Task<WorkSpec> AddAsync(WorkSpec spec)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkSpec>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<WorkSpec>>(_workSpecs);
        }

        public Task<WorkSpec> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WorkSpec spec)
        {
            throw new NotImplementedException();
        }
        //******************* Mock data ********************************
        private readonly List<WorkSpec> _workSpecs;

        public WorkSpecRepository()
        {
            _workSpecs = new List<WorkSpec>
        {
            // WorkType: Poured Concrete (WorkType_ID = 2)
            new WorkSpec(id: 1, workCategory_ID: 2, workType_ID: null, designation: "Standard mix", unit: "Cubic Meter", unitPrice: 120.50m, quantity: 50.0, vat: "20%", createdBy: 10),
            new WorkSpec(id: 2, workCategory_ID: 1, workType_ID: null, designation: "High-strength mix", unit: "Cubic Meter", unitPrice: 150.00m, quantity: 25.0, vat: "20%", createdBy : 10),
            
            // WorkType: Steel Reinforcement (WorkType_ID = 3)
            new WorkSpec(id: 3, workCategory_ID: null, workType_ID: 3, designation: "#4 Rebar", unit: "Tonne", unitPrice: 850.00m, quantity: 10.5, vat: "20%", createdBy : 10),
            new WorkSpec(id: 4, workCategory_ID: null, workType_ID: 3, designation: "Mesh wire", unit: "Square Meter", unitPrice: 5.75m, quantity: 200.0, vat: "20%", createdBy : 10),
            
            // WorkType: React (WorkType_ID = 7)
            new WorkSpec(id: 5, workCategory_ID: 2, workType_ID: null, designation: "Initial component setup", unit: "Hour", unitPrice: 85.00m, quantity: 10.0, vat: "0%", createdBy : 10),
            new WorkSpec(id: 6, workCategory_ID: null, workType_ID: 7, designation: "State management implementation", unit: "Hour", unitPrice: 90.00m, quantity: 20.0, vat: "0%", createdBy : 10),
            
            // WorkType: Angular (WorkType_ID = 8)
            new WorkSpec(id: 7, workCategory_ID : 2, workType_ID: null, designation: "Module creation", unit: "Hour", unitPrice: 85.00m, quantity: 8.0, vat: "0%", createdBy : 10),
            new WorkSpec(id: 8, workCategory_ID : null, workType_ID: 8, designation: "Service and dependency injection", unit: "Hour", unitPrice: 90.00m, quantity: 15.0, vat: "0%", createdBy : 10)
        };
        }
    }
}
