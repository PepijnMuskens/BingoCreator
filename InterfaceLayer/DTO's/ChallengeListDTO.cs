using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.DTO_s
{
    public class ChallengeListDTO
    {
        public string Name { get; private set; }
        public int MaxCardSize { get; private set; }
        public List<ChallengeDTO> Challenges { get; private set; }
    }
}
