using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO_s;

namespace LogicLayer
{
    public class SteamGame
    {
        public string Name { get; set; }
        public int SteamId { get; set; }
        public List<Challenge> Challenges { get; set; }
        public List<ChallengeList> ChallengesLists { get; set;}
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
        }
    }

}
