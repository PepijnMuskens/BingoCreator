using InterfaceLayer.DTO_s;
using InterfaceLayer.Interfaces;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class SteamGameDAL : ISteamGame
    {
        private string connectionString = "server=localhost;user=root;database=steambingo;port=3306;password='';SslMode=none";
        MySqlConnection connection;
        string query = "";

        public SteamGameDAL()
        {
            connection = new MySqlConnection(connectionString);

        }

        public int AddGame(SteamGameDTO game)
        {
            try
            {
                connection.Open();
                query = $"INSERT INTO `games`(`Id`, `Name`) VALUES ('{game.SteamId}','{game.Name}')";
                var cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                return 0;
            }
            return 1;
        }

        public List<SteamGameDTO> GetGamesAll()
        {
            List<SteamGameDTO> steamGameDTOs = new List<SteamGameDTO>();
            try
            {
                connection.Open();
                query = "SELECT * FROM games";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SteamGameDTO dTO = new SteamGameDTO();
                    dTO.SteamId = reader.GetInt32(0);
                    dTO.Name = reader.GetString(1);
                    dTO.Challenges = new List<ChallengeDTO>();
                    dTO.ChallengeLists = new List<ChallengeListDTO>();
                    
                    steamGameDTOs.Add(dTO);
                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            return steamGameDTOs;
        }
    }
}