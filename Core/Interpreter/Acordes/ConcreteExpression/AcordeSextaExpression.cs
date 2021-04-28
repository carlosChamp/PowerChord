using System.Collections.Generic;
using Acordes.DML;

namespace Acordes.Interpreter
{
    public class AcordeSextaExpression : AcordeRegExpExpression
    {
        protected override string ExpressaoAcorde => @"\(?6|(13)\)?";

        protected override List<TipoIntervalo> Intervalos => new List<TipoIntervalo> { TipoIntervalo.SEXTA_MAIOR };

    }
}