using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO_s;

namespace LogicLayer
{
    public class ChallengeList
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int MaxCardSize { get; private set; }
        public List<Challenge> Challenges { get; private set; }

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
        }

        public ChallengeList(string name)
        {
            Name=name;
            Challenges = new List<Challenge>();
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
    }
}
