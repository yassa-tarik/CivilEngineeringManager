using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ProjectRepository : IProjectRepository
    {

        public Task<Project> AddAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> FindAllFullAsync()
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAllMinimal()
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> FindAllMinimalAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetByID(int projectID)
        {
            throw new NotImplementedException();
        }

        public bool IsProjectExist(int ID)
        {
            throw new NotImplementedException();
        }

        public bool IsProjectExistByName(string projectName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveProjectWithAddressAsync(Project project, Address address)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> SearchProjectsAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Project project)
        {
            throw new NotImplementedException();
        }

        //******************************* Mock Data *****************************
        /*
        private readonly List<Project> _projects;
        private readonly IAddressRepository _addressRepository;
        private int _nextId = 4;

        public MockProjectRepository(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            _projects = new List<Project>
        {
            new Project(1, "Project Alpha", "PA-001", DateTime.Now.AddMonths(-6), 12, "Commercial", "Office building construction.", true, "LandReg-1", "SubPermit-A", DateTime.Now.AddMonths(-7), "ConstPermit-X", DateTime.Now.AddMonths(-7), "DeedVol-1", "DeedNum-1", "DeedFolio-1", "LandBook-1", DateTime.Now.AddMonths(-7), "Admin", true, 90, 1, DateTime.Now.AddMonths(-8), 1, DateTime.Now.AddDays(-1), 1, false),
            new Project(2, "Project Beta", "PB-002", DateTime.Now.AddMonths(-8), 18, "Residential", "New housing subdivision.", true, "LandReg-2", "SubPermit-B", DateTime.Now.AddMonths(-9), "ConstPermit-Y", DateTime.Now.AddMonths(-9), "DeedVol-2", "DeedNum-2", "DeedFolio-2", "LandBook-2", DateTime.Now.AddMonths(-9), "Admin", false, 45, 2, DateTime.Now.AddMonths(-10), 1, DateTime.Now.AddDays(-2), 1, false),
            new Project(3, "Project Gamma", "PG-003", DateTime.Now.AddMonths(-12), 24, "Industrial", "Warehouse renovation.", true, "LandReg-3", "SubPermit-C", DateTime.Now.AddMonths(-13), "ConstPermit-Z", DateTime.Now.AddMonths(-13), "DeedVol-3", "DeedNum-3", "DeedFolio-3", "LandBook-3", DateTime.Now.AddMonths(-13), "Admin", true, 100, 3, DateTime.Now.AddMonths(-14), 1, DateTime.Now.AddDays(-3), 1, false)
        };
        }

        public Task<IEnumerable<Project>> FindAllAsync()
        {
            return Task.Run(() => (IEnumerable<Project>)_projects);
        }

        public Task<Project> FindById(int projectId)
        {
            return Task.Run(() => _projects.FirstOrDefault(p => p.ID == projectId));
        }

        public Task<IEnumerable<Project>> SearchProjectsAsync(string searchTerm)
        {
            return Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return _projects;
                }

                var normalizedSearchTerm = searchTerm.ToLower();
                return _projects.Where(p =>
                    p.Name.ToLower().Contains(normalizedSearchTerm) ||
                    p.ProjectCode.ToLower().Contains(normalizedSearchTerm) ||
                    p.ProjectType.ToLower().Contains(normalizedSearchTerm));
            });
        }

        public Task<Project> AddAsync(Project project)
        {
            return Task.Run(() =>
            {
                project.ID = _nextId++;
                _projects.Add(project);
                return project;
            });
        }

        public Task UpdateAsync(Project project)
        {
            return Task.Run(() =>
            {
                var existingProject = _projects.FirstOrDefault(p => p.ID == project.ID);
                if (existingProject != null)
                {
                    _projects.Remove(existingProject);
                    _projects.Add(project);
                }
            });
        }

        public Task DeleteAsync(int projectId)
        {
            return Task.Run(() =>
            {
                var projectToDelete = _projects.FirstOrDefault(p => p.ID == projectId);
                if (projectToDelete != null)
                {
                    _projects.Remove(projectToDelete);
                }
            });
        }

        public async Task<Project> SaveProjectWithAddressAsync(Project project, Address address)
        {
            var addedAddress = await _addressRepository.AddAsync(address);
            project.SetAddressId(addedAddress.ID);
            var addedProject = await AddAsync(project);
            return addedProject;
        }
        */

    }
}
