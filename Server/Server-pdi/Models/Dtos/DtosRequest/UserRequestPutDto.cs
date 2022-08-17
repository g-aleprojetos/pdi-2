using Models.Entities;
using System;

namespace Models.Dtos.DtosRequest
{
    public class UserRequestPutDto
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public AccessType Role { get; set; } = AccessType.NULL;
    }
}
