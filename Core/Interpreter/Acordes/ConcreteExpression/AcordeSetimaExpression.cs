using System.Collections.Generic;
using Acordes.DML;

namespace Acordes.Interpreter
{
    public class AcordeSetimaExpression : AcordeRegExpExpression
    {
        protected override string ExpressaoAcorde => @"\(?7\)?";

        protected override List<TipoIntervalo> Intervalos => new List<TipoIntervalo> { TipoIntervalo.SETIMA_MENOR };

    }
}