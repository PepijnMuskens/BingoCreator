using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO_s;
using InterfaceLayer.Interfaces;

namespace LogicLayer
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Discription { get; set; }
        public string StatName { get; set; }
        public double Value { get; set; }
        public int Difficulty { get; set; }
        public int Gameid { get; set; }

        public Challenge(ChallengeDTO challengeDTO)
        {
            Id = challengeDTO.Id;
            Discription = challengeDTO.Discription;
            StatName = challengeDTO.StatName;
            Value = challengeDTO.Value;
            Difficulty = challengeDTO.Difficulty;
            Gameid = challengeDTO.Gameid;
        }

        public int Edit()
        {
            IChallenge Ichallenge = new DataLayer.ChallengeDAL();
            return Ichallenge.Edit(Id, StatName, Discription, Difficulty);
        }

    }
}
