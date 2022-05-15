using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.DTO_s
{
    public struct SteamGameDTO
    {
        public string Name { get; set; }
        public int SteamId { get; set; }
        public List<ChallengeDTO> Challenges { get; set; }
        public List<ChallengeListDTO> ChallengeLists { get; set; }

        public SteamGameDTO()
        {
            Name = "";
            SteamId = 0;
            Challenges = new List<ChallengeDTO>();
            ChallengeLists = new List<ChallengeListDTO>();
        }
    }

    
}
