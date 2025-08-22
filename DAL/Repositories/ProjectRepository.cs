using DAL.Contract.Project;
using DAL.Interfaces;
using DTO.Address;
using DTO.Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly string _connectionString;
        private readonly SqlConnection _conn;
        public ProjectRepository(string connectionString)
        {
            _connectionString = connectionString;
            _conn = new SqlConnection(connectionString);
        }
        public bool Delete(int ID)
        {
            // We must delete all related rows in other tables (Consider using Transaction in SQL Query)
            int rowsAffected = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteProjetAndDependentsByID", _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjetID", ID);
                    _conn.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            return (rowsAffected > 0);
        }
        // Full Project info
        public async Task<List<ProjectEntityDTO>> GetAllFullAsync()
        {
            List<ProjectEntityDTO> allProjetsEntityDTO = new List<ProjectEntityDTO>();
            try
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllProjets", _conn))
                {
                    await _conn.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            // Address part
                            int Adresse_ID = reader.GetInt32(reader.GetOrdinal("ID_Adresse"));
                            int ID_Country = reader.GetInt32(reader.GetOrdinal("ID_Country"));
                            int ID_City = reader.GetInt32(reader.GetOrdinal("ID_City"));
                            string APC = reader.GetString(reader.GetOrdinal("APC"));
                            string Street = reader.GetString(reader.GetOrdinal("Street"));
                            string PostalCode = reader.GetString(reader.GetOrdinal("PostalCode"));
                            string LieuDit = reader.GetString(reader.GetOrdinal("LieuDit"));
                            string Reper = reader.GetString(reader.GetOrdinal("Reper"));

                            //*************Projet part ************
                            //because a common type was not found between types (DateTime & null.
                            Nullable<DateTime> permisDeLotirDu = null;
                            if (reader["PermisDeLotirDu"] != DBNull.Value)
                            {
                                permisDeLotirDu = Convert.ToDateTime(reader["PermisDeLotirDu"]);
                            }
                            Nullable<DateTime> livretFoncierLe = null;
                            if (reader["LivretFoncierLe"] != DBNull.Value)
                            {
                                livretFoncierLe = Convert.ToDateTime(reader["LivretFoncierLe"]);
                            }
                            allProjetsEntityDTO.Add(new ProjectEntityDTO
                                (
            reader.GetInt32(reader.GetOrdinal("ID"))
           , reader.GetInt32(reader.GetOrdinal("ID_Adresse"))
           , reader.GetString(reader.GetOrdinal("Nom"))
           , reader["CodeProjet"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CodeProjet")) : null
           , reader.GetBoolean(reader.GetOrdinal("isDeleted"))
           , reader.GetDateTime(reader.GetOrdinal("DateDebut"))
           , reader.GetInt32(reader.GetOrdinal("Duree"))
           , reader.GetString(reader.GetOrdinal("TypeProjet"))
           , reader.GetString(reader.GetOrdinal("Description"))
           , reader.GetInt32(reader.GetOrdinal("Avancement"))
           , reader.GetBoolean(reader.GetOrdinal("IsActive"))
           , reader.GetInt32(reader.GetOrdinal("CreePar"))
           , reader.GetString(reader.GetOrdinal("ConcervationFonciere"))
           , reader["PermisDeLotirNum"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PermisDeLotirNum")) : null
           //Nullable<DateTime> permisDeLotirDu = null
           , permisDeLotirDu
           , reader.GetString(reader.GetOrdinal("PermisDeConstNum"))
           , reader.GetDateTime(reader.GetOrdinal("PermisDeConstDu"))
           , reader["ActeVolume"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ActeVolume")) : null
           , reader.GetString(reader.GetOrdinal("ActeNum"))
           , reader["ActeFolio"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ActeFolio")) : null
           , reader["LivretFoncier"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LivretFoncier")) : null
           , livretFoncierLe
           , reader.GetString(reader.GetOrdinal("LivretFoncierPar"))
           , reader.GetBoolean(reader.GetOrdinal("isSpecComplete"))
           , reader.GetByte(reader.GetOrdinal("Progress"))

           , ID_Country, ID_City, APC, Street, PostalCode, LieuDit, Reper));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return allProjetsEntityDTO;
        }

        public async Task<List<ProjectMinimalDTO>> GetAllMinimalAsync()
        {
            List<ProjectMinimalDTO> allMinimalProjects = new List<ProjectMinimalDTO>();
            try
            {
                using (SqlCommand command = new SqlCommand("SP_GetMinimalRefProjets", _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await _conn.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            allMinimalProjects.Add(
                                new ProjectMinimalDTO(
                                reader.GetInt32(reader.GetOrdinal("ID"))
                                , reader.GetString(reader.GetOrdinal("Nom"))
                                , reader.GetBoolean(reader.GetOrdinal("isSpecComplete"))
                                , reader.GetByte(reader.GetOrdinal("Progress"))
                                )
                                );
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return allMinimalProjects;
        }

        // For Test purpos
        public List<ProjectMinimalDTO> GetAllMinimal()
        {
            return new List<ProjectMinimalDTO>
            {
                new ProjectMinimalDTO ( 1, "Bridge A",true, 60 ),
                new ProjectMinimalDTO ( 2, "Road B", true, 100 ),
                new ProjectMinimalDTO ( 3, "Tunnel C", true, 0 )
            };
        }

        public ProjectEntityDTO GetByID(int ID)
        {
            ProjectEntityDTO projetEntityDTO = null;
            try
            {
                using (SqlCommand command = new SqlCommand("SP_GetProjetByID", _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjetID", ID);
                    _conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("ID"));
                            int ID_Adresse = reader.GetInt32(reader.GetOrdinal("ID_Adresse"));
                            string nom = reader.GetString(reader.GetOrdinal("Nom"));
                            string codeProjet = reader["CodeProjet"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CodeProjet")) : null;
                            bool isDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted"));
                            DateTime dateDebut = reader.GetDateTime(reader.GetOrdinal("DateDebut"));
                            int duree = reader.GetInt32(reader.GetOrdinal("Duree"));
                            string typeProjet = reader.GetString(reader.GetOrdinal("TypeProjet"));
                            string description = reader.GetString(reader.GetOrdinal("Description"));
                            int avancement = reader.GetInt32(reader.GetOrdinal("Avancement"));
                            bool isActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                            int creePar = reader.GetInt32(reader.GetOrdinal("CreePar"));
                            string conservationFonciere = reader.GetString(reader.GetOrdinal("ConcervationFonciere"));
                            string permisDeLotirNum = reader["PermisDeLotirNum"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PermisDeLotirNum")) : null;
                            //because a common type was not found between types (DateTime & null.
                            Nullable<DateTime> permisDeLotirDu = null;
                            if (reader["PermisDeLotirDu"] != DBNull.Value)
                            {
                                permisDeLotirDu = Convert.ToDateTime(reader["PermisDeLotirDu"]);
                            }

                            string permisDeConstNum = reader.GetString(reader.GetOrdinal("PermisDeConstNum"));
                            DateTime permisDeConstDu = reader.GetDateTime(reader.GetOrdinal("PermisDeConstDu"));
                            string acteVolume = reader["ActeVolume"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ActeVolume")) : null;
                            string acteNum = reader.GetString(reader.GetOrdinal("ActeNum"));
                            string acteFolio = reader["ActeFolio"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ActeFolio")) : null;
                            string livretFoncier = reader["LivretFoncier"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LivretFoncier")) : null;
                            //because a common type was not found between types (DateTime & null.
                            Nullable<DateTime> livretFoncierLe = null;
                            if (reader["LivretFoncierLe"] != DBNull.Value)
                            {
                                livretFoncierLe = Convert.ToDateTime(reader["LivretFoncierLe"]);
                            }

                            string livretFoncierPar = reader.GetString(reader.GetOrdinal("LivretFoncierPar"));
                            bool isSpecComplete = reader.GetBoolean(reader.GetOrdinal("isSpecComplete"));
                            byte progress = reader.GetByte(reader.GetOrdinal("Progress"));

                            //Adresse part
                            int AdresseID = reader.GetInt32(reader.GetOrdinal("ID"));
                            int ID_Country = reader.GetInt32(reader.GetOrdinal("ID_Country"));
                            int ID_City = reader.GetInt32(reader.GetOrdinal("ID_City"));
                            string APC = reader.GetString(reader.GetOrdinal("APC"));
                            string Street = reader.GetString(reader.GetOrdinal("Street"));
                            string PostalCode = reader.GetString(reader.GetOrdinal("PostalCode"));
                            string LieuDit = reader.GetString(reader.GetOrdinal("LieuDit"));
                            string Reper = reader.GetString(reader.GetOrdinal("Reper"));
                            // create objects
                            AddressDTO adresse = new AddressDTO(AdresseID, ID_Country, ID_City, APC, Street, PostalCode, LieuDit, Reper);
                            projetEntityDTO = new ProjectEntityDTO(id, ID_Adresse, nom, codeProjet, isDeleted, dateDebut, duree, typeProjet, description, avancement, isActive, creePar, conservationFonciere, permisDeLotirNum, permisDeLotirDu, permisDeConstNum, permisDeConstDu, acteVolume, acteNum, acteFolio, livretFoncier, Convert.ToDateTime(livretFoncierLe), livretFoncierPar, isSpecComplete, progress, ID_Country, ID_City, APC, Street, PostalCode, LieuDit, Reper);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return projetEntityDTO;
        }

        //the related Table info are added at the S_Procedure level, the ID adresse is not apdated after the Add (ID Adresse -> -1)
        public bool AddNew(ProjectDTO dto)
        {
            bool isAdded = false;
            try
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewProjetAndRelatedTables", _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Adresse part
                    command.Parameters.AddWithValue("@ID_Country", dto.Address.ID_Country);
                    command.Parameters.AddWithValue("@ID_City", dto.Address.ID_City);
                    command.Parameters.AddWithValue("@APC", dto.Address.APC);
                    command.Parameters.AddWithValue("@Street", dto.Address.Street);
                    command.Parameters.AddWithValue("@PostalCode", dto.Address.PostalCode);
                    if (string.IsNullOrEmpty(dto.Address.LieuDit))
                    {
                        command.Parameters.AddWithValue("@LieuDit", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@LieuDit", dto.Address.LieuDit);
                    }
                    if (string.IsNullOrEmpty(dto.Address.Reper))
                    {
                        command.Parameters.AddWithValue("@Reper", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Reper", dto.Address.Reper);
                    }

                    // Projet part
                    command.Parameters.AddWithValue("@Nom", dto.Nom);

                    if (string.IsNullOrEmpty(dto.CodeProjet))
                    {
                        command.Parameters.AddWithValue("@CodeProjet", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@CodeProjet", dto.CodeProjet);
                    }
                    command.Parameters.AddWithValue("@isDeleted", dto.isDeleted);
                    command.Parameters.AddWithValue("@DateDebut", dto.DateDebut);

                    command.Parameters.AddWithValue("@Duree", dto.Duree);
                    command.Parameters.AddWithValue("@TypeProjet", dto.TypeProjet);

                    command.Parameters.AddWithValue("@Description", dto.Description);
                    command.Parameters.AddWithValue("@Avancement", dto.Avancement);
                    command.Parameters.AddWithValue("@IsActive", dto.IsActive);
                    command.Parameters.AddWithValue("@CreePar", dto.CreePar);

                    command.Parameters.AddWithValue("@ConcervationFonciere", dto.ConcervationFonciere);
                    if (string.IsNullOrEmpty(dto.PermisDeLotirNum))
                    {
                        command.Parameters.AddWithValue("@PermisDeLotirNum", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@PermisDeLotirNum", dto.PermisDeLotirNum);
                    }
                    if (dto.PermisDeLotirDu == null)
                    {
                        command.Parameters.AddWithValue("@PermisDeLotirDu", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@PermisDeLotirDu", dto.PermisDeLotirDu);
                    }
                    command.Parameters.AddWithValue("@PermisDeConstNum", dto.PermisDeConstNum);
                    command.Parameters.AddWithValue("@PermisDeConstDu", dto.PermisDeConstDu);

                    if (string.IsNullOrEmpty(dto.ActeVolume))
                    {
                        command.Parameters.AddWithValue("@ActeVolume", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ActeVolume", dto.ActeVolume);
                    }
                    command.Parameters.AddWithValue("@ActeNum", dto.ActeNum);

                    if (string.IsNullOrEmpty(dto.ActeFolio))
                    {
                        command.Parameters.AddWithValue("@ActeFolio", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ActeFolio", dto.ActeFolio);
                    }
                    command.Parameters.AddWithValue("@LivretFoncier", dto.LivretFoncier);

                    if (dto.LivretFoncierLe == null)
                    {
                        command.Parameters.AddWithValue("@LivretFoncierLe", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@LivretFoncierLe", dto.LivretFoncierLe);
                    }
                    command.Parameters.AddWithValue("@LivretFoncierPar", dto.LivretFoncierPar);

                    var outputIdParam = new SqlParameter("@NewProjetIDToReturn", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    _conn.Open();

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        //ID = Convert.ToInt32(outputIdParam.Value);
                        isAdded = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return isAdded;
        }

        public bool Update(ProjectDTO dto)
        {
            int rowsAffected = -1;
            try
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateProjetAndRelatedTables", _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Street part
                    command.Parameters.AddWithValue("@ID_Country", dto.Address.ID_Country);
                    command.Parameters.AddWithValue("@ID_City", dto.Address.ID_City);
                    command.Parameters.AddWithValue("@APC", dto.Address.APC);
                    command.Parameters.AddWithValue("@Street", dto.Address.Street);
                    command.Parameters.AddWithValue("@PostalCode", dto.Address.PostalCode);
                    if (string.IsNullOrEmpty(dto.Address.LieuDit))
                    {
                        command.Parameters.AddWithValue("@LieuDit", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@LieuDit", dto.Address.LieuDit);
                    }
                    if (string.IsNullOrEmpty(dto.Address.Reper))
                    {
                        command.Parameters.AddWithValue("@Reper", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Reper", dto.Address.Reper);
                    }

                    // Projet part                        
                    command.Parameters.AddWithValue("@Nom", dto.Nom);

                    if (string.IsNullOrEmpty(dto.CodeProjet))
                    {
                        command.Parameters.AddWithValue("@CodeProjet", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@CodeProjet", dto.CodeProjet);
                    }
                    command.Parameters.AddWithValue("@isDeleted", dto.isDeleted);
                    command.Parameters.AddWithValue("@DateDebut", dto.DateDebut);

                    command.Parameters.AddWithValue("@Duree", dto.Duree);
                    command.Parameters.AddWithValue("@TypeProjet", dto.TypeProjet);

                    command.Parameters.AddWithValue("@Description", dto.Description);
                    command.Parameters.AddWithValue("@Avancement", dto.Avancement);
                    command.Parameters.AddWithValue("@IsActive", dto.IsActive);
                    command.Parameters.AddWithValue("@CreePar", dto.CreePar);

                    command.Parameters.AddWithValue("@ConcervationFonciere", dto.ConcervationFonciere);
                    if (string.IsNullOrEmpty(dto.PermisDeLotirNum))
                    {
                        command.Parameters.AddWithValue("@PermisDeLotirNum", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@PermisDeLotirNum", dto.PermisDeLotirNum);
                    }
                    if (dto.PermisDeLotirDu == null)
                    {
                        command.Parameters.AddWithValue("@PermisDeLotirDu", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@PermisDeLotirDu", dto.PermisDeLotirDu);
                    }
                    command.Parameters.AddWithValue("@PermisDeConstNum", dto.PermisDeConstNum);
                    command.Parameters.AddWithValue("@PermisDeConstDu", dto.PermisDeConstDu);

                    if (string.IsNullOrEmpty(dto.ActeVolume))
                    {
                        command.Parameters.AddWithValue("@ActeVolume", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ActeVolume", dto.ActeVolume);
                    }
                    command.Parameters.AddWithValue("@ActeNum", dto.ActeNum);

                    if (string.IsNullOrEmpty(dto.ActeFolio))
                    {
                        command.Parameters.AddWithValue("@ActeFolio", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ActeFolio", dto.ActeFolio);
                    }
                    command.Parameters.AddWithValue("@LivretFoncier", dto.LivretFoncier);

                    if (dto.LivretFoncierLe == null)
                    {
                        command.Parameters.AddWithValue("@LivretFoncierLe", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@LivretFoncierLe", dto.LivretFoncierLe);
                    }
                    command.Parameters.AddWithValue("@LivretFoncierPar", dto.LivretFoncierPar);
                    command.Parameters.AddWithValue("@isSpecComplete", dto.isSpecComplete);

                    command.Parameters.AddWithValue("@ProjetID", dto.ID);

                    _conn.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            return (rowsAffected > 0);
        }

        public bool IsProjectExist(int ID)
        {
            bool isFound = false;
            try
            {
                string query = "SELECT Found=1 FROM Projets WHERE ID= @ID";
                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    _conn.Open();
                    object result = command.ExecuteScalar();
                    {
                        isFound = (result != null);
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return isFound;
        }
    }
}
