﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO_s;
namespace InterfaceLayer.Interfaces
{
    public interface ISteamGame
    {
        public List<ChallengeDTO> GetChallenges(int id);
        
    }
}
