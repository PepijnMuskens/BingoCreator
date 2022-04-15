using InterfaceLayer.DTO_s;
using InterfaceLayer.Interfaces;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class SteamGameDAL : ISteamGame , ISteamGames
    {
        private string connectionString = "server=host.docker.internal;user=root;database=steambingo;port=3306;password='';SslMode=none";
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
        public SteamGameDTO GetSteamgame(int id)
        {
            SteamGameDTO dTO = new SteamGameDTO();
            try
            {
                connection.Open();
                query = $"SELECT * FROM games WHERE Id = {id}";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dTO.SteamId = reader.GetInt32(0);
                    dTO.Name = reader.GetString(1);
                    dTO.Challenges = new List<ChallengeDTO>();
                    dTO.ChallengeLists = new List<ChallengeListDTO>();
                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            return dTO;
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

        public List<ChallengeDTO> GetChallenges(int id)
        {
            List<ChallengeDTO> challengeDTOs = new List<ChallengeDTO>();
            try
            {
                connection.Open();
                query = $"SELECT * FROM challenge WHERE GameId = {id}";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChallengeDTO dTO = new ChallengeDTO();
                    dTO.Discription = reader.GetString(1);
                    dTO.StatName = reader.GetString(2);
                    dTO.Value = reader.GetDouble(3);
                    dTO.Difficulty = reader.GetInt32(4);

                    challengeDTOs.Add(dTO);
                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            return challengeDTOs;
        }
    }
}