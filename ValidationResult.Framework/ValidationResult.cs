using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ValidationResult.Framework
{
    public class Result<T> : BaseResult
    {
        public T Data
        {
            get;
            set;
        }
    }

    public class ValidationResult_OSC : BaseResult
    {
        public ValidationResult_OSC()
        {
            ValidationMessages = new List<string>();
        }

        public List<string> ValidationMessages
        {
            get;
            set;
        }

        bool _success = true;

        public override bool Success
        {
            get { return _success; }
            set
            {
                _success = value;
                if (_success && ValidationMessages != null)
                    ValidationMessages.Clear();
            }
        }

        public void AddMessage(string msg)
        {
            Message = "Failed Validation:";    // can give more appropriate message
            ValidationMessages.Add(msg);
            Success = false;
        }
    }
}
