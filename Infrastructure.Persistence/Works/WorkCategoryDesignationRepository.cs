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
    public class WorkCategoryDesignationRepository : DBConnectionStringBaseRepo, IWorkCategoryDesignationRepository
    {
        // DONE
        public Task<int> AddNewAsync(WorkCategoryDesignation category)
        {
            int NewID = 0;
            try
            {
                using (var conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("[SP_AddNewWorkCategoryDesignation]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Designation", category.Designation);
                        cmd.Parameters.AddWithValue("@CreationDate", category.CreationDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", category.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModificationDate", category.ModificationDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", category.ModifiedBy);
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
                return Task.FromResult(NewID);
            }
            return Task.FromResult(NewID);
        }

        public async Task<WorkCategoryDesignation> GetByIdAsync(int iD)
        {
            WorkCategoryDesignation workCatDesign = default;
            try
            {
                using (var conn = await OpenConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM WorkCategoryDesignations WHERE ID = @ID;", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", iD);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                workCatDesign = new WorkCategoryDesignation(
                            id: reader.GetInt32(reader.GetOrdinal("ID")),

                            designation: reader.GetString(reader.GetOrdinal("Designation"))
                                );
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
            return workCatDesign;
        }

        public bool isDesignationExists(string designation)
        {
            int returnedNum = default;
            try
            {
                using (var conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT CASE  WHEN EXISTS(SELECT 1 from WorkCategoryDesignations where Designation = @designation )  THEN 1   ELSE 0 END AS record_exists;", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@designation", designation);
                        object result = cmd.ExecuteScalar();
                        if (int.TryParse(result.ToString(), out int returnedInt))
                        {
                            returnedNum = returnedInt;
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
            return returnedNum > 0;
        }

        // DONE
        public Task<bool> UpdateAsync(WorkCategoryDesignation category)
        {
            int categoryID = 0;
            try
            {
                using (var conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateWorkCategoryDesignation", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", category.ID);
                        cmd.Parameters.AddWithValue("@Designation", category.Designation);
                        cmd.Parameters.AddWithValue("@ModificationDate", category.ModificationDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", category.ModifiedBy);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            categoryID = category.ID;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return Task.FromResult(categoryID > 0);
            }
            return Task.FromResult(categoryID > 0);
        }

        public async Task<List<WorkCategoryDesignation>> GetAllAsync()
        {
            List<WorkCategoryDesignation> workCategoryDesignations = new List<WorkCategoryDesignation>();
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("[SP_GetAll_WorkCategoryDesignation]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                workCategoryDesignations.Add(new WorkCategoryDesignation
                                (
                                    reader.GetInt32(reader.GetOrdinal("ID")),
                                    reader.GetString(reader.GetOrdinal("Designation"))
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return workCategoryDesignations;
        }
    }
}
