using Acordes.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Acordes.Interpreter
{
    public abstract class AcordeRegExpExpression : IAcordeExpression
    {
        /// <Summary>
        /// Define a expressão regular que identificará o acorde.
        /// </Summary>
        protected abstract string ExpressaoAcorde { get; }

        /// <Summary>
        /// Define quais intervalos serão adicionados ao acorde, caso a expressão seja verdadeira.
        /// </Summary>
        protected abstract List<TipoIntervalo> Intervalos{get;}

        public void Interpret(Acorde acorde){
            if(Test(acorde.Nome)){
                foreach(var intervalo in Intervalos)
                {
                    acorde.AddIntervalo(intervalo);    
                }
                
            }
        }

        private bool Test(string nome){
            Regex reg = new Regex(ExpressaoAcorde);
            return reg.IsMatch(nome);
        }
        
    }
}