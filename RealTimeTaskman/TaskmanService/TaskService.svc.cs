using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using TaskmanService.Messaging;

public class TaskService : ITaskService
{
    private readonly string _connectionString;// = "Server=localhost;Database=TasksDB;Trusted_Connection=True;";
    public TaskService()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
    }

    public void AddTask(string description)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "INSERT INTO Tasks (Description) VALUES (@Description)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.ExecuteNonQuery();
            }
        }
        TaskHub.NotifyNewTask(description);
    }

    public List<TaskItem> GetTasks()
    {
        List<TaskItem> tasks = new List<TaskItem>();
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT Id, Description, CreatedAt FROM Tasks";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
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