using BLL.Interfaces;
using BLL.Services;
using DAL.Database;
using DAL.Interfaces;
using DAL.Pepositories;
using DAL.Repositories;
using DTO.Subcontractor;
using System;

namespace Composition
{
    public static class DependencyBuilder
    {
        private static string _connectionString;

        /// <summary>
        /// Call this method once at startup to set the DB connection string.
        /// </summary>
        public static void InitializeDB_Connection()
        {
            string connectionString = SqlConnectionFactory.connectionString;
            if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException("Invalid database connection " +
                        "");
                }
            _connectionString = connectionString;
        }

        /// <summary>
        /// Builds a ready-to-use ISubcontractorService with repository injected.
        /// </summary>
        public static ISubcontractorService BuildSubcontractorService()
        {            
            ISubcontractorRepository subcontractorRepo = new SubcontractorRepository(_connectionString);
            return new SubcontractorService(subcontractorRepo);
        }

        /// <summary>
        /// Builds a ready-to-use IProjectService (if needed).
        /// </summary>
        public static IProjectService BuildProjectService()
        {
            IProjectRepository projectRepo = new ProjectRepository(_connectionString);
            return new ProjectService(projectRepo);
        }

        /// <summary>
        /// Add other services similarly...
        /// </summary>
        public static ITaskService BuildTaskService()
        {
            ITaskRepository taskRepo = new TaskRepository(_connectionString);
            return new TaskService(taskRepo);
        }

        /// <summary>
        /// Optional: use to generate test data
        /// </summary>
        public static SubcontractorDTO CreateSampleSubcontractor()
        {
            throw new NotImplementedException();
            //return new SubcontractorDTO
            //{
            //    Id = 0,
            //    Name = "ALC-BATIMENT",
            //    MatriculeFiscale = "MF-123456",
            //    CreatedAt = DateTime.Now,
            //    Contact = new ContactDTO { Id = 1 },
            //    Address = new AddressDTO { Id = 1 }
            //};
        }

        private static void EnsureInitialized()
        {
            
        }
    }
}
