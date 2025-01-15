using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystemWPF
{
    public class PasswordHasher
    {
        static PasswordHasher instance;
        byte[] salt;
        PasswordHasher(){}
        public static PasswordHasher GetInstance()
        {
            if(instance == null)
            {
                byte[] salt = new byte[16];
                for(int i = 0; i<16; i++)
                {
                    salt[i] = (byte)i;
                }
                instance = new PasswordHasher();
                instance.salt = salt;
            }
            return instance;
        }

        public string HashPassword(string password)
        {

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combine salt and hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert to base64 string
            return Convert.ToBase64String(hashBytes);
        }
        public bool VerifyPassword(string password, string storedHash)
        {
            return password==storedHash;
        }
    }
}
