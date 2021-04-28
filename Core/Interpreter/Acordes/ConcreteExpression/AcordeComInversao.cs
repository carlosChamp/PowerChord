using Acordes.DML;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Acordes.Infra;

namespace Acordes.Interpreter
{
    public class AcordeComInversao : IAcordeExpression
    {
        public void Interpret(Acorde acorde)
        {
            Regex reg = new Regex("/([A-G])$");
            Match matchBaixo = reg.Match(acorde.Nome);
            if (matchBaixo.Success)
                acorde.Baixo = matchBaixo.Groups[1].Value.GetEnumFromCifra() ?? acorde.Tonica;
            else
                acorde.Baixo = acorde.Tonica;
        }
    }
}
