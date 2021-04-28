using System.Collections.Generic;
using Acordes.DML;

namespace Acordes.Interpreter
{

    public class AcordeQuartaExpression : AcordeRegExpExpression
    {
        protected override string ExpressaoAcorde => @"\(?4|(11)\)?";

        protected override List<TipoIntervalo> Intervalos => new List<TipoIntervalo> { TipoIntervalo.QUARTA_JUSTA };
    }
}