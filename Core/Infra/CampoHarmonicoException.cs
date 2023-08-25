using System;
using System.Collections.Generic;
using System.Text;

namespace Acordes.Infra
{
    public class CampoHarmonicoException:AcordeCoreException
    {
        public CampoHarmonicoException() { }
        public CampoHarmonicoException(string message) : base(message) { }
        public CampoHarmonicoException(string message, Exception inner) : base(message, inner) { }

        protected CampoHarmonicoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
