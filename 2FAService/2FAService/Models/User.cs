using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2FAService.Models
{
    public class User
    {
        public long UserId { get; set; }

        public Guid UserKey { get; set; }

        public string Nome { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool HasTwoFactor { get; set; }

        public string SecretKey256 { get; set; }

        public string SecretKey { get; set; }
    }
}