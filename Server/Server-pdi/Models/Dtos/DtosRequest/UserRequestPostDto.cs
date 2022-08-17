using Models.Entities;

namespace Models.Dtos.DtosRequest
{
    public class UserRequestPostDto
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public AccessType Role { get; set; }
    }
}
