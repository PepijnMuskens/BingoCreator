using InterfaceLayer.DTO_s;
using InterfaceLayer.Interfaces;

namespace LogicLayer
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string SteamId { get; private set; }
        public string Email { get; private set; }

        private IChallengeList IChallengeList;

        public User(UserDTO userDTO)
        {
            Id = userDTO.Id;
            Username = userDTO.Name;
            SteamId = userDTO.SteamId;
            Email = userDTO.Email;

            IChallengeList = new DataLayer.ChallengeDAL();
        }

        public int CreateChallengelist(string name, int gameid)
        {
            return IChallengeList.CreateChallengeList(name, Id, gameid);
        }

        public ChallengeList GetChallengeList(int id)
        {
            return new ChallengeList(IChallengeList.GetChallengeList(id, Id));
        }


    }
}