using DataBaseLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL:IUserRL
    {
        private SqlConnection sqlConnection;
        public UserRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        private IConfiguration Configuration { get; }

        //Method for user registration
        public UserModel Register(UserModel user)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.Configuration["ConnectionStrings:BookStore"]);
                //Adding stored procedure name and connction
                SqlCommand com = new SqlCommand("Registeruser", this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //Adding all parameters to stored proecedure
                com.Parameters.AddWithValue("@FullName", user.FullName);
                com.Parameters.AddWithValue("@Email", user.Email);
                com.Parameters.AddWithValue("@Password", user.Password);
                com.Parameters.AddWithValue("@PhoneNumber", user.Phone);
                this.sqlConnection.Open();
                int result = com.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (result >= 1)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}
