using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCrypt.Net;

namespace ktms
{
    public class Authentication
    {
        public bool ValidateUser(string username, string password)
        {
            // For testing purposes, let's consider a simple hardcoded user/password combination
            string validUsername = "norman@gmail.com";
            string validPassword = "$2a$11$uhhaxkyx26TWOrvC1pICf.Y2aQ.Sku4ovMxgkfzUCeCFxCLkb334a";
            
            
            // Compare the provided username and password with the valid credentials
            if (username == validUsername && VefifyHash(password, validPassword))
            {
                return true;
            }
            else
            {
                // Users can enter whatever email or password for now
                //return false;

                return true;
            }
        }
        private bool VefifyHash(string password, string validPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, validPassword);
        }
    }
}