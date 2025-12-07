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
    public class WorkSpecRepository : DBConnectionStringBaseRepo, IWorkSpecRepository
    {
        //DONE
        public async Task<bool> AddNewAsync(WorkSpec workSpec)
        {
            bool isAdded = false;
            try
            {
                using (var conn = await OpenConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("[SP_AddNewWorkSpec]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WorkCategory_ID", workSpec.WorkCategory_ID);
                        cmd.Parameters.AddWithValue("@WorkType_ID", workSpec.WorkType_ID);
                        cmd.Parameters.AddWithValue("@Designation", workSpec.Designation);
                        cmd.Parameters.AddWithValue("@Unit", workSpec.Unit);
                        cmd.Parameters.AddWithValue("@UnitPrice", workSpec.UnitPrice);
                        cmd.Parameters.AddWithValue("@Quantity", workSpec.Quantity);
                        cmd.Parameters.AddWithValue("@VAT", workSpec.VAT);
                        cmd.Parameters.AddWithValue("@Status", workSpec.IsAssigned);
                        cmd.Parameters.AddWithValue("@CreationDate", workSpec.CreationDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", workSpec.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModificationDate", workSpec.ModificationDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", workSpec.ModifiedBy);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isAdded = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                isAdded = false;
            }
            return isAdded;
        }
        //DONE
        public async Task<bool> AddNewAsyncInTransaction(WorkSpec workSpec, IUnitOfWork uow)
        {
            if (workSpec == null) throw new ArgumentNullException(nameof(workSpec));
            bool isAdded = false;
            try
            {
                var conn = uow.Connection;

                using (SqlCommand cmd = new SqlCommand("[SP_AddNewWorkSpec]", conn, uow.Transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkCategory_ID", workSpec.WorkCategory_ID);
                    cmd.Parameters.AddWithValue("@WorkType_ID", workSpec.WorkType_ID);
                    cmd.Parameters.AddWithValue("@Designation", workSpec.Designation);
                    cmd.Parameters.AddWithValue("@Unit", workSpec.Unit);
                    cmd.Parameters.AddWithValue("@UnitPrice", workSpec.UnitPrice);
                    cmd.Parameters.AddWithValue("@Quantity", workSpec.Quantity);
                    cmd.Parameters.AddWithValue("@VAT", workSpec.VAT);
                    cmd.Parameters.AddWithValue("@CreationDate", workSpec.CreationDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", workSpec.CreatedBy);
                    cmd.Parameters.AddWithValue("@ModificationDate", workSpec.ModificationDate);
                    cmd.Parameters.AddWithValue("@ModifiedBy", workSpec.ModifiedBy);

                    int result = await cmd.ExecuteNonQueryAsync();
                    if (result > 0)
                    {
                        isAdded = true;
                    }
                }

                //await uow.CommitAsync();
            }
            catch (Exception)
            {
                //await uow.RollbackAsync();
                throw;
                isAdded = false;
            }
            return isAdded;
        }
        //DONE
        public Task<bool> UpdateAsync(WorkSpec workSpec)
        {
            bool isModified = false;
            try
            {
                using (var conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("[SP_UpdateWorkSpec]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", workSpec.ID);
                        cmd.Parameters.AddWithValue("@Designation", workSpec.Designation);
                        cmd.Parameters.AddWithValue("@Unit", workSpec.Unit);
                        cmd.Parameters.AddWithValue("@UnitPrice", workSpec.UnitPrice);
                        cmd.Parameters.AddWithValue("@Quantity", workSpec.Quantity);
                        cmd.Parameters.AddWithValue("@VAT", workSpec.VAT);
                        cmd.Parameters.AddWithValue("@ModificationDate", workSpec.ModificationDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", workSpec.ModifiedBy);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isModified = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                isModified = false;
            }
            return Task.FromResult(isModified);
        }
        //DONE
        public Task<bool> UpdateAsyncInTransaction(WorkSpec workSpec, IUnitOfWork uow)
        {
            bool isModified = false;
            try
            {
                var conn = uow.Connection;
                {
                    using (SqlCommand cmd = new SqlCommand("[SP_UpdateWorkSpec]", conn, uow.Transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", workSpec.ID);
                        cmd.Parameters.AddWithValue("@Designation", workSpec.Designation);
                        cmd.Parameters.AddWithValue("@Unit", workSpec.Unit);
                        cmd.Parameters.AddWithValue("@UnitPrice", workSpec.UnitPrice);
                        cmd.Parameters.AddWithValue("@Quantity", workSpec.Quantity);
                        cmd.Parameters.AddWithValue("@VAT", workSpec.VAT);
                        cmd.Parameters.AddWithValue("@ModificationDate", workSpec.ModificationDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", workSpec.ModifiedBy);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isModified = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Task.FromResult(isModified);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkSpec>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<WorkSpec>>(_workSpecs);
        }

        public async Task<WorkSpec> GetByIdAsync(int workSpecId)
        {
            WorkSpec workSpec = null;
            try
            {
                using (var conn = await OpenConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("[SP_GetWorkSpecById]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", workSpecId);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                //TODO: will make this in a separate method
                                workSpec = new WorkSpec(
                                    id: reader.GetInt32(reader.GetOrdinal("ID")),

                            workCategory_ID: reader.IsDBNull(reader.GetOrdinal("WorkCategory_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("WorkCategory_ID")),

                            workType_ID: reader.IsDBNull(reader.GetOrdinal("workType_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("workType_ID")),

                            designation: reader.GetString(reader.GetOrdinal("Designation")),

                            unit: reader.GetString(reader.GetOrdinal("Unit")),

                            unitPrice: reader.GetDecimal(reader.GetOrdinal("UnitPrice")),

                            quantity: reader.GetDouble(reader.GetOrdinal("Quantity")),

                            vat: reader.GetString(reader.GetOrdinal("VAT")),
                            isAssigned: reader.GetBoolean(reader.GetOrdinal("Status"))
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
            return workSpec;
        }

        public async Task<List<WorkSpec>> GetAllSpecsForProjectAsync(int projectID, bool isAssigned)
        {
            List<WorkSpec> workSpecs = new List<WorkSpec>();
            try
            {
                using (var conn = await OpenConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllWorkSpecsForProject", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@projectID", projectID);
                        cmd.Parameters.AddWithValue("@isAssigned", isAssigned);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                workSpecs.Add(MapWorkSpecFromReader(reader));
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
            return workSpecs;
        }

        public async Task<List<WorkSpec>> GetAllSpecsForProjectAndSubcontractorAsync(int projectID, int subcontractorID)
        {
            List<WorkSpec> workSpecs = new List<WorkSpec>();
            try
            {
                using (var conn = await OpenConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("[SP_GetAllWorkSpecsForProjectAndSubcontractor]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@projectID", projectID);
                        cmd.Parameters.AddWithValue("@isAssigned", subcontractorID);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                workSpecs.Add(MapWorkSpecFromReader(reader));
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
            return workSpecs;
        }

        WorkSpec MapWorkSpecFromReader(SqlDataReader reader)
        {
            return new WorkSpec(
                            id: reader.GetInt32(reader.GetOrdinal("ID")),

                            workCategory_ID: reader.IsDBNull(reader.GetOrdinal("WorkCategory_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("WorkCategory_ID")),

                            workType_ID: reader.IsDBNull(reader.GetOrdinal("workType_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("workType_ID")),

                            designation: reader.GetString(reader.GetOrdinal("Designation")),

                            unit: reader.GetString(reader.GetOrdinal("Unit")),

                            unitPrice: reader.GetDecimal(reader.GetOrdinal("UnitPrice")),

                            quantity: reader.GetDouble(reader.GetOrdinal("Quantity")),

                            vat: reader.GetString(reader.GetOrdinal("VAT")),

                            isAssigned: reader.GetBoolean(reader.GetOrdinal("IsAssigned"))
                                );
        }
        //******************* Mock data ********************************
        private readonly List<WorkSpec> _workSpecs;

        public WorkSpecRepository()
        {
            /*
            _workSpecs = new List<WorkSpec>
        {
            // WorkType: Poured Concrete (WorkType_ID = 2)
            new WorkSpec(id: 1, workCategory_ID: 2, workType_ID: null, designation: "Standard mix", unit: "Cubic Meter", unitPrice: 120.50m, quantity: 50.0, vat: "20%"),
            new WorkSpec(id: 2, workCategory_ID: 1, workType_ID: null, designation: "High-strength mix", unit: "Cubic Meter", unitPrice: 150.00m, quantity: 25.0, vat: "20%"),
            
            // WorkType: Steel Reinforcement (WorkType_ID = 3)
            new WorkSpec(id: 3, workCategory_ID: null, workType_ID: 3, designation: "#4 Rebar", unit: "Tonne", unitPrice: 850.00m, quantity: 10.5, vat: "20%"),
            new WorkSpec(id: 4, workCategory_ID: null, workType_ID: 3, designation: "Mesh wire", unit: "Square Meter", unitPrice: 5.75m, quantity: 200.0, vat: "20%"),
            
            // WorkType: React (WorkType_ID = 7)
            new WorkSpec(id: 5, workCategory_ID: 2, workType_ID: null, designation: "Initial component setup", unit: "Hour", unitPrice: 85.00m, quantity: 10.0, vat: "0%"),
            new WorkSpec(id: 6, workCategory_ID: null, workType_ID: 7, designation: "State management implementation", unit: "Hour", unitPrice: 90.00m, quantity: 20.0, vat: "0%"),
            
            // WorkType: Angular (WorkType_ID = 8)
            new WorkSpec(id: 7, workCategory_ID : 2, workType_ID: null, designation: "Module creation", unit: "Hour", unitPrice: 85.00m, quantity: 8.0, vat: "0%"),
            new WorkSpec(id: 8, workCategory_ID : null, workType_ID: 8, designation: "Service and dependency injection", unit: "Hour", unitPrice: 90.00m, quantity: 15.0, vat: "0%")
        };
            */
        }
    }
}
