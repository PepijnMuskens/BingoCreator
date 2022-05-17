using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO_s;
using InterfaceLayer.Interfaces;

namespace LogicLayer
{
    public class ChallengeList
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int MaxCardSize { get; private set; }
        public int GameId { get;private set; }
        public List<Challenge> Challenges { get; private set; }
        public IChallengeList IChallengelist { get; private set; }

        public ChallengeList(ChallengeListDTO challengeListDTO)
        {
            Id = challengeListDTO.Id;
            Name = challengeListDTO.Name;
            MaxCardSize = challengeListDTO.MaxCardSize;
            GameId = challengeListDTO.Gameid;
            Challenges = new List<Challenge>();
            foreach(ChallengeDTO challengeDTO in challengeListDTO.Challenges)
            {
                Challenges.Add(new Challenge(challengeDTO));
            }
            IChallengelist = new DataLayer.ChallengeDAL();
        }
        public ChallengeList()
        {
            Name = "";
            Challenges = new List<Challenge>();
            IChallengelist = new DataLayer.ChallengeDAL();
        }

        public ChallengeList(string name)
        {
            Name=name;
            Challenges = new List<Challenge>();
            IChallengelist = new DataLayer.ChallengeDAL();
        }

        public Challenge AddToChallengeList(int challengelistid, int  challengeid)
        {
            return new Challenge(IChallengelist.AddToChallengeList(challengelistid, challengeid));
        }

        public async Task<Challenge> AddChallenge(string disc, string statname, int value, int diff, int gameid)
        {
            return new Challenge( IChallengelist.AddChallenge(disc, statname, value, diff, gameid));
        }
    }
}
