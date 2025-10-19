using Domain.Abstractions;
using Domain.Abstractions.Works;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Works
{
    public class WorkTypeRepository : DBConnectionStringBaseRepo ,IWorkTypeRepository
    {
        //DONE
        public Task<int> AddNewAsync(WorkType workType)
        {
            int NewID = 0;
            try
            {
                using (var conn = CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewWorkType", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WorkCategory_ID", workType.WorkCategory_ID);
                        cmd.Parameters.AddWithValue("@Parent_ID", workType.Parent_ID);
                        cmd.Parameters.AddWithValue("@Designation", workType.Designation);
                        cmd.Parameters.AddWithValue("@CreationDate", workType.CreationDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", workType.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModificationDate", workType.ModificationDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", workType.ModifiedBy);
                        SqlParameter returnedNewID = new SqlParameter("@NewID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(returnedNewID);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            NewID = Convert.ToInt32(returnedNewID.Value);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return Task.FromResult(-1);
            }
            return Task.FromResult(NewID);
        }
        //DONE
        public Task<int> UpdateAsync(WorkType workType)
        {
            int typeID = 0;
            try
            {
                using (var conn = CreateConnection())
                using (SqlCommand cmd = new SqlCommand("SP_UpdateWorkType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", workType.ID);
                    cmd.Parameters.AddWithValue("@Designation", workType.Designation);
                    cmd.Parameters.AddWithValue("@ModificationDate", workType.ModificationDate);
                    cmd.Parameters.AddWithValue("@ModifiedBy", workType.ModifiedBy);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        typeID = workType.ID;
                    }
                }
            }
            catch (Exception)
            {
                return Task.FromResult(-1);
            }
            return Task.FromResult(typeID);
        }
        // done
        public async Task<List<WorkType>> GetAllForCategoriesRootsAsync(int projectID)
        {
            List<WorkType> workTypes = new List<WorkType>(); 
            try
            {
                using (var conn = CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllWorkTypesForWorkCategoriesRoots", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@projectID", projectID);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                workTypes.Add( new WorkType(
                            id: reader.GetInt32(reader.GetOrdinal("ID")),
                            workCategory_ID: reader.IsDBNull(reader.GetOrdinal("WorkCategory_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("WorkCategory_ID")),
                            parent_ID: reader.IsDBNull(reader.GetOrdinal("Parent_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Parent_ID")),
                            designation: reader.GetString(reader.GetOrdinal("Designation"))
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., using a logger)
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Re-throw the exception or return an empty list based on error handling policy
                throw;
            }
            return workTypes;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        //mock data
        public async Task<IEnumerable<WorkType>> GetAllForCategoryAsync(int categoryID)
        {
            return await Task.FromResult<IEnumerable<WorkType>>(_workTypes);
        }

        public Task<WorkType> GetByIdAsync(int id)
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
            new WorkType(id: 1, workCategory_ID: 1, parent_ID: null, designation: "Foundations"),
            new WorkType(id: 2, workCategory_ID: 1, parent_ID: 1, designation: "Poured Concrete"),
            new WorkType(id: 3, workCategory_ID: 1, parent_ID: 1, designation: "Steel Reinforcement"),
            
            // IT and Technology Category (WorkCategory_ID = 2)
            new WorkType(id: 4, workCategory_ID : null, parent_ID : null, designation : "Software Development"),
            new WorkType(id: 5, workCategory_ID : 4, parent_ID : 4, designation : "Frontend"),
            new WorkType(id: 6, workCategory_ID : 4, parent_ID : 4, designation : "Backend"),
            new WorkType(id: 7, workCategory_ID : 5, parent_ID : 5, designation : "React"),
            new WorkType(id: 8, workCategory_ID : 5, parent_ID : 5, designation : "Angular"),
            
            // Marketing Category (WorkCategory_ID = 3)
            new WorkType(id: 9, workCategory_ID : null, parent_ID : null, designation : "Digital Campaigns"),
            new WorkType(id: 10, workCategory_ID : 9, parent_ID : 9, designation : "PPC"),
            new WorkType(id: 11, workCategory_ID : 9, parent_ID : 9, designation : "Social Media")
        };
        }
    }
}
