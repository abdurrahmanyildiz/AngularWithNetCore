using AngularWithNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWithNetCore.Repos.Abstract
{
    public interface IAuthRepo
    {
        bool UserExists(string userName);
        User Register(User user, string password);
        User Login(string userName, string password);
    }
}
