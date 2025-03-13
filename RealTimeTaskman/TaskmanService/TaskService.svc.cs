using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TaskmanService.Messaging;

namespace TaskmanService
{
    public class TaskService : ITaskService
    {
        private readonly string _connectionString;// = "Server=localhost;Database=TasksDB;Trusted_Connection=True;";
        public TaskService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }

        public async Task AddTask(string description)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Tasks (Description) VALUES (@Description)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Description", description);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            TaskHub.NotifyNewTask(description);
        }

        public async Task<List<TaskItem>> GetTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Description, CreatedAt FROM Tasks";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new TaskItem
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            CreatedAt = reader.GetDateTime(2)
                        });
                    }
                }
            }
            return tasks;
        }
    }
}