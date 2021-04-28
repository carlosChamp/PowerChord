using Acordes.DML;

namespace Acordes.Interpreter
{
    public class AcordeBemolSustenidoExpression : IAcordeExpression
    {
        public void Interpret(Acorde acorde)
        {    
            if(acorde.Nome.StartsWith("E#") || acorde.Nome.StartsWith("B#") || 
                acorde.Nome.StartsWith("Cb") || acorde.Nome.StartsWith("Fb"))
                throw new ExpressaoInvalidaException("Acorde inválido.");

            if (acorde.Nome.Length > 1)
            {
                if (acorde.Nome[1] == '#') acorde.Tonica += 1;

                if (acorde.Nome[1] == 'b') acorde.Tonica -= 1;
            }
        }
    }
}