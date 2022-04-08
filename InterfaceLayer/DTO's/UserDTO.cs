using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.DTO_s
{
    public  struct UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SteamId { get; set; }
        public string Email { get; set; }
    }
}
