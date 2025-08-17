using System.Configuration;

namespace DAL.Database
{
    public class SqlConnectionFactory
    {
        static public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}
