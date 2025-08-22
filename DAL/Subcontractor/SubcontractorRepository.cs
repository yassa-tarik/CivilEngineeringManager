using DAL.Contracts.SubcontractorEntity;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL.Pepositories
{
    public class SubcontractorRepository : ISubcontractorRepository
    {
        private readonly string _connectionString;
        private readonly SqlConnection _conn;
        public SubcontractorRepository(string connectionString)
        {
            _connectionString = connectionString;
            _conn = new SqlConnection(connectionString);
        }

        public bool AddNew(SubcontractorEntityDTO EntityDTO)
        {
            bool isSuccess = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("SP_AddNewFullSousTraitant", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adresse Parameters
                    cmd.Parameters.AddWithValue("@ID_Country", EntityDTO.ID_Country);
                    cmd.Parameters.AddWithValue("@ID_City", EntityDTO.ID_City);
                    cmd.Parameters.AddWithValue("@APC", EntityDTO.APC);
                    cmd.Parameters.AddWithValue("@Street", EntityDTO.Street);
                    cmd.Parameters.AddWithValue("@PostalCode", EntityDTO.PostalCode);
                    cmd.Parameters.AddWithValue("@LieuDit", EntityDTO.LieuDit ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Reper", EntityDTO.Reper ?? (object)DBNull.Value);

                    // Contact Parameters
                    cmd.Parameters.AddWithValue("@Telephone", EntityDTO.Telephone);
                    cmd.Parameters.AddWithValue("@Mobile", EntityDTO.Mobile ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telecopie", EntityDTO.Telecopie ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", EntityDTO.Email ?? (object)DBNull.Value);

                    // SousTraitant Parameters
                    cmd.Parameters.AddWithValue("@RaisonSocial", EntityDTO.RaisonSocial);
                    cmd.Parameters.AddWithValue("@Representant", EntityDTO.Representant);
                    cmd.Parameters.AddWithValue("@NumCptBank", EntityDTO.NumCptBank ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreationDate", EntityDTO.CreationDate);
                    cmd.Parameters.AddWithValue("@CreePar", EntityDTO.CreePar);
                    cmd.Parameters.AddWithValue("@ModificationDate", EntityDTO.ModificationDate);
                    cmd.Parameters.AddWithValue("@ModifierPar", EntityDTO.ModifierPar);
                    cmd.Parameters.AddWithValue("@IsActive", EntityDTO.IsActive);

                    // Output Parameter
                    SqlParameter outputParam = new SqlParameter("@NewSousTraitantIDToReturn", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    try
                    {
                        _conn.Open();
                        cmd.ExecuteNonQuery();

                        int newId = (int)(outputParam.Value ?? -1);
                        isSuccess = newId > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log or handle exception as needed
                        Console.Error.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
            return isSuccess;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            try
            {
                using (SqlCommand command = new SqlCommand("SP_Delete_Full_SousTraitantByID", _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SousTraitant_ID", id);
                    _conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        isDeleted = true;
                    }
                }
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            finally
            {
                _conn.Close();
            }
            return isDeleted;
        }

        public async Task<List<SubcontractorEntityDTO>> GetAllAsync()
        {
            List<SubcontractorEntityDTO> RawSubcontractors = new List<SubcontractorEntityDTO>();
            //TODO: Replace with stored procedure
            string query = "SELECT * FROM SousTraitants s join Contacts c on s.IDContact = c.ContactID join Adresses a on c.IDAdresses = a.ID ";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    await _conn.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        SubcontractorEntityDTO subcontactorEntityDTO = new SubcontractorEntityDTO
                           (
                           // TODO: soustraitant
                           reader.GetInt32(reader.GetOrdinal("SousTraitantID"))
                           , reader.GetInt32(reader.GetOrdinal("IDContact"))
                           , reader.GetString(reader.GetOrdinal("RaisonSocial"))
                           , reader.GetString(reader.GetOrdinal("Representant"))
                           , reader.GetString(reader.GetOrdinal("NumCptBank"))
                           , reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                           , reader.GetInt32(reader.GetOrdinal("CreePar"))
                           , reader.GetDateTime(reader.GetOrdinal("ModificationDate"))
                           , reader.GetInt32(reader.GetOrdinal("ModifierPar"))
                           , reader.GetBoolean(reader.GetOrdinal("IsActive"))
                           , reader.GetInt32(reader.GetOrdinal("IDAdresses"))
                           , reader.GetString(reader.GetOrdinal("Telephone"))
                           , reader.GetString(reader.GetOrdinal("Mobile"))
                           , reader.GetString(reader.GetOrdinal("Telecopie"))
                           , reader.GetString(reader.GetOrdinal("Email"))
                           , reader.GetInt32(reader.GetOrdinal("ID_Country"))
                           , reader.GetInt32(reader.GetOrdinal("ID_City"))
                           , reader.GetString(reader.GetOrdinal("APC"))
                           , reader.GetString(reader.GetOrdinal("Street"))
                           , reader.GetString(reader.GetOrdinal("PostalCode"))
                           , reader.GetString(reader.GetOrdinal("LieuDit"))
                           , reader.GetString(reader.GetOrdinal("Reper"))
                           )
                           ;
                        RawSubcontractors.Add(subcontactorEntityDTO);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }
            return RawSubcontractors;
        }

        public bool Update(SubcontractorEntityDTO EntityDTO)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SP_Update_Full_SousTraitant", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Address Parameters
                    cmd.Parameters.AddWithValue("@ID_Country", EntityDTO.ID_Country);
                    cmd.Parameters.AddWithValue("@ID_City", EntityDTO.ID_City);
                    cmd.Parameters.AddWithValue("@APC", EntityDTO.APC);
                    cmd.Parameters.AddWithValue("@Street", EntityDTO.Street);
                    cmd.Parameters.AddWithValue("@PostalCode", EntityDTO.PostalCode);
                    cmd.Parameters.AddWithValue("@LieuDit", EntityDTO.LieuDit ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Reper", EntityDTO.Reper ?? (object)DBNull.Value);

                    // Contact Parameters
                    cmd.Parameters.AddWithValue("@Telephone", EntityDTO.Telephone);
                    cmd.Parameters.AddWithValue("@Mobile", EntityDTO.Mobile ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telecopie", EntityDTO.Telecopie ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", EntityDTO.Email ?? (object)DBNull.Value);

                    // SousTraitant Parameters
                    cmd.Parameters.AddWithValue("@SousTraitantID", EntityDTO.ID);
                    cmd.Parameters.AddWithValue("@RaisonSocial", EntityDTO.RaisonSocial);
                    cmd.Parameters.AddWithValue("@Representant", EntityDTO.Representant);
                    cmd.Parameters.AddWithValue("@NumCptBank", EntityDTO.NumCptBank ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreationDate", EntityDTO.CreationDate);
                    cmd.Parameters.AddWithValue("@CreePar", EntityDTO.CreePar);
                    cmd.Parameters.AddWithValue("@ModificationDate", EntityDTO.ModificationDate);
                    cmd.Parameters.AddWithValue("@ModifierPar", EntityDTO.ModifierPar);
                    cmd.Parameters.AddWithValue("@IsActive", EntityDTO.IsActive);

                    _conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception appropriately here
                return false;
            }
        }

        public SubcontractorEntityDTO GetById(int id)
        {
            SubcontractorEntityDTO subcontractorEntityDTO = null;
            try
            {
                using (SqlCommand command = new SqlCommand("SP_Get_Full_SousTraitantByID", _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoustraitantID", id);
                    _conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //sousTraitant part
                            int subcontractorID = reader.GetInt32(reader.GetOrdinal("SousTraitantID"));
                            int ID_Contact = reader.GetInt32(reader.GetOrdinal("IDContact"));
                            string RaisonSocial = reader.GetString(reader.GetOrdinal("RaisonSocial"));
                            string Representant = reader.GetString(reader.GetOrdinal("Representant"));
                            string NumCptBank = reader.GetString(reader.GetOrdinal("NumCptBank"));
                            DateTime CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
                            int CreePar = reader.GetInt32(reader.GetOrdinal("CreePar"));
                            DateTime ModificationDate = reader.GetDateTime(reader.GetOrdinal("ModificationDate"));
                            int ModifierPar = reader.GetInt32(reader.GetOrdinal("ModifierPar"));
                            bool IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));

                            //Contact part
                            int IDAdresse = reader.GetInt32(reader.GetOrdinal("IDAdresses"));
                            string Telephone = reader.GetString(reader.GetOrdinal("Telephone"));
                            string Mobile = reader.GetString(reader.GetOrdinal("Mobile"));
                            string Telecopie = reader.GetString(reader.GetOrdinal("Telecopie"));
                            string Email = reader.GetString(reader.GetOrdinal("Email"));

                            //Adresse part
                            int ID_Country = reader.GetInt32(reader.GetOrdinal("ID_Country"));
                            int ID_City = reader.GetInt32(reader.GetOrdinal("ID_City"));
                            string APC = reader.GetString(reader.GetOrdinal("APC"));
                            string Street = reader.GetString(reader.GetOrdinal("Street"));
                            string PostalCode = reader.GetString(reader.GetOrdinal("PostalCode"));
                            string LieuDit = reader.GetString(reader.GetOrdinal("LieuDit"));
                            string Reper = reader.GetString(reader.GetOrdinal("Reper"));

                            // create objects
                            subcontractorEntityDTO = new SubcontractorEntityDTO(subcontractorID, ID_Contact, RaisonSocial, Representant, NumCptBank, CreationDate, CreePar, ModificationDate, ModifierPar, IsActive, IDAdresse, Telephone, Mobile, Telecopie, Email, ID_Country, ID_City, APC, Street, PostalCode, LieuDit, Reper);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _conn.Close();
            }
            return subcontractorEntityDTO;
        }

        public bool ExistsById(int id)
        {
            bool exists = false;
            try
            {
                using (SqlCommand command = new SqlCommand("SP_isSubcontractorExistsByID", _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoustraitantID", id);
                    _conn.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        int subcontractorExists = Convert.ToInt32(result);
                        exists = subcontractorExists == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle other general exceptions
                throw new Exception("General Error: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return exists;
        }

        public bool ExistsByName(string raisonSocial)
        {
            bool exists = false;
            try
            {
                using (SqlCommand command = new SqlCommand("SP_isSubcontractorExistsByName", _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoustraitantID", raisonSocial);
                    _conn.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        int subcontractorExists = Convert.ToInt32(result);
                        exists = subcontractorExists == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle other general exceptions
                throw new Exception("General Error: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return exists;
        }
    }
}
