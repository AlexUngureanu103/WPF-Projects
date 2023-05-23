using Microsoft.Data.SqlClient;
using System.Configuration;

namespace SchoolManagementApp.Domain
{
    public static class DALHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SchoolManagement"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
