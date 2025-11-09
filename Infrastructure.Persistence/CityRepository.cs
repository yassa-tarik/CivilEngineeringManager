using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CityRepository : DBConnectionStringBaseRepo, ICityRepository
    {
        public List<City> GetAll()
        {
            var result = new List<City>();
            try
            {
                using (var con = CreateConnection())
                {
                    using (var cmd = new SqlCommand("SELECT ID, Name, Country_ID FROM Cities", con))
                    {
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                result.Add(new City(
                                    (int)dr["ID"],
                                    dr["Name"].ToString(),
                                    (int)dr["Country_ID"]
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
            return result;
        }

        public List<City> GetByCountryId(int countryId)
        {
            var result = new List<City>();
            try
            {
                using (var con = CreateConnection())
                {
                    using (var cmd = new SqlCommand("SELECT Id, Name, Country_ID FROM Cities WHERE Country_ID = @countryId", con))
                    {
                        cmd.Parameters.AddWithValue("@countryId", countryId);
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                result.Add(new City(
                                    (int)dr["ID"],
                                    dr["Name"].ToString(),
                                    (int)dr["Country_ID"]
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
            return result;
        }
    }
}
