using DataAccessLayer.Access;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class AccountBL
    {
        private readonly Account _accountDAL;
        public AccountBL(Account accountDAL)
        {
            this._accountDAL = accountDAL;
        }
        public Task<IdentityResult> CreateUser(Register model)
        {
            var result = _accountDAL.CreateUser(model);
            return result;
        }

        public Task<SignInResult> CheckUser(Login model)
        {
            var result = _accountDAL.CheckUser(model);

            return result;
        }
        
        public Task<IdentityUser> GetUser(string name)
        {
            var user = _accountDAL.GetUser(name);

            return user;
        }
    }
}
