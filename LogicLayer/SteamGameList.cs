using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.Interfaces;
using DataLayer;
using InterfaceLayer.DTO_s;
namespace LogicLayer
{
    public class SteamGameList
    {
        public List<SteamGame> SteamGames { get; set; }
        private ISteamGames ISteamGames { get; set; }
        public SteamGameList()
        {
            SteamGames = new List<SteamGame>();
            ISteamGames = new SteamGameDAL();
        }

        public List<SteamGame> GetAllSteamGames()
        {
            foreach(SteamGameDTO steamGameDTO in ISteamGames.GetGamesAll())
            {
                SteamGames.Add(new SteamGame(steamGameDTO));
            }
            return SteamGames;
        }
        public SteamGame GetSteamGame(int id)
        {
            return new SteamGame(ISteamGames.GetSteamgame(id));
        }

        public int AddSteamGame(int id, string name)
        {
            return ISteamGames.AddGame(new SteamGameDTO { SteamId = id, Name = name });
        } 
    }
}
