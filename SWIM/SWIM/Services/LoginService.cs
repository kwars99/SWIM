using SWIM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWIM.Services
{
    public class LoginService
    {
        public bool CredentialCheck(string username, string password)
        {
            return username == Constants.Email && password == Constants.Password;
        }
    }
}
