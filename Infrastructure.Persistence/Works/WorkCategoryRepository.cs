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
    public class WorkCategoryRepository : DBConnectionStringBaseRepo, IWorkCategoryRepository
    {
        public async Task<WorkCategory> GetByIdAsync(int id)
        {
            WorkCategory category = null;
            try
            {
                using (var conn = await CreateConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetWorkCategoryById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                category = new WorkCategory(
                                    id: (int)reader["ID"],
                                    project_ID: (int)reader["Project_ID"],
                                    workCategoryDesignation_ID: (int)reader["WorkCategoryDesignation_ID"]
                                    //creationDate: (DateTime)reader["CreationDate"],
                                    //CreatedBy: (int)reader["CreatedBy"],
                                    //ModificationDate: (DateTime)reader["ModificationDate"],
                                    //ModifiedBy: (int)reader["ModifiedBy"]
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception
                throw;
            }
            return category;
        }

        // Done
        public async Task<IEnumerable<WorkCategory>> GetAllWorkCategoriesForProjectAsync(int projecID)
        {
            var workCategories = new List<WorkCategory>();
            try
            {
                using (var conn = await CreateConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllWorkCategoriesForProject", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@projectID", projecID);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                workCategories.Add(new WorkCategory(
                                  id: (int)reader["ID"],
                                  project_ID: (int)reader["Project_ID"],
                                  workCategoryDesignation_ID: (int)reader ["WorkCategoryDesignation_ID"]
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception
                throw;
            }
            return workCategories;
        }

        // Done
        public async Task<int> AddNewAsync(WorkCategory category)
        {
            int NewID = 0;
            try
            {
                using (var conn = await CreateConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewWorkCategory", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Projet_ID", category.Project_ID);
                        cmd.Parameters.AddWithValue("@WorkCategoryDesignation_ID", category.WorkCategoryDesignation_ID);

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
            catch (Exception ex)
            {
                throw;
            }
            return NewID;
        }
        // Done
        public async Task<int> UpdateAsync(WorkCategory category)
        {
            int categoryID = 0;
            try
            {
                using (var conn = await CreateConnectionAsync())
                {using (SqlCommand cmd = new SqlCommand("SP_UpdateWorkCategory", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", category.ID);
                        cmd.Parameters.AddWithValue("@WorkCategoryDesignation_ID", category.WorkCategoryDesignation_ID);
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
                return -1;
            }
            return categoryID;

        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
