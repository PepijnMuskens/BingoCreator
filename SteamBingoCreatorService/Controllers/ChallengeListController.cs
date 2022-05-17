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
        [HttpPost("AddChallenge")]
        public async Task<Challenge> AddChallenge(string disc, string statname, int value, int diff, int gameid)
        {
            if (value < 1 || value > 50 || diff > 3 || diff < 1) return null;
            ChallengeList challengeList = new ChallengeList();
            return await challengeList.AddChallenge(disc, statname, value, diff, gameid);
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("AddToChallengeList")]
        public async Task<Challenge> AddToChallengeList(int challengelistid, int challengeid)
        {
            ChallengeList challengeList = new ChallengeList();
            return challengeList.AddToChallengeList(challengelistid, challengeid);
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("CreateChallengeList")]
        public string CreateChallengeList(string name, int gameid)
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