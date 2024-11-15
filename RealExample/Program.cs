using Microsoft.Data.SqlClient;

namespace RealExample
{
    internal class Program
    {
        private static string connectionString = "data source=.;Initial Catalog=Test;Integrated Security=true;TrustServerCertificate=True";

        public static async IAsyncEnumerable<string> FetchRecordsAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("SELECT Name FROM LargeTable", connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        yield return reader.GetString(0); // Assuming the first column is of type string
                    }
                }
            }
        }

        public static async Task ProcessRecordsAsync()
        {
            await foreach (var record in FetchRecordsAsync())
            {
                // Simulate processing each record
                Console.WriteLine($"Processing record: {record}");
                await Task.Delay(100); // Simulate some asynchronous work
            }
        }

        public static async Task Main(string[] args)
        {
            await ProcessRecordsAsync();
        }
    }
}
