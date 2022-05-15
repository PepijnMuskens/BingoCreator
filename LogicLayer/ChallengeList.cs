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
        public List<Challenge> Challenges { get; private set; }
        public IChallengeList IChallengelist { get; private set; }

        public ChallengeList(ChallengeListDTO challengeListDTO)
        {
            Id = challengeListDTO.Id;
            Name = challengeListDTO.Name;
            MaxCardSize = challengeListDTO.MaxCardSize;
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

        public int AddChallenge(Challenge challenge)
        {
            foreach(Challenge challenge1 in Challenges)
            {
                if(challenge1.StatName == challenge.StatName)
                {
                    return 0;
                }
            }
            Challenges.Add(challenge);
            return 1;
        }

        public async Task<Challenge> AddtoChallengelist(string disc, string statname, int value, int diff, int gameid)
        {
            return new Challenge( IChallengelist.AddtoChallengelist(disc, statname, value, diff, gameid));
        }
    }
}
