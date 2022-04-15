using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO_s;
using InterfaceLayer.Interfaces;
namespace LogicLayer
{
    public class SteamGame
    {
        public string Name { get; set; }
        public int SteamId { get; set; }
        public List<Challenge> Challenges { get; set; }
        public List<ChallengeList> ChallengesLists { get; set;}

        private ISteamGame ISteamGame { get; set; } 
        public SteamGame(SteamGameDTO steamGameDTO)
        {
            Challenges = new List<Challenge>();
            ChallengesLists = new List<ChallengeList>();
            Name = steamGameDTO.Name;
            SteamId = steamGameDTO.SteamId;
            foreach(ChallengeDTO challenge in steamGameDTO.Challenges)
            {
                Challenges.Add(new Challenge(challenge));
            }
            foreach (ChallengeListDTO challengelist in steamGameDTO.ChallengeLists)
            {
                ChallengesLists.Add(new ChallengeList(challengelist));
            }
            ISteamGame = new DataLayer.SteamGameDAL();
        }

        public List<Challenge> GetChallenges()
        {
            List<Challenge> challenges = new List<Challenge>();
            foreach(ChallengeDTO dTO in ISteamGame.GetChallenges(SteamId))
            {
                challenges.Add(new Challenge(dTO));
            }
            return challenges;
        }
    }

}
