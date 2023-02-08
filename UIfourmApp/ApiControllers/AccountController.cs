using FourmApplication.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace UIfourmApp.ApiControllers
{
    public class AccountController : ApiController
    {
        IUsersservice us;
        public AccountController(IUsersservice us)
        {
            this.us = us;
        }

        public string Get(string Email)
        {
            if (this.us.GetUserByEmail(Email) != null)
            {
                return "Found";
            }
            else
            {
                return "Not Found";
            }
        }
    }
}