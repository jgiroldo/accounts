﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Business.Exceptions
{

    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException() { }
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, Exception inner) : base(message, inner) { }
    }

}
