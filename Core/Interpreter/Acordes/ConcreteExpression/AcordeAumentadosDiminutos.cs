using Acordes.DML;
using Acordes.Infra;
using System.Text.RegularExpressions;

namespace Acordes.Interpreter
{
    internal class AcordeAumentadosDiminutos : IAcordeExpression
    {
        public void Interpret(Acorde acorde)
        {
            Regex reg = new Regex(@"(\d+)([+\-#b])");
            MatchCollection match = reg.Matches(acorde.Nome);

            foreach (Match item in match)
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