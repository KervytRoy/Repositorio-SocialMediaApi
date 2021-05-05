using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.CustomEntities
{
    public class TokenClaims
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}
