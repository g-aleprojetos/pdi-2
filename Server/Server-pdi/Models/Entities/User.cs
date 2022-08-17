using Models.Dtos.DtosRequest;
using Services;

namespace Models.Entities
{
    public class User : BaseEntity
    {

        public string Login { get; set; }
        public string Password { get; set; }
        public AccessType Role { get; set; }
        // public string Token { get; set; }

        public User() { }

        public User(string name, string login, string password, AccessType role)
        {
            Name = name;
            Login = login;
            Password = password;
            Role = role;
        }

        public void UpdateUser(UserRequestPutDto userRequestPutDto)
        {
            if (userRequestPutDto.Name != null) Name = userRequestPutDto.Name;
            if (userRequestPutDto.Login != null) Login = userRequestPutDto.Login;
            if (userRequestPutDto.Password != null) Password = Encrypting(userRequestPutDto.Password);
            if (userRequestPutDto.Role != AccessType.NULL) Role = userRequestPutDto.Role;
        }

        public string Encrypting(string valor)
        {
            var encryptedPassword = new Cryptography();
            return encryptedPassword.Encrypt(valor);
        }
    }






    public enum AccessType
    {
        ADM,
        USER,
        NULL
    }
}
