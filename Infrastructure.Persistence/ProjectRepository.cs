using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ProjectRepository : DBConnectionStringBaseRepo, IProjectRepository
    {
        public Task DeleteAsync(int projectId)
        {
            throw new NotImplementedException();
        }
        // Done
        public async Task<List<Project>> FindAllFullAsync()
        {
            const string query = @"
                SELECT 
                   p.ID, p.Name, p.ProjectCode, p.StartDate, p.Duration, p.ProjectType, 
                   p.Description, p.IsActive, p.LandRegistry, p.SubdivisionPermitNumber, 
                   p.SubdivisionPermitDate, p.ConstructionPermitNumber, p.ConstructionPermitDate, 
                   p.DeedVolume, p.DeedNumber, p.DeedFolio, p.LandBook, p.LandBookDate, 
                   p.LandBookBy, p.IsSpecCompleted, p.Progress, 
                   p.Country_ID, p.City_ID, p.Municipality, p.PostalCode, p.PlaceName,p.Landmark,
                   p.CreationDate, p.CreatedBy, p.ModificationDate, p.ModifiedBy, p.IsDeleted
                FROM Projects p
                WHERE  p.IsDeleted = 0;";
            List<Project> projects = new List<Project>();
            try
            {
                using (var conn = await OpenConnectionAsync())
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                projects.Add(MapProjectFromReader(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception

                Console.WriteLine($"Error retrieving project by ID: {ex.Message}");
                throw;
            }
            return projects;
        }
        // Done
        private Project MapProjectFromReader(SqlDataReader reader)
        {
            return new Project
            (
                id: reader.GetInt32(reader.GetOrdinal("ID")),
                name: reader.GetString(reader.GetOrdinal("Name")),
                projectCode: reader.GetString(reader.GetOrdinal("ProjectCode")),
                startDate: reader.GetDateTime(reader.GetOrdinal("StartDate")),
                duration: reader.GetInt32(reader.GetOrdinal("Duration")),
                projectType: reader.GetString(reader.GetOrdinal("ProjectType")),
                description: reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                isActive: reader.GetBoolean(reader.GetOrdinal("IsActive")),
                landRegistry: reader.IsDBNull(reader.GetOrdinal("LandRegistry")) ? null : reader.GetString(reader.GetOrdinal("LandRegistry")),
                subdivisionPermitNumber: reader.IsDBNull(reader.GetOrdinal("SubdivisionPermitNumber")) ? null : reader.GetString(reader.GetOrdinal("SubdivisionPermitNumber")),
                subdivisionPermitDate: reader.IsDBNull(reader.GetOrdinal("SubdivisionPermitDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SubdivisionPermitDate")),
                constructionPermitNumber: reader.GetString(reader.GetOrdinal("ConstructionPermitNumber")),
                constructionPermitDate: reader.GetDateTime(reader.GetOrdinal("ConstructionPermitDate")),
                deedVolume: reader.IsDBNull(reader.GetOrdinal("DeedVolume")) ? null : reader.GetString(reader.GetOrdinal("DeedVolume")),
                deedNumber: reader.IsDBNull(reader.GetOrdinal("DeedNumber")) ? null : reader.GetString(reader.GetOrdinal("DeedNumber")),
                deedFolio: reader.IsDBNull(reader.GetOrdinal("DeedFolio")) ? null : reader.GetString(reader.GetOrdinal("DeedFolio")),
                landBook: reader.IsDBNull(reader.GetOrdinal("LandBook")) ? null : reader.GetString(reader.GetOrdinal("LandBook")),
                landBookDate: reader.IsDBNull(reader.GetOrdinal("LandBookDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("LandBookDate")),
                landBookBy: reader.IsDBNull(reader.GetOrdinal("LandBookBy")) ? null : reader.GetString(reader.GetOrdinal("LandBookBy")),
                isSpecComplete: reader.GetBoolean(reader.GetOrdinal("IsSpecCompleted")),
                progress: reader.GetByte(reader.GetOrdinal("Progress")),
                address: new Address
                (
                    country_ID: reader.GetInt32(reader.GetOrdinal("Country_ID")),
                    city_ID: reader.GetInt32(reader.GetOrdinal("City_ID")),
                    municipality: reader.IsDBNull(reader.GetOrdinal("Municipality")) ? null : reader.GetString(reader.GetOrdinal("Municipality")),
                    postalCode: reader.IsDBNull(reader.GetOrdinal("PostalCode")) ? null : reader.GetString(reader.GetOrdinal("PostalCode")),
                    placeName: reader.IsDBNull(reader.GetOrdinal("PlaceName")) ? null : reader.GetString(reader.GetOrdinal("PlaceName")),
                    landmark: reader.IsDBNull(reader.GetOrdinal("Landmark")) ? null : reader.GetString(reader.GetOrdinal("Landmark"))
                    ),
                    createdDate: reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                    createdBy: reader.GetInt32(reader.GetOrdinal("CreatedBy")),
                    modificationDate: reader.GetDateTime(reader.GetOrdinal("ModificationDate")),
                    modifiedBy: reader.GetInt32(reader.GetOrdinal("ModifiedBy")),
                    isDeleted: reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
            );
        }

        public async Task<Project> GetByID(int projectID)
        {
            const string query = @"
                SELECT 
                   p.ID, p.Name, p.ProjectCode, p.StartDate, p.Duration, p.ProjectType, 
                   p.Description, p.IsActive, p.LandRegistry, p.SubdivisionPermitNumber, 
                   p.SubdivisionPermitDate, p.ConstructionPermitNumber, p.ConstructionPermitDate, 
                   p.DeedVolume, p.DeedNumber, p.DeedFolio, p.LandBook, p.LandBookDate, 
                   p.LandBookBy, p.IsSpecCompleted, p.Progress, 
                   p.Country_ID, p.City_ID, p.Municipality, p.PostalCode, p.PlaceName,p.Landmark,
                   p.CreationDate, p.CreatedBy, p.ModificationDate, p.ModifiedBy, p.IsDeleted
                FROM Projects p
                WHERE p.ID = @ProjectID AND p.IsDeleted = 0;";

            try
            {
                using (var conn = await OpenConnectionAsync())
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@ProjectID", SqlDbType.Int).Value = projectID;

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return MapProjectFromReader(reader);
                            }
                            else
                            {
                                return null; // Project not found or is deleted
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving project by ID: {ex.Message}");
                throw;
            }
        }
        // Done
        public bool IsProjectExist(int ID)
        {
            bool isFound = false;
            try
            {
                using (var conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("DECLARE @projectID INT   SET NOCOUNT ON; IF EXISTS (SELECT 1 FROM Projects WHERE ID = @projectID)  BEGIN    SELECT 1 AS projectExists;  END ELSE   BEGIN   SELECT 0 AS projectExists;  END", conn))
                    {
                        cmd.Parameters.AddWithValue("@projectID", ID);

                        object result = cmd.ExecuteScalar();
                        if (int.TryParse(result.ToString(), out int num))
                        {
                            isFound = num == 1;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return isFound;
        }

        // Done
        public bool IsProjectExistByName(string projectName)
        {
            bool isFound = false;
            try
            {
                using (var conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("DECLARE @projectName NVARCHAR(100) SET NOCOUNT ON;  IF EXISTS (SELECT 1 FROM Projects WHERE Name = @projectName)  BEGIN   SELECT 1 AS projectExists;  END  ELSE  BEGIN       SELECT 0 AS projectExists;  END", conn))
                    {
                        cmd.Parameters.AddWithValue("@projectName", projectName);

                        object result = cmd.ExecuteScalar();
                        if (int.TryParse(result.ToString(), out int num))
                        {
                            isFound = num == 1;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return isFound;
        }

        //Done
        public async Task<bool> AddNewAsync(Project project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project));
            bool isSuccess = false;
            try
            {
                using (SqlConnection conn = await OpenConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewProject", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // --- Project Fields ---
                        //cmd.Parameters.AddWithValue("@ID", project.ID);
                        cmd.Parameters.AddWithValue("@Name", project.Name);
                        cmd.Parameters.AddWithValue("@ProjectCode", project.ProjectCode ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@StartDate", project.StartDate);
                        cmd.Parameters.AddWithValue("@Duration", project.Duration);
                        cmd.Parameters.AddWithValue("@ProjectType", project.ProjectType);
                        cmd.Parameters.AddWithValue("@Description", project.Description);
                        cmd.Parameters.AddWithValue("@IsActive", project.IsActive);
                        cmd.Parameters.AddWithValue("@LandRegistry", project.LandRegistry);
                        cmd.Parameters.AddWithValue("@SubdivisionPermitNumber", project.SubdivisionPermitNumber ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@SubdivisionPermitDate", project.SubdivisionPermitDate ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ConstructionPermitNumber", project.ConstructionPermitNumber);
                        cmd.Parameters.AddWithValue("@ConstructionPermitDate", project.ConstructionPermitDate);
                        cmd.Parameters.AddWithValue("@DeedVolume", project.DeedVolume ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DeedNumber", project.DeedNumber);
                        cmd.Parameters.AddWithValue("@DeedFolio", project.DeedFolio ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@LandBook", project.LandBook);
                        cmd.Parameters.AddWithValue("@LandBookDate", project.LandBookDate ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@LandBookBy", project.LandBookBy);
                        cmd.Parameters.AddWithValue("@IsSpecCompleted", project.IsSpecCompleted);
                        cmd.Parameters.AddWithValue("@Progress", project.Progress);
                        cmd.Parameters.AddWithValue("@CreatedDate", project.CreationDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", project.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModificationDate", project.ModificationDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", project.ModifiedBy);
                        cmd.Parameters.AddWithValue("@IsDeleted", project.IsDeleted);

                        // --- Address (flattened value object) ---
                        cmd.Parameters.AddWithValue("@Country_ID", project.Address.Country_ID);
                        cmd.Parameters.AddWithValue("@City_ID", project.Address.City_ID);
                        cmd.Parameters.AddWithValue("@Municipality", project.Address.Municipality ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PostalCode", project.Address.PostalCode ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PlaceName", project.Address.PlaceName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Landmark", project.Address.Landmark ?? (object)DBNull.Value);
                        SqlParameter returnedID = new SqlParameter("@NewProjetID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(returnedID);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        if ((int)returnedID.Value > 0)
                        {
                            isSuccess = true;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }

        // Done
        public async Task<bool> UpdateAsync(Project project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project));
            bool isSuccess = false;
            try
            {
                using (SqlConnection conn = await OpenConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateProject", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // --- Project Fields ---
                        //cmd.Parameters.AddWithValue("@ID", project.ID);
                        cmd.Parameters.AddWithValue("@ID", project.ID);
                        cmd.Parameters.AddWithValue("@Name", project.Name);
                        cmd.Parameters.AddWithValue("@ProjectCode", project.ProjectCode ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@StartDate", project.StartDate);
                        cmd.Parameters.AddWithValue("@Duration", project.Duration);
                        cmd.Parameters.AddWithValue("@ProjectType", project.ProjectType);
                        cmd.Parameters.AddWithValue("@Description", project.Description);
                        cmd.Parameters.AddWithValue("@IsActive", project.IsActive);
                        cmd.Parameters.AddWithValue("@LandRegistry", project.LandRegistry);
                        cmd.Parameters.AddWithValue("@SubdivisionPermitNumber", project.SubdivisionPermitNumber ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@SubdivisionPermitDate", project.SubdivisionPermitDate ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ConstructionPermitNumber", project.ConstructionPermitNumber);
                        cmd.Parameters.AddWithValue("@ConstructionPermitDate", project.ConstructionPermitDate);
                        cmd.Parameters.AddWithValue("@DeedVolume", project.DeedVolume ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DeedNumber", project.DeedNumber);
                        cmd.Parameters.AddWithValue("@DeedFolio", project.DeedFolio ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@LandBook", project.LandBook);
                        cmd.Parameters.AddWithValue("@LandBookDate", project.LandBookDate ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@LandBookBy", project.LandBookBy);
                        cmd.Parameters.AddWithValue("@IsSpecCompleted", project.IsSpecCompleted);
                        cmd.Parameters.AddWithValue("@Progress", project.Progress);
                        cmd.Parameters.AddWithValue("@CreationDate", project.CreationDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", project.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModificationDate", project.ModificationDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", project.ModifiedBy);
                        cmd.Parameters.AddWithValue("@IsDeleted", project.IsDeleted);

                        // --- Address (flattened value object) ---
                        cmd.Parameters.AddWithValue("@Country_ID", project.Address.Country_ID);
                        cmd.Parameters.AddWithValue("@City_ID", project.Address.City_ID);
                        cmd.Parameters.AddWithValue("@Municipality", project.Address.Municipality ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PostalCode", project.Address.PostalCode ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PlaceName", project.Address.PlaceName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Landmark", project.Address.Landmark ?? (object)DBNull.Value);
                        //SqlParameter returnedID = new SqlParameter("@NewProjetID", SqlDbType.Int)
                        //{
                        //    Direction = ParameterDirection.Output
                        //};
                        //cmd.Parameters.Add(returnedID);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        if (rowsAffected > 0)
                        {
                            isSuccess = true;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isSuccess;
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
