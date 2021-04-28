using System.Collections.Generic;
using Acordes.DML;

namespace Acordes.Interpreter
{
    public class AcordeNonaExpression : AcordeRegExpExpression
    {
        protected override string ExpressaoAcorde => @"\(?[29]\)?";

        protected override List<TipoIntervalo> Intervalos => new List<TipoIntervalo> { TipoIntervalo.SEGUNDA_MAIOR };
    }
}