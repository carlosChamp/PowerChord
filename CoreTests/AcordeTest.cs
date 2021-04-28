using Acordes.DML;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreTests
{
    public class AcordeTest
    {
        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { TipoIntervalo.SEGUNDA_MENOR, TipoNota.DO_SUS},
            new object[] { TipoIntervalo.SEGUNDA_MAIOR, TipoNota.RE},
            new object[] { TipoIntervalo.TERCA_MENOR, TipoNota.RE_SUS},
            new object[] { TipoIntervalo.TERCA_MAIOR, TipoNota.MI},
            new object[] { TipoIntervalo.QUARTA_JUSTA, TipoNota.FA},
            new object[] { TipoIntervalo.QUARTA_AUMENTADA, TipoNota.FA_SUS},
            new object[] { TipoIntervalo.QUINTA_JUSTA, TipoNota.SOL},
            new object[] { TipoIntervalo.SEXTA_MENOR, TipoNota.SOL_SUS},
            new object[] { TipoIntervalo.SEXTA_MAIOR, TipoNota.LA},
            new object[] { TipoIntervalo.SETIMA_MENOR, TipoNota.LA_SUS},
            new object[] { TipoIntervalo.SETIMA_MAIOR, TipoNota.SI},

        };

        [Theory]
        [MemberData(nameof(Data))]
        public void GetNotas_Deve_Retornar_Notas_Dos_Acordes(TipoIntervalo intervalo, TipoNota nota)
        {
            Acorde acorde = new Acorde
            {
                Tonica = TipoNota.DO
            };
            acorde.AddIntervalo(intervalo);
            Assert.Contains(nota, acorde.GetNotas());

        }

        [Fact]
        public void Acorde_Deve_Criar_Acorde_Menor()
        {
            Acorde acorde = Acorde.CriarAcordeMenor(TipoNota.DO);
            Assert.Equal(new List<TipoIntervalo>() { TipoIntervalo.TONICA, TipoIntervalo.TERCA_MENOR, TipoIntervalo.QUINTA_JUSTA },
                          acorde.GetIntervalos());
        }

        [Fact]
        public void Acorde_Deve_Criar_Acorde_Maior()
        {
            Acorde acorde = Acorde.CriarAcordeMaior(TipoNota.DO);
            Assert.Equal(new List<TipoIntervalo>() { TipoIntervalo.TONICA, TipoIntervalo.TERCA_MAIOR, TipoIntervalo.QUINTA_JUSTA },
                          acorde.GetIntervalos());
        }

    }
}
