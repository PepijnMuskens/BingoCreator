using Microsoft.AspNetCore.Mvc;
using LogicLayer;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;

namespace SteamBingoCreatorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class SteamBingoController : ControllerBase
    {
        private SteamGameList SteamGameList { get; set; }

        private readonly ILogger<SteamBingoController> _logger;

        public SteamBingoController(ILogger<SteamBingoController> logger)
        {
            _logger = logger;
            SteamGameList = new SteamGameList();

        }
        [EnableCors("CorsPolicy")]
        [HttpGet("GetSteamGames")]
        public IEnumerable<SteamGame> Get()
        {
            return SteamGameList.GetAllSteamGames().ToArray();
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("GetSteamGame")]
        public SteamGame GetSteamGame(int id)
        {
            return SteamGameList.GetSteamGame(id);
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("AddSteamGame")]
        public SteamGame Post(string name, int id)
        {
           return SteamGameList.AddSteamGame(id, name);
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("GetChallengesGame")]
        public IEnumerable<Challenge> Get(int id)
        {
            SteamGame steamGame = SteamGameList.GetSteamGame(id);
            return steamGame.GetChallenges();
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("AddToChallengeList")]
        public string AddtoChallengelist(string challengesJson, int challengelistid)
        {
            try
            {
                
                List<Challenge> challenges = JsonSerializer.Deserialize<List<Challenge>>(challengesJson);
                foreach(Challenge challenge in challenges)
                {
                    challenges.Add(challenge);
                }
            }
            catch
            {
                return "failed";
            }
            return "failed";

        }

        [EnableCors("CorsPolicy")]
        [HttpPost("CreateChallengeList")]
        public string CreateChallengeList(string name, int gameid, int userid)
        {
            User user = new User(new InterfaceLayer.DTO_s.UserDTO() { Id = 1, Name = "Pepijn"});
            user.CreateChallengelist(name, gameid);
            return "succes";
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("GetChallengeList")]
        public ChallengeList GetChallengeList(int id)
        {
            User user = new User(new InterfaceLayer.DTO_s.UserDTO() { Id = 1, Name = "Pepijn" });
            return user.GetChallengeList(id);
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("GetStats")]
        public async Task<List<string>> GetStats(int id)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync("https://api.steampowered.com/ISteamUserStats/GetSchemaForGame/v2/?key=B28FAD6C2B1A54EA2342EA465206F5A7&appid=" + id);
            JObject data = JObject.Parse(response);
            IEnumerable<JToken> tokens = data.SelectTokens("game.availableGameStats.stats[?(@.name !='')].name");
            List<string> stats = new List<string>();
            foreach(JToken token in tokens)
            {
                stats.Add(token.ToString());
            }
            return stats;
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("EditChallenge")]
        public Challenge EdditChallenge(int id, string discription, string statname)
        {
            Challenge challenge = new Challenge(new InterfaceLayer.DTO_s.ChallengeDTO { Id = id, Discription = discription, StatName = statname });
            int result = challenge.Edit();
            if(result == 1)
            {
                return challenge;
            }
            else { return null; }
        }

    }
}