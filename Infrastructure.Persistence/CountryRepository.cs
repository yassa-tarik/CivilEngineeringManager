using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infrastructure.Persistence
{
    public class CountryRepository : DBConnectionStringBaseRepo, ICountryRepository
    {
        public List<Country> GetAll()
        {
            var result = new List<Country>();
            try
            {
                using (var con = OpenConnection())
                {
                    using (var cmd = new SqlCommand("SELECT ID, Name FROM Countries", con))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                result.Add(new Country(
                                    (int)dr["ID"],
                                    dr["Name"].ToString()
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
