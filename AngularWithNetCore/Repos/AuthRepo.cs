using AngularWithNetCore.Models;
using AngularWithNetCore.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWithNetCore.Repos
{
    public class AuthRepo: IAuthRepo
    {
        //ctorda dbcontext çağırılmalı

        public User Login(string userName, string password)
        {
            var user = new User(); //Get(u => u.username == userName);
            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public User Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;
            user.UpdateDate = DateTime.UtcNow;
            
           // context.SaveChanges();

           

           // Add(user);

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool UserExists(string userName)
        {
            //if (Get(u => u.username == userName || u.email == userName) != null)
            //{
            //    return true;
            //}

            return false;
        }

    }
}
