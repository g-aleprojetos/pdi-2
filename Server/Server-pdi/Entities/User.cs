namespace Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public AccessType Role { get; set; }
        public string Token { get; set; }
    }





    public enum AccessType
    {
        ADM,
        USER,
        NULL
    }
}
