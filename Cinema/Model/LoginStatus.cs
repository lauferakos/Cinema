using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class LoginStatus
    {
        public bool LoggedIn { get; set; }

        public int UserId { get; set; }

        public LoginStatus(bool loggedin, int userid)
        {
            LoggedIn = loggedin;
            UserId = userid;
        }
    }
}
