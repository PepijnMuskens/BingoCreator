using Microsoft.AspNetCore.Mvc;
using LogicLayer;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;

namespace SteamBingoCreatorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class ChallengeListController : ControllerBase
    {
        private SteamGameList SteamGameList { get; set; }

        private readonly ILogger<SteamBingoController> _logger;

        public ChallengeListController(ILogger<SteamBingoController> logger)
        {
            _logger = logger;
            SteamGameList = new SteamGameList();

        }
        [EnableCors("CorsPolicy")]
        [HttpGet("GetChallenges")]
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
                foreach (Challenge challenge in challenges)
                {

                }
            }
            catch
            {
                return "failed";
            }
            return "failed";

        }
        [EnableCors("CorsPolicy")]
        [HttpPost("AddChallenge")]
        public async Task<Challenge> AddtoChallengelist(string disc, string statname, int value, int diff, int gameid)
        {
            if (value < 1 || value > 50 || diff > 3 || diff < 1) return null;
            ChallengeList challengeList = new ChallengeList();
            return await challengeList.AddtoChallengelist(disc, statname, value, diff, gameid);
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

    }
}