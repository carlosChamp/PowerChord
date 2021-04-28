using System;
using Acordes.Interpreter;
using Acordes.DML;

namespace Acordes
{
    class Program
    {
        protected Program()
        {
        }

        protected static void Main(string[] args)
        {
            string nomeAcorde = args[0];
            InterpreterAcorde cAcorde = new InterpreterAcorde();
            Acorde acorde = new Acorde(nomeAcorde);
            cAcorde.Interpret(acorde);

            foreach(TipoNota nota in acorde.GetNotas()){
                Console.WriteLine(nota);
            }           
        }
    }
}
