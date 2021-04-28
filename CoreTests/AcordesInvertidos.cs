using Acordes.DML;
using Acordes.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreTests
{
    public class AcordesInvertidos
    {

        [Theory]
        [InlineData("C/D", TipoNota.RE)]
        [InlineData("D9/A", TipoNota.LA)]
        [InlineData("E", TipoNota.MI)]
        public void Interpret_Deve_Encontrar_Baixo(string nome, TipoNota baixo)
        {
            InterpreterAcorde interpreterAcorde = new InterpreterAcorde();
            Acorde acorde = new Acorde(nome);

            interpreterAcorde.Interpret(acorde);

            Assert.Equal(baixo, acorde.Baixo);

        }
    }
}
