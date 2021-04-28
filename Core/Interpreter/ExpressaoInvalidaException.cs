using System;
using System.Collections.Generic;
using System.Text;

namespace Acordes.Interpreter
{

    [System.Serializable]
    public class ExpressaoInvalidaException : Exception
    {
        public ExpressaoInvalidaException() { }
        public ExpressaoInvalidaException(string message) : base(message) { }
        public ExpressaoInvalidaException(string message, Exception inner) : base(message, inner) { }
        
        protected ExpressaoInvalidaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    
}
