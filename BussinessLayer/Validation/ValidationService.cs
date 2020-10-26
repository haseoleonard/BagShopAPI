using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Validation
{
    public class ValidationService : IValidationService
    {
        //private ModelStateDictionary
        public bool isValid => throw new NotImplementedException();

        public void AddError(string key, string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
