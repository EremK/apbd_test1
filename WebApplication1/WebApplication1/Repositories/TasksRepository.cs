using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class TasksRepository
{
    private readonly string _connectionString;

    public TasksRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public Task_ GetCreatedTaskById(int id)
    {
        Task_ createdTask = null;
        using (var conn = new SqlConnection(_connectionString))
        {
            var sql = @"
            SELECT IdTask, Name, Description, Deadline, IdProject, IdTaskType, IdAssignedTo, IdCreator
            FROM Task
            WHERE IdCreator = @IdCreator";
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IdCreator", id);
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    createdTask = new Task_(
                        (int)reader["IdTask"],
                        reader["Name"].ToString(),
                        reader["Description"].ToString(),
                        (DateTime)reader["Deadline"],
                        (int)reader["IdProject"],
                        (int)reader["IdTaskType"],
                        (int)reader["IdAssignedTo"],
                        (int)reader["IdCreator"]
                    );
                }
            }
        }

        return createdTask;
    }
    
    public Task_ GetAssignedTaskById(int id)
    {
        Task_ createdTask = null;
        using (var conn = new SqlConnection(_connectionString))
        {
            var sql = @"
            SELECT IdTask, Name, Description, Deadline, IdProject, IdTaskType, IdAssignedTo, IdCreator
            FROM Task
            WHERE IdAssignedTo = @IdAssignedTo";
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IdAssignedTo", id);
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    createdTask = new Task_(
                        (int)reader["IdTask"],
                        reader["Name"].ToString(),
                        reader["Description"].ToString(),
                        (DateTime)reader["Deadline"],
                        (int)reader["IdProject"],
                        (int)reader["IdTaskType"],
                        (int)reader["IdAssignedTo"],
                        (int)reader["IdCreator"]
                    );
                }
            }
        }

        return createdTask;
    }

}