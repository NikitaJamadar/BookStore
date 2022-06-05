using BusinessLayer.Interfaces;
using DataBaseLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.services
{
    public class UserBL: IUserBL
    {
        public IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        //method for user registration
        public UserModel Register(UserModel user)
        {
            try
            {
                return this.userRL.Register(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Method for user login
        public UserLogin Login(string Email, string Password)
        {
            try
            {
                return this.userRL.Login(Email, Password);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
