using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class JwtToken
    {
        public string Token { get; set; }
        public JwtToken() { }

        public JwtToken(string token)
        {
            Token = token;
        }
    }
}
