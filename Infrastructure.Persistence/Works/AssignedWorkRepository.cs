using Common.Enums;
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
    public class AssignedWorkRepository : DBConnectionStringBaseRepo, IAssignedWorkRepository
    {
        public async Task<List<AssignedWork>> GetAllAssignedWorksForProjectAndSubcontractorAsync(int projectID, int subcontractorID)
        {
            List<AssignedWork> assignedWorks = new List<AssignedWork>();
            try
            {
                using (var conn = await OpenConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("[SP_GetAllAssignedWorksForProjectAndSubcontractor]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@projectID", projectID);
                        cmd.Parameters.AddWithValue("@subcontractor_ID", subcontractorID);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                assignedWorks.Add(new AssignedWork(
                            iD: reader.GetInt32(reader.GetOrdinal("ID")),

                            workSpec_ID: reader.GetInt32(reader.GetOrdinal("WorkSpec_ID")),

                            subcontractor_ID: reader.GetInt32(reader.GetOrdinal("Subcontractor_ID")),

                            negotiatedUnitPrice: reader.GetDecimal(reader.GetOrdinal("NegotiatedUnitPrice")),

                            assignedQuantity: reader.GetDouble(reader.GetOrdinal("AssignedQuantity")),

                            assignedDate: reader.GetDateTime(reader.GetOrdinal("AssignedDate")),

                            producedQuantity: reader.GetDouble(reader.GetOrdinal("ProducedQuantity")),

                            status: (AssignedWorkStatus)Convert.ToByte(reader.GetDouble(reader.GetOrdinal("Status"))),

                            endDate: reader.GetDateTime(reader.GetOrdinal("EndDate")),

                            isActive: reader.GetBoolean(reader.GetOrdinal("IsActive")),

                            isDeleted: reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                                ));
                            }
                        }
                    }
                }
            }
            catch
            {
                // Log the exception (e.g., using a logger)
                //Console.WriteLine($"An error occurred: {/*ex.Message*/}");
                // Re-throw the exception or return an empty list based on error handling policy
                throw;
            }
            return assignedWorks;
        }
    }
}
