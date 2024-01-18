using Acordes.DML;
using Acordes.Infra;
using System.Linq;
using System.Text.RegularExpressions;

namespace Acordes.Interpreter
{
    internal class AcordeAumentadosDiminutos : IAcordeExpression
    {
        private const string REGEXP_ACORDESAUMENTADOS_OU_DIMINUTOS = @"(\d+)([+\-#b])";

        public void Interpret(Acorde acorde)
        {
            Regex reg = new(REGEXP_ACORDESAUMENTADOS_OU_DIMINUTOS);
            MatchCollection match = reg.Matches(acorde.Nome);

            foreach (Match item in match.Cast<Match>())
            {
                int valor = int.Parse(item.Groups[1].Value);
                TipoIntervalo? intervalo = valor.GetIntervaloPorValor();
                string sinal = item.Groups[2].Value;
                if (!intervalo.HasValue)
                    continue;
                
                if (sinal.In("+", "#"))
                    acorde.AumentarIntervalo(intervalo);
                else 
                    acorde.DiminuirIntervalo(intervalo);
                
            }
        }
    }
}