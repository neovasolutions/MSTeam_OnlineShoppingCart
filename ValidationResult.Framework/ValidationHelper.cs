using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ValidationResult.Framework
{
    public class ValidationHelper
    {
        private ValidationResult_OSC result;

        public ValidationHelper(ref ValidationResult_OSC result, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
            {
                foreach (var value in ModelState.Values)
                {
                    foreach (var err in value.Errors)
                    {
                        result.AddMessage(err.ErrorMessage);
                    }
                }
            }
        }       
    }
}
