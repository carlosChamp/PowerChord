using Acordes.DML;
using Acordes.Infra;

namespace Acordes.Interpreter
{
    public class AcordeTonicaExpression : IAcordeExpression
    {
        public void Interpret(Acorde acorde)
        {
            TipoNota? nota = acorde.Nome.ToUpper()[0].ToString().GetEnumFromCifra();
            if (!nota.HasValue)
                throw new ExpressaoInvalidaException("Tônica não encontrada.");

            acorde.Tonica = nota.Value;

        }
    }
}