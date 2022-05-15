using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.DTO_s
{
    public struct ChallengeDTO
    {
        public int Id { get; set; }
        public string Discription { get; set; }
        public string StatName { get; set; }
        public double Value { get; set; }
        public int Difficulty { get; set; }
        public int Gameid { get; set; }

    }
}
