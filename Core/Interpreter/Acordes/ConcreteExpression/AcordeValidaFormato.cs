using Acordes.DML;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Acordes.Infra;
using System.Linq;

namespace Acordes.Interpreter
{
    public class AcordeValidaFormato : IAcordeExpression
    {
        private const string REGEXP_VALIDAFORMATOACORDE = @"([^0-9])([+-])";
        private const string REGEXP_VALIDAINTERVALOSACORDES = @"(\d+)";
        private const string REGEXP_NOTAVALIDANOACORDE = @"/[A-G]";

        public void Interpret(Acorde acorde)
        {
            Regex regexSinais = new(REGEXP_VALIDAFORMATOACORDE);
            if (regexSinais.IsMatch(acorde.Nome))
                throw new ExpressaoInvalidaException("O sinais para aumentar e diminuir devem ser precedidos pelo valor do intervalo.");

            Regex regexIntervalos = new(REGEXP_VALIDAINTERVALOSACORDES);
            MatchCollection matches = regexIntervalos.Matches(acorde.Nome);
            foreach (Match item in matches.Cast<Match>())
            {
                if (item.Groups[1].Value.Length > 2)
                    throw new ExpressaoInvalidaException("Os intervalos devem estar separados por / ou ()");

                int valorIntervalo = int.Parse(item.Groups[1].Value);

                if (valorIntervalo.GetIntervaloPorValor() == null)
                    throw new ExpressaoInvalidaException(
                        $"O valor {valorIntervalo} não representa um intervalo válido. " +
                        $"Intervalos aceitos: 4, 11, 2, 9, 7, 6 e 13. ");
            }

            Regex regexBaixo = new(REGEXP_NOTAVALIDANOACORDE);
            MatchCollection matchesBaixo = regexBaixo.Matches(acorde.Nome);

            if (matchesBaixo.Count > 1)
                throw new ExpressaoInvalidaException("O acorde só pode ser representado com uma inversão.");

        }
    }
}
