using Microsoft.AspNetCore.Mvc;
using LogicLayer;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;

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
        public string Post(string name, int id)
        {
            switch( SteamGameList.AddSteamGame(id, name)){
                case 0:
                    return "error";
                case 1:
                    return "success";
            }
            return "unknown error";
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

    }
}