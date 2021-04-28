using Acordes.DML;
using Acordes.Infra;
using Acordes.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreTests
{
    public class InterpreterTests
    {
        [Fact]
        public void Interpret_Deve_Reconhecer_Tonica()
        {
            InterpreterAcorde interpreterAcorde = new InterpreterAcorde();
            foreach (TipoNota item in Enum.GetValues(typeof(TipoNota)))
            {
                Acorde acorde = new Acorde
                {
                    Nome = item.GetCifraFromEnum()
                };

                interpreterAcorde.Interpret(acorde);

                Assert.Equal(item, acorde.Tonica);

            }

        }
        
        [Theory]
        [InlineData("Cb")]
        [InlineData("Fb")]
        [InlineData("B#")]
        [InlineData("E#")]
        public void Interpret_Deve_Lancar_Erro_Sustenidos_Bemois(string nome)
        {
            InterpreterAcorde interpreterAcorde = new InterpreterAcorde();
            Acorde acorde = new Acorde
            {
                Nome = nome
            };

            Assert.Throws<ExpressaoInvalidaException>(() => interpreterAcorde.Interpret(acorde));
        }

        [Theory]
        [InlineData("C/D/E")]//Acorde com mais de uma inversão
        [InlineData("F114")]//Acorde sem separador nos intervalos
        [InlineData("B+")]//Acordes com 5 aumentados devem ser representados com 5+
        [InlineData("E7++")]//Dois sinais repetidos
        [InlineData("F5--")]//Dois sinais repetidos
        [InlineData("F11++")]//Dois sinais repetidos
        public void Interpret_Deve_Lancar_Erro_Formatos_Invalidos(string nome)
        {
            InterpreterAcorde interpreterAcorde = new InterpreterAcorde();
            Acorde acorde = new Acorde(nome);
                

            Assert.Throws<ExpressaoInvalidaException>(() => interpreterAcorde.Interpret(acorde));
        }

    }
}
