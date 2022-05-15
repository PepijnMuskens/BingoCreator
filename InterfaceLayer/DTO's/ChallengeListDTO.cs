using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.DTO_s
{
    public class ChallengeListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gameid { get; set; }
        public int MaxCardSize { get; set; }
        public List<ChallengeDTO> Challenges { get; set; }

        public ChallengeListDTO()
        {
            Challenges = new List<ChallengeDTO>();
            Name = "";
        }
    }
}
