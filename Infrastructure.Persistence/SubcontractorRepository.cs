using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class SubcontractorRepository : DBConnectionStringBaseRepo, ISubcontractorRepository
    {
        public Task DeleteAsync(int projectId)
        {
            throw new NotImplementedException();
        }
        // Done
        public async Task<List<Subcontractor>> FindAllAsync()
        {
            const string query = @"
                SELECT [ID],[CompanyName],[Representative],[BankAccountNumber],[Country_ID],[City_ID],[Municipality],[PostalCode],[PlaceName],[Landmark],[Telephone],[Mobile],[Telecopy],[Email],[CreationDate],[CreatedBy],[ModificationDate],[ModifiedBy],[IsActive],[IsDeleted]
                FROM [dbo].[Subcontractors]
                WHERE IsDeleted = 0";
            List<Subcontractor> subcontractors = new List<Subcontractor>();
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
                                subcontractors.Add(MapSubcontractorFromReader(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception

                Console.WriteLine($"Error retrieving subcontractor by ID: {ex.Message}");
                throw;
            }
            return subcontractors;
        }
        // Done
        private Subcontractor MapSubcontractorFromReader(SqlDataReader reader)
        {
            Address address = new Address(
                    country_ID: reader.GetInt32(reader.GetOrdinal("Country_ID")),
                    city_ID: reader.GetInt32(reader.GetOrdinal("City_ID")),
                    municipality: reader.IsDBNull(reader.GetOrdinal("Municipality")) ? null : reader.GetString(reader.GetOrdinal("Municipality")),
                    postalCode: reader.IsDBNull(reader.GetOrdinal("PostalCode")) ? null : reader.GetString(reader.GetOrdinal("PostalCode")),
                    placeName: reader.IsDBNull(reader.GetOrdinal("PlaceName")) ? null : reader.GetString(reader.GetOrdinal("PlaceName")),
                    landmark: reader.IsDBNull(reader.GetOrdinal("Landmark")) ? null : reader.GetString(reader.GetOrdinal("Landmark"))
                    );
            return new Subcontractor
            (
                id: reader.GetInt32(reader.GetOrdinal("ID")),
                companyName: reader.GetString(reader.GetOrdinal("CompanyName")),
                representative: reader.GetString(reader.GetOrdinal("Representative")),
                bankAccountNumber: reader.IsDBNull(reader.GetOrdinal("BankAccountNumber")) ? null : reader.GetString(reader.GetOrdinal("BankAccountNumber")),
                isActive: reader.GetBoolean(reader.GetOrdinal("IsActive")),
                contact: new Contact
                (
                    telephone: reader.GetString(reader.GetOrdinal("Telephone")),
                    mobile: reader.GetString(reader.GetOrdinal("Mobile")),
                    telecopy: reader.IsDBNull(reader.GetOrdinal("Telecopy")) ? null : reader.GetString(reader.GetOrdinal("Telecopy")),
                    email: reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                    address: address
                    ),
                    createdDate: reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                    createdBy: reader.GetInt32(reader.GetOrdinal("CreatedBy")),
                    modificationDate: reader.GetDateTime(reader.GetOrdinal("ModificationDate")),
                    modifiedBy: reader.GetInt32(reader.GetOrdinal("ModifiedBy")),
                    isDeleted: reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
            );
        }

        public async Task<Subcontractor> GetByID(int subcontractorID)
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
                        cmd.Parameters.Add("@SsubcontractorID", SqlDbType.Int).Value = subcontractorID;

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return MapSubcontractorFromReader(reader);
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

        // Done
        public async Task<bool> AddNewAsync(Subcontractor subcontractor)
        {
            if (subcontractor == null)
                throw new ArgumentNullException(nameof(subcontractor));
            bool isSuccess = false;
            try
            {
                using (SqlConnection conn = await OpenConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("[SP_AddNewSubcontractor]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // --- subcontractor Fields ---
                        cmd.Parameters.AddWithValue("@CompanyName", subcontractor.CompanyName);
                        cmd.Parameters.AddWithValue("@Representative", subcontractor.Representative);
                        cmd.Parameters.AddWithValue("@BankAccountNumber", subcontractor.BankAccountNumber ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CreationDate", subcontractor.CreationDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", subcontractor.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModificationDate", subcontractor.ModificationDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", subcontractor.ModifiedBy);

                        // --- Address (flattened value object) ---
                        cmd.Parameters.AddWithValue("@Country_ID", subcontractor.Contact.Address.Country_ID);
                        cmd.Parameters.AddWithValue("@City_ID", subcontractor.Contact.Address.City_ID);
                        cmd.Parameters.AddWithValue("@Municipality", subcontractor.Contact.Address.Municipality);
                        cmd.Parameters.AddWithValue("@PostalCode", subcontractor.Contact.Address.PostalCode);
                        cmd.Parameters.AddWithValue("@PlaceName", subcontractor.Contact.Address.PlaceName);
                        cmd.Parameters.AddWithValue("@Landmark", subcontractor.Contact.Address.Landmark);

                        cmd.Parameters.AddWithValue("@IsActive", subcontractor.IsActive);
                        cmd.Parameters.AddWithValue("@Telephone", subcontractor.Contact.Telephone);
                        cmd.Parameters.AddWithValue("@Mobile", subcontractor.Contact.Mobile);
                        cmd.Parameters.AddWithValue("@Telecopy", subcontractor.Contact.Telecopy ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", subcontractor.Contact.Email ?? (object)DBNull.Value);

                        cmd.Parameters.AddWithValue("@IsDeleted", subcontractor.IsDeleted);

                        SqlParameter returnedID = new SqlParameter("@NewSubcontractorID", SqlDbType.Int)
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

        // Done
        public async Task<bool> IsSubcontractorExistByName(string CompanyName)
        {
            bool isFound = false;
            try
            {
                using (var conn = await OpenConnectionAsync())
                {
                    using (SqlCommand cmd = new SqlCommand("SET NOCOUNT ON;  IF EXISTS (SELECT 1 FROM Subcontractors WHERE CompanyName = @subcontractorCompanyName) BEGIN  SELECT 1 AS subcontractorExists;  END  ELSE BEGIN  SELECT 0 AS subcontractorExists; END", conn))
                    {
                        cmd.Parameters.AddWithValue("@subcontractorCompanyName", CompanyName);

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
                throw;
            }
            return isFound;
        }
    }
}
