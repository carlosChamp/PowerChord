using Acordes.DML;
using Acordes.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acordes.Factory
{
    public class FactoryAcorde
    {
        public Acorde CriarAcorde(TipoNota tonica, TipoAcordeFormula tipoAcorde)
        {
            var interpreter = new Interpreter.InterpreterAcorde();
            var acorde = new Acorde($"{tonica.GetCifraFromEnum()}{tipoAcorde.ToDefaultValue()}");
            interpreter.Interpret(acorde);
            return acorde;
        }
    }
}
