using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace posto_desktop.Infrastructure.Repository
{
    public static class DbConnectionFactory
    {
        private const string CONNECTION_STRING =
            "Server=localhost,1433;" +
            "Database=FuelLocalDb;" +
            "User Id=sa;" +
            "Password=StrongPass!123;" +
            "TrustServerCertificate=True;" +
            "Encrypt=False;" +
            "Connection Timeout=30;";

        public static SqlConnection Create()
        {
            return new SqlConnection(CONNECTION_STRING);
        }
    }
}
