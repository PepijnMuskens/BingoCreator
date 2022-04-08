using InterfaceLayer.DTO_s;

namespace LogicLayer
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string SteamId { get; private set; }
        public string Email { get; private set; }

        public User(UserDTO userDTO)
        {
            Id = userDTO.Id;
            Username = userDTO.Name;
            SteamId = userDTO.SteamId;
            Email = userDTO.Email;
        }


    }
}