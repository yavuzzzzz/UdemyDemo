using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonFinal.Service.Dtos.UserDtos
{
    public class UserResponseDto
    {
        public string Id { get; set; } = default!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
