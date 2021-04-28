using System;
using System.Collections.Generic;
using Acordes.DML;

namespace Acordes.Interpreter
{

    public class InterpreterAcorde : IAcordeExpression
    {

        public void Interpret(Acorde acorde)
        {
            List<IAcordeExpression> listInterpreters = new List<IAcordeExpression>(){
                new AcordeValidaFormato(),
                new AcordeTonicaExpression(),
                new AcordeBemolSustenidoExpression(),
                new AcordeMaiorMenorQuintaExpression(),
                new AcordeAdicionadoExpression(),
                new AcordeDiminutoExpression(),
                new AcordeComInversao(),
                new AcordeRelativo(),
            };

            foreach (IAcordeExpression interpreter in listInterpreters)
            {
                interpreter.Interpret(acorde);
            }
        }

    }

}