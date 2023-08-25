using System;
using System.Collections.Generic;
using System.Text;

namespace Acordes.Infra
{
    public class AcordeCoreException:Exception
    {
        public AcordeCoreException() { }
        public AcordeCoreException(string message) : base(message) { }
        public AcordeCoreException(string message, Exception inner) : base(message, inner) { }

        protected AcordeCoreException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
