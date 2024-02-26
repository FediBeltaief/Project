using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Project
{
    public class Admin
    {
        [PrimaryKey]
        public int Id { get; set; }
        [NotNull]
        public string username { get; set; }
        [NotNull]
        public string password { get; set; }

        public Admin(string user,string pass)
        {
            Id = 1;
            username = user;
            password = pass;
        }
        public Admin()
        {

        }
    }
}
