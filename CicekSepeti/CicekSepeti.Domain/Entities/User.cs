using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Domain.Entities
{
    public class User
    {
        //public User()
        //{

        //}
        //public User(string name, string password)
        //{
        //    Id = Guid.NewGuid();
        //    AccountName = name;
        //    AccountPassword = password;
        //}

        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }

        
    }
}
