﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    internal class UserAccount
    {
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public UserAccount(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
