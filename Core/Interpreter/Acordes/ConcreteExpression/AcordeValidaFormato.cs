using Acordes.DML;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Acordes.Infra;

namespace Acordes.Interpreter
{
    public class AcordeValidaFormato : IAcordeExpression
    {

        public void Interpret(Acorde acorde)
        {
            Regex regexSinais = new Regex(@"([^0-9])([+-])");
            if (regexSinais.IsMatch(acorde.Nome))
                throw new ExpressaoInvalidaException("O sinais para aumentar e diminuir devem ser precedidos pelo valor do intervalo.");

            Regex regexIntervalos = new Regex(@"(\d+)");
            MatchCollection matches = regexIntervalos.Matches(acorde.Nome);
            foreach (Match item in matches)
            {
                if (item.Groups[1].Value.Length > 2)
                    throw new ExpressaoInvalidaException("Os intervalos devem estar separados por / ou ()");

                int valorIntervalo = int.Parse(item.Groups[1].Value);
                TipoIntervalo? intervalo = valorIntervalo.GetIntervaloPorValor();
                if (intervalo == null)
                    throw new ExpressaoInvalidaException(
                        $"O valor {valorIntervalo} não representa um intervalo válido. " +
                        $"Intervalos aceitos: 4, 11, 2, 9, 7, 6 e 13. ");
            }

            Regex regexBaixo = new Regex(@"/[A-G]");
            MatchCollection matchesBaixo = regexBaixo.Matches(acorde.Nome);

            if (matchesBaixo.Count > 1)
                throw new ExpressaoInvalidaException("O acorde só pode ser representado com uma inversão.");

        }
    }
}
