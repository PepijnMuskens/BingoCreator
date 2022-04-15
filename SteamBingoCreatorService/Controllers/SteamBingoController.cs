using Microsoft.AspNetCore.Mvc;
using LogicLayer;
using System.Text.Json;
namespace SteamBingoCreatorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SteamBingoController : ControllerBase
    {
        private SteamGameList SteamGameList { get; set; }

        private readonly ILogger<SteamBingoController> _logger;

        public SteamBingoController(ILogger<SteamBingoController> logger)
        {
            _logger = logger;
            SteamGameList = new SteamGameList();

        }

        [HttpGet("GetSteamGames")]
        public IEnumerable<SteamGame> Get()
        {
            return SteamGameList.GetAllSteamGames().ToArray();
        }

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

        [HttpGet("GetChallengesGame")]
        public IEnumerable<Challenge> Get(int id)
        {
            SteamGame steamGame = SteamGameList.GetSteamGame(id);
            return steamGame.GetChallenges();
        }

        [HttpPost("AddToChallengeList")]
        public string Post(string challengesJson, int challengelistid)
        {
            try
            {
                
                List<Challenge> challenges = JsonSerializer.Deserialize<List<Challenge>>(challengesJson);
                foreach(Challenge challenge in challenges)
                {
                    challenge
                }
            }
            catch
            {
                return "failed";
            }
            
            
        }

        [HttpPost("CreateChallengeList")]
        public string CreateChallengeList(string name, int gameid, int userid)
        {
            User user = new User(new InterfaceLayer.DTO_s.UserDTO() { Id = 1, Name = "Pepijn"});
            user.CreateChallengelist(name, gameid);
            return "succes";
        }

        [HttpGet("GetChallengeList")]
        public string GetChallengeList(int id)
        {

        }

    }
}