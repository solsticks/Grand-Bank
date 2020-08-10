using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankApp.ClassLib
{
    class utility
    {
        public void createSession(string Id, string Name, string Email, string pass)
        {
            // create login session
            LoggingDetails.Id = Id;
            LoggingDetails.Email = Name;
            LoggingDetails.Password = pass;
        }
    }
}
