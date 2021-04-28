using Acordes.DML;
using System.Text;

namespace Acordes.Interpreter
{
    public interface IAcordeExpression
    {
        void Interpret(Acorde acorde);
    }
}