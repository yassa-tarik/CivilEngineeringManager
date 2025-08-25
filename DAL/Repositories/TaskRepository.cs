using DAL.Interfaces;
using DTO.Task;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Pepositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;
        private readonly SqlConnection _conn;
        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
            _conn = new SqlConnection(connectionString);
        }
        public List<TaskDTO> GetAllTravaux()
        {
            List<TaskDTO> taskList = new List<TaskDTO>();
            try
            {
                using (SqlCommand command = new SqlCommand("Sp_GetAllTravaux", _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    _conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            /*
                            taskList.Add(
                                new TaskDTO(
                                 reader.GetInt32(reader.GetOrdinal("ID"))
                                 , reader.GetString(reader.GetOrdinal("Designation"))
                               , reader.GetString(reader.GetOrdinal("Unit"))
                               , reader.GetDecimal(reader.GetOrdinal("Prix_Unitaire"))
                               , reader.GetDouble(reader.GetOrdinal("Quantite"))
                               , reader.IsDBNull(reader.GetOrdinal("ID_Type_Travaux")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ID_Type_Travaux"))

                               , reader.GetString(reader.GetOrdinal("TVA"))
                               , reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                               , reader.IsDBNull(reader.GetOrdinal("ParentID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ParentID"))
                               , reader.GetBoolean(reader.GetOrdinal("HasChild"))
                               )
                            ); */
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex) { /*clsErrorHandling.HandleError(ex);*/ }
            return taskList;
        }
        //*********************** work together *****************************
        /*
        private static int SaveTreeNodeToDatabaseWithSP(clsTravauxNode travauxNode, int? parentId)
        {
            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewTravaux", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // TODO: will check if good practice?
                        object IdTypeTravaux = parentId != null ? cmd.Parameters.AddWithValue("@ID_Type_Travaux", DBNull.Value) : cmd.Parameters.AddWithValue("@ID_Type_Travaux", travauxNode.ID_Type_Travaux);
                        cmd.Parameters.AddWithValue("@Designation", travauxNode.Designation);
                        cmd.Parameters.AddWithValue("@Unit", travauxNode.Unite);
                        cmd.Parameters.AddWithValue("@Prix_Unitaire", travauxNode.Prix_Unitaire);
                        cmd.Parameters.AddWithValue("@Quantite", travauxNode.Quantite);
                        cmd.Parameters.AddWithValue("@TVA", travauxNode.TVA);
                        cmd.Parameters.AddWithValue("@CreationDate", travauxNode.CreationDate);

                        object ParentIdObj = parentId == null ? cmd.Parameters.AddWithValue("@ParentId", DBNull.Value) : cmd.Parameters.AddWithValue("@ParentId", parentId);
                        cmd.Parameters.AddWithValue("@HasChild", travauxNode.HasChild);
                        var outputId = new SqlParameter("@NewId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputId);
                        connection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            ID = Convert.ToInt32(outputId.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return ID;
        }
        private static bool SaveTreeNode(clsTravauxNode node, int? parentId)
        {
            // TODO: will make Transaction
            bool isSuccess = true;
            //clsTravauxDTO trvDTO = TravauxMapper.ToDTO(node);
            // Save the current node           
            int newId = SaveTreeNodeToDatabaseWithSP(node, parentId);
            if (newId == -1)
            {
                return isSuccess = false;
            }
            // Save child nodes recursively
            foreach (var child in node.Children)
            {
                SaveTreeNode(child, newId);
            }
            return isSuccess;
        }
        public static bool SaveTreeRootsToDatabase(List<clsTravauxNode> travauxRoots)
        {
            bool isRootSaved = true;
            try
            {
                {
                    foreach (var Node in travauxRoots)
                    {
                        if (SaveTreeNode(Node, null) == false)
                        {
                            isRootSaved = false;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return isRootSaved;
        }
        */
        //********************************************************************
    }
}
