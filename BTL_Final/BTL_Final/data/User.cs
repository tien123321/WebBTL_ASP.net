using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_Final.data
{
    public class User
    {
        public string email {  get; set; }
        public string nameAccount { get; set; }
        public string nameUser { get; set; }
        public string password { get; set; }
        public User() { }

        public User(string email, string nameAccount, string nameUser, string password)
        {
            this.email = email;
            this.nameAccount = nameAccount;
            this.nameUser = nameUser;
            this.password = password;
        }

    }
}