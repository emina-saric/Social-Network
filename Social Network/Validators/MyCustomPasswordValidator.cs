using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Social_Network.Validators
{
    class MyCustomPasswordValidator: PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string password)
        {

            IdentityResult result = await base.ValidateAsync(password);

            if (password.Contains("abcdef") || password.Contains("123456"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Password can not contain sequence of chars");
                result = new IdentityResult(errors);
            }

            return result;
        }
    }
}
