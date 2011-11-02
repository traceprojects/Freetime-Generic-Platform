using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Freetime.Data.Services
{
    public class ClientValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null)
                throw new ArgumentNullException("userName");

            if (password == null)
                throw new ArgumentNullException("password");

            throw new Exception("Hello World");
        }
    }
}
