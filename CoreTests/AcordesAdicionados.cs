using Acordes.DML;
using Acordes.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreTests
{
    public class AcordesAdicionados
    {

        [Theory]
        [InlineData("C4")]
        [InlineData("C#11")]
        [InlineData("D4")]
        [InlineData("E11")]
        [InlineData("A4")]
        public void Interpret_Deve_Adicionar_Quarta(string nome)
        {
            InterpreterAcorde interpreterAcorde = new InterpreterAcorde();
            Acorde acorde = new Acorde
            {
                Nome = nome
            };

            interpreterAcorde.Interpret(acorde);

            Assert.Contains(TipoIntervalo.QUARTA_JUSTA, acorde.GetIntervalos());
        }

        [Theory]
        [InlineData("C7")]
        [InlineData("C#7")]
        [InlineData("E7")]
        [InlineData("F7")]
        [InlineData("Gm7")]
        public void Interpret_Deve_Adicionar_Setima(string nome)
        {
            InterpreterAcorde interpreterAcorde = new InterpreterAcorde();
            Acorde acorde = new Acorde
            {
                Nome = nome
            };

            interpreterAcorde.Interpret(acorde);

            Assert.Contains(TipoIntervalo.SETIMA_MENOR, acorde.GetIntervalos());
        }

        [Theory]
        [InlineData("C9")]
        [InlineData("C#9")]
        [InlineData("E9")]
        [InlineData("F9")]
        [InlineData("G9")]
        public void Interpret_Deve_Adicionar_Nona(string nome)
        {
            InterpreterAcorde interpreterAcorde = new InterpreterAcorde();
            Acorde acorde = new Acorde
            {
                Nome = nome
            };

            interpreterAcorde.Interpret(acorde);

            Assert.Contains(TipoIntervalo.SEGUNDA_MAIOR, acorde.GetIntervalos());
        }

        [Theory]
        [InlineData("C6")]
        [InlineData("Db13")]
        [InlineData("E13")]
        [InlineData("F13")]
        [InlineData("G13")]
        public void Interpret_Deve_Adicionar_DecimaTerceira(string nome)
        {
            InterpreterAcorde interpreterAcorde = new InterpreterAcorde();
            Acorde acorde = new Acorde
            {
                Nome = nome
            };

            interpreterAcorde.Interpret(acorde);

            Assert.Contains(TipoIntervalo.SEXTA_MAIOR, acorde.GetIntervalos());
        }
    }
}
