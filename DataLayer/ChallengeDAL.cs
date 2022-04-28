using InterfaceLayer.DTO_s;
using InterfaceLayer.Interfaces;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class ChallengeDAL : IChallengeList
    {
        private string connectionString = "server=host.docker.internal;user=root;database=steambingo;port=3306;password='';SslMode=none";
        MySqlConnection connection;
        string query = "";

        public ChallengeDAL()
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
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }

        public int AddToChallengeList(List<ChallengeDTO> challenges, int id)
        {
            throw new NotImplementedException();
        }

        public int CreateChallengeList(string name, int userid, int gameid)
        {
            try
            {
                connection.Open();
                query = $"INSERT INTO `challengelist`(`Name`, `UserId`, `GameId`) VALUES ('{name}',{userid},{gameid})";
                var cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                return 0;
            }
            return 1;
        }

        public ChallengeListDTO GetChallengeList(int id, int userid)
        {
            ChallengeListDTO challengeList = new ChallengeListDTO();
            try
            {
                connection.Open();
                query = $"SELECT challenge.Id, challenge.Discription, challenge.Statname, challenge.Value, challenge.Difficulty, challenge.GameId FROM challengelistchallenge INNER JOIN challenge on challengelistchallenge.challengeId = challenge.Id WHERE challengelistchallenge.Challengelistid = 1; ";
                var cmd = new MySqlCommand(query,connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    challengeList.Id = reader.GetInt32(0);
                    challengeList.Name = reader.GetString(1);
                    challengeList.Gameid = reader.GetInt32(3);
                }
                connection.Close();
                
            }
            catch
            {
                connection.Close();
            }
            return challengeList;
        }

        
    }
}