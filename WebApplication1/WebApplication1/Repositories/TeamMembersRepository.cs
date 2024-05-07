using WebApplication1.Models;

namespace WebApplication1.Repositories;
using Microsoft.Data.SqlClient;

public class TeamMembersRepository
{
    private readonly string _connectionString;

    public TeamMembersRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public TeamMember GetTeamMeberById(int id)
    {
        TeamMember teamMember = null;
        using (var conn = new SqlConnection(_connectionString))
        {
            var sql = "SELECT IdTeamMember, FirstName, LastName, Email FROM TeamMember WHERE IdTeamMember = @IdTeamMember";
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IdTeamMember", id);
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    teamMember = new TeamMember
                    {
                        IdTeamMember = (int)reader["IdTeamMember"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString()
                    };
            }
        }

        return teamMember;
    }
}