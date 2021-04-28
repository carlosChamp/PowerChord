using Acordes.DML;
using Acordes.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreTests
{
    public class AcordeMaiorMenor
    {
        [Theory]
        [InlineData("C")]
        [InlineData("C#")]
        [InlineData("E")]
        [InlineData("D")]
        public void Interpret_Deve_Reconhecer_Acordes_Maiores(string nome)
        {
            Acorde acorde = new Acorde(nome);

            InterpreterAcorde cAcorde = new InterpreterAcorde();

            cAcorde.Interpret(acorde);

            Assert.Equal(
                new List<TipoIntervalo> { TipoIntervalo.TONICA, TipoIntervalo.TERCA_MAIOR, TipoIntervalo.QUINTA_JUSTA },
                acorde.GetIntervalos());

        }

        [Theory]
        [InlineData("Cm")]
        [InlineData("C#m")]
        [InlineData("Em")]
        [InlineData("Dm")]
        public void Interpret_Deve_Reconhecer_Acordes_Menores(string nome)
        {
            Acorde acorde = new Acorde(nome);

            InterpreterAcorde cAcorde = new InterpreterAcorde();

            cAcorde.Interpret(acorde);

            Assert.Equal(
                new List<TipoIntervalo> { TipoIntervalo.TONICA, TipoIntervalo.TERCA_MENOR, TipoIntervalo.QUINTA_JUSTA },
                acorde.GetIntervalos());

        }
    }
}
