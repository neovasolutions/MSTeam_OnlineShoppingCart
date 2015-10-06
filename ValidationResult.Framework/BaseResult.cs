using System;
using System.Collections.Generic;

namespace ValidationResult.Framework
{
    public class BaseResult
    {
        public BaseResult()
        {
            Errors = new List<string>();
        }

        public List<string> Errors
        {
            get;
            set;
        }

        public void AddError(string error)
        {
            Errors.Add(error);
            Success = false;
        }

        bool _success = true;

        public virtual bool Success
        {
            get { return _success; }
            set
            {
                _success = value;
                if (_success)
                    Errors.Clear();
            }
        }

        public string Message
        {
            get;
            set;
        }

        public Exception Exception
        {
            get;
            set;
        }

        string _returnValue = string.Empty;

        public string returnValue
        {
            get { return _returnValue; }
            set
            {
                _returnValue = value;
            }
        }
    }
}