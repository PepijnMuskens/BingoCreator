using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO_s;
namespace InterfaceLayer.Interfaces
{
    public interface ISteamGames
    {
        public List<SteamGameDTO> GetGamesAll();
        public SteamGameDTO GetSteamgame(int id);
        public SteamGameDTO AddGame(int id, string name);
    }
}
