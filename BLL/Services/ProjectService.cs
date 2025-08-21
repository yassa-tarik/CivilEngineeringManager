using BLL.Interfaces;
using BLL.Mappers.Projects;
using DAL.Interfaces;
using DTO.Project;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        public ProjectService(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<List<ProjectDTO>> GetAllFullAsync()
        {
            var entities = await _projectRepo.GetAllFullAsync();
            return entities.ConvertAll(ProjectMapper.EntityToDTO);
        }
        public async Task<List<ProjectMinimalDTO>> GetAllMinimalProjectsAsync()
        {
            return await _projectRepo.GetAllMinimalAsync();
        }

        public void AddProject(ProjectDTO dto)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(ProjectDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
