using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        public UserModel Register(UserModel user);
        public UserLogin Login(string Email, string Password);
    }
}
