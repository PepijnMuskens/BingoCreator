using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO_s;
namespace InterfaceLayer.Interfaces
{
    public interface IChallengeList
    {
        public int CreateChallengeList(string name, int userid, int gameid);
        public ChallengeListDTO GetChallengeList(int id, int userid);
        public ChallengeDTO AddtoChallengelist(string disc, string statname, int value, int diff, int gameid);


    }
}
