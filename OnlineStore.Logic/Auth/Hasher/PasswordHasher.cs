using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Auth.Hasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password)     
             => BCrypt.Net.BCrypt.EnhancedHashPassword(password); 
        

        public bool Verify(string password, string hashpassword)
            => BCrypt.Net.BCrypt.EnhancedVerify(password, hashpassword);
    }
}
