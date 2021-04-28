using System.Collections.Generic;
using Acordes.DML;

namespace Acordes.Interpreter
{
    internal class AcordeAdicionadoExpression : IAcordeExpression
    {
        public void Interpret(Acorde acorde)
        {
            List<IAcordeExpression> listInterpreters = new List<IAcordeExpression>(){
                new AcordeQuartaExpression(),
                new AcordeSextaExpression(),
                new AcordeSetimaExpression(),
                new AcordeNonaExpression(),
                new AcordeAumentadosDiminutos(),

            };

            foreach (IAcordeExpression interpreter in listInterpreters)
            {
                interpreter.Interpret(acorde);
            }
        }
    }
}