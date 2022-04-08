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
        private ISteamGame ISteamGame { get; set; }
        public SteamGameList()
        {
            SteamGames = new List<SteamGame>();
            ISteamGame = new SteamGameDAL();
        }

        public List<SteamGame> GetAllSteamGames()
        {
            foreach(SteamGameDTO steamGameDTO in ISteamGame.GetGamesAll())
            {
                SteamGames.Add(new SteamGame(steamGameDTO));
            }
            return SteamGames;
        }

        public int AddSteamGame(int id, string name)
        {
            return ISteamGame.AddGame(new SteamGameDTO { SteamId = id, Name = name });
        } 
    }
}
