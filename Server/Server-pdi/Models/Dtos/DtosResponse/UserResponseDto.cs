using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Dtos.DtosResponse
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }

        public static UserResponseDto Response(User user) =>
            new(user.Id, user.Name, user.Login, user.Role);

        public UserResponseDto(Guid id, string name, string login, AccessType role)
        {
            Id = id;
            Name = name;
            Login = login;
            Role = role.ToString();
        }

    }
    public class UsersResponseDto
    {
        public UsersResponseDto(IEnumerable<User> user)
        {
            Users = user
                .Select(UserResponseDto.Response)
                .OrderBy(element => element.Name);
        }
        public IEnumerable<UserResponseDto> Users { get; set; }
    }
}
