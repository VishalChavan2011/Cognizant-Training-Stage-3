using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersManagerLib
{
    class PlayerMapper : IPlayerMapper
    {
        private readonly string _connectionString = "Data Source=(local);Initial Catalog=GameDB;Integrated Security=True";

        public bool IsPlayerNameExistsInDb(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open(); using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT count(*) FROM Player WHERE 'Name' = @name";
                    command.Parameters.AddWithValue("@name", name);
                }
                //Get the number of player with this name var existing
                PlayersCount = (int)command.ExecuteScalar();
                // Result is 0, if no player exists, or 1, if a player already exists
                return existingPlayersCount > 0;
            }
        }
    }
    public void AddNewPlayerIntoDb(string name)
    { 
        using (SqlConnection connection = new SqlConnection(connectionString))
        { connection.Open(); using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT   INTO   Player   ([Name])  VALUES (@name)"; 
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            } 
        } 
    }

}

