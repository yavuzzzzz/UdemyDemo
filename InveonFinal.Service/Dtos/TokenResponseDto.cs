using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonFinal.Service.Dtos
{
    public class TokenResponseDto
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }

}
