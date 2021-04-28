using Acordes.DML;
using Acordes.Infra;
using System.Collections.Generic;

namespace Acordes.Interpreter
{
    internal class AcordeRelativo : IAcordeExpression
    {
        public void Interpret(Acorde acorde)
        {
            if (acorde.TriadeFormadora == ModoDoAcorde.PerfeitoMaior)
            {
                acorde.Relativa = Acorde.CriarAcordeMenor(acorde.Tonica.Add(9));
            }
            else if (acorde.TriadeFormadora == ModoDoAcorde.PerfeitoMenor)
            {
                acorde.Relativa = Acorde.CriarAcordeMaior(acorde.Tonica.Add(3));
            }
        }
    }
}