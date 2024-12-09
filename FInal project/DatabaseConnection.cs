using System;
using System.Data.SqlClient;

namespace FInal_project
{
    public sealed class DatabaseConnection
    {
        private static readonly Lazy<DatabaseConnection> _instance =
            new Lazy<DatabaseConnection>(() => new DatabaseConnection());

        private readonly string _connectionString;
        private SqlConnection _connection;

        // Private constructor to prevent instantiation
        private DatabaseConnection()
        {
            // Define your connection string here (update with your actual values)
            _connectionString = "Server=localhost;Database=CarSales&ServiceManagementSystem;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
        }

        // Public property to access the single instance
        public static DatabaseConnection Instance => _instance.Value;

        // Method to get the SqlConnection object
        public SqlConnection GetConnection()
        {
            if (_connection == null || _connection.State == System.Data.ConnectionState.Closed)
            {
                _connection = new SqlConnection(_connectionString);
            }
            return _connection;
        }

        // Test the database connection
        public bool TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return false;
            }
        }
    }
}
