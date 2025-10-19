using Domain.Abstractions;
using Domain.Abstractions.Works;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Works
{
    public class WorkCategoryRepository : DBConnectionStringBaseRepo, IWorkCategoryRepository
    {
        public Task<WorkCategory> GetByIdAsync(int id)
        {
            using (var conn = CreateConnection())
            using (var command = CreateConnection())
            {

            }
            throw new NotImplementedException();
            
        }

        public Task<IEnumerable<WorkCategory>> GetAllForProjectAsync(int projecID)
        {
            throw new NotImplementedException();
        }

        // DONE
        public Task<int> AddNewAsync(WorkCategory category)
        {
            int NewID = 0;
            try
            {
                using (var conn = CreateConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewWorkCategory", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Project_ID", category.Project_ID);
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
            catch (Exception)
            {
                return Task.FromResult(-1);                
            }
            return Task.FromResult(NewID);
        }
        // DONE
        public Task<int> UpdateAsync(WorkCategory category)
        {
            int categoryID = 0;
            try
            {
                using (var conn = CreateConnection())
                using (SqlCommand cmd = new SqlCommand("SP_UpdateWorkCategory", conn))
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
            catch (Exception)
            {
                return Task.FromResult(-1);
            }
            return Task.FromResult(categoryID);

        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
