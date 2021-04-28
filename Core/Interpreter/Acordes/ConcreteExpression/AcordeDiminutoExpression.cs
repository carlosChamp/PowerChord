using Acordes.DML;
using System.Collections.Generic;

namespace Acordes.Interpreter
{
    internal class AcordeDiminutoExpression : AcordeRegExpExpression
    {
        protected override string ExpressaoAcorde => "[A-G][#b]?º";

        protected override List<TipoIntervalo> Intervalos =>
            new List<TipoIntervalo>()
            {
                TipoIntervalo.TERCA_MENOR,
                TipoIntervalo.QUARTA_AUMENTADA,
                TipoIntervalo.SEXTA_MAIOR
            };
    }
}