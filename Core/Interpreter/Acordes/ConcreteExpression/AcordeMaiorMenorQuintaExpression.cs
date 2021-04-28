using System.Collections.Generic;
using System.Text.RegularExpressions;
using Acordes.DML;

namespace Acordes.Interpreter
{
    public class AcordeMaiorMenorQuintaExpression : IAcordeExpression
    {
        const string expQuinta = @"^[A-G][#b]?\(?[5]\)?";
        const string expMenor = "^[A-G][#b]?m";
        const string expMaior = "^[A-G][#b]?";

        public void Interpret(Acorde acorde)
        {
            Regex reg = new Regex(expQuinta);
            if (reg.IsMatch(acorde.Nome))
            {
                acorde.AddIntervalo(TipoIntervalo.QUINTA_JUSTA);
                acorde.TriadeFormadora = ModoDoAcorde.NaoDefinido;
                return;
            }

            reg = new Regex(expMenor);
            if (reg.IsMatch(acorde.Nome))
            {
                acorde.AddIntervalos(new List<TipoIntervalo> { TipoIntervalo.TERCA_MENOR, TipoIntervalo.QUINTA_JUSTA });
                acorde.TriadeFormadora = ModoDoAcorde.PerfeitoMenor;
                return;
            }

            reg = new Regex(expMaior);
            if (reg.IsMatch(acorde.Nome))
            {
                acorde.AddIntervalos(new List<TipoIntervalo> { TipoIntervalo.TERCA_MAIOR, TipoIntervalo.QUINTA_JUSTA });
                acorde.TriadeFormadora = ModoDoAcorde.PerfeitoMaior;
                return;
            }

            throw new ExpressaoInvalidaException("Modo do acorde não encontrado");

        }
    }
}