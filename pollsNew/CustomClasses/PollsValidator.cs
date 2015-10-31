using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace pollsNew.CustomClasses
{
    public class PollsValidator: IValidator
    {
        public PollsValidator(string message)
            {
                ErrorMessage = message;
                IsValid = false;
            } 

            public string ErrorMessage { get; set; }
            public bool IsValid { get; set; }
            public void Validate()
            {
                // no action required
            }
    }
}