using InterfaceLayer.DTO_s;
using InterfaceLayer.Interfaces;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class ChallengeDAL : IChallengeList
    {
        private string connectionString = "Server=am1.fcomet.com;Uid=steambin_steambin;Database=steambin_Data;Pwd=Appels1peren0";
        //private string connectionString = "Server=studmysql01.fhict.local;Uid=dbi437675;Database=dbi437675;Pwd=1234";
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

        public ChallengeDTO AddtoChallengelist(string disc, string statname, int value, int diff, int gameid)
        {
            ChallengeDTO challenge = new ChallengeDTO();
            try
            {
                connection.Open();
                query = $"INSERT INTO `challenge`(`Discription`, `Statname`, `Value`, `Difficulty`, `GameId`) VALUES ('{disc}','{statname}',{value},{diff},{gameid})";
                var cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                challenge.Value = value;
                challenge.Gameid = gameid;
                challenge.StatName = statname;
                challenge.Difficulty = diff;
                challenge.Discription = disc;
            }
            catch
            {
                connection.Close();
            }
            return challenge;
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
            challengeList.Id = id;
            try
            {
                connection.Open();
                query = $"SELECT challengelist.Name, challenge.Id, challenge.Discription, challenge.Statname, challenge.Value, challenge.Difficulty, challenge.GameId FROM challengelistchallenge INNER JOIN challenge on challengelistchallenge.challengeId = challenge.Id INNER JOIN challengelist on challengelistchallenge.Challengelistid = challengelist.Id WHERE challengelistchallenge.Challengelistid = {id} AND challengelist.UserId = {userid};";
                var cmd = new MySqlCommand(query,connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    challengeList.Name = reader.GetString(reader.GetOrdinal("Name"));
                    ChallengeDTO challengeDTO = new ChallengeDTO();
                    challengeDTO.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    challengeDTO.Discription = reader.GetString(reader.GetOrdinal("Discription"));
                    challengeDTO.StatName = reader.GetString(reader.GetOrdinal("Statname"));
                    challengeDTO.Value = reader.GetDouble(reader.GetOrdinal("Value"));
                    challengeDTO.Difficulty = reader.GetInt32(reader.GetOrdinal("Difficulty"));
                    challengeDTO.Gameid = reader.GetInt32(reader.GetOrdinal("GameId"));

                    challengeDTO.Discription = challengeDTO.Discription.Replace('@', Convert.ToChar((int)challengeDTO.Value + 48));
                    if (challengeDTO.Value > 1)
                    {
                        challengeDTO.Discription = challengeDTO.Discription.Replace('$', 's');
                    }
                    else if (challengeDTO.Discription.Contains('$'))
                    {
                        challengeDTO.Discription = challengeDTO.Discription.Remove(challengeDTO.Discription.IndexOf('$'), 1);
                    }
                    challengeList.Challenges.Add(challengeDTO);
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