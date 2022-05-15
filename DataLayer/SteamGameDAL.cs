using InterfaceLayer.DTO_s;
using InterfaceLayer.Interfaces;
using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace DataLayer
{
    public class SteamGameDAL : ISteamGame , ISteamGames
    {
        private string connectionString = "Server=am1.fcomet.com;Uid=steambin_steambin;Database=steambin_Data;Pwd=Appels1peren0";
        //private string connectionString = "Server=studmysql01.fhict.local;Uid=dbi437675;Database=dbi437675;Pwd=1234";
        MySqlConnection connection;
        string query = "";

        ChallengeDAL challengeDAL;

        public SteamGameDAL()
        {
            connection = new MySqlConnection(connectionString);
            challengeDAL = new ChallengeDAL();
        }

        public SteamGameDTO AddGame(int id, string name)
        {
            SteamGameDTO game = new SteamGameDTO();
            try
            {
                connection.Open();
                query = $"SELECT * FROM `games` WHERE Id = {id} OR Name = '{name}'";
                var cmd1 = new MySqlCommand(query, connection);
                if(cmd1.ExecuteScalar() != null)
                {
                    connection.Close();
                    return game;
                }
                connection.Close();
                connection.Open();
                query = $"INSERT INTO `games`(`Id`, `Name`) VALUES ('{id}','{name}')";
                var cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                game.SteamId = id;
                game.Name = name;
            }
            catch(Exception ex)
            {

            }
            return game;
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
                
                dTO.Challenges = GetChallenges(id);
                dTO.ChallengeLists = GetChallengeLists(id);
            }
            catch (Exception ex)
            {
                connection.Close();
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
                connection.Close();
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
                    dTO.Discription = dTO.Discription.Replace('@', Convert.ToChar((int)dTO.Value + 48));
                    if (dTO.Value > 1)
                    {
                        dTO.Discription = dTO.Discription.Replace('$', 's');
                    }
                    else if(dTO.Discription.Contains('$'))
                    {
                        dTO.Discription = dTO.Discription.Remove(dTO.Discription.IndexOf('$'),1);
                    }
                    challengeDTOs.Add(dTO);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return challengeDTOs;
        }
        public List<ChallengeListDTO> GetChallengeLists(int id)
        {
            List<ChallengeListDTO> dtos = new List<ChallengeListDTO>();
            try
            {
                connection.Open();
                query = $"SELECT * FROM challengelist WHERE GameId = {id}";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChallengeListDTO dto = new ChallengeListDTO();
                    dto.Id = reader.GetInt32(0);
                    dto.Name = reader.GetString(1);

                    dtos.Add(dto);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return dtos;
        }
    }
}