using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Dtos
{
    public class IdentityUserTokenDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
