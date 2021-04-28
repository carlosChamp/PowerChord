using Acordes.DML;
using Acordes.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreTests
{
    public class AcordesRelativos
    {

        [Theory]
        [InlineData("C", "Am")]
        [InlineData("D", "Bm")]
        [InlineData("E", "C#m")]
        [InlineData("C#m", "E")]
        [InlineData("Bm", "D")]
        [InlineData("Am", "C")]
        public void Interpret_Deve_Encontrar_Relativo(string nome, string relativa)
        {
            InterpreterAcorde interpreterAcorde = new InterpreterAcorde();
            Acorde acorde = new Acorde(nome);

            interpreterAcorde.Interpret(acorde);

            Assert.Equal(relativa, acorde.Relativa.Nome);

        }
    }
}
