using Acordes.DML;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acordes.Factory
{
    public class FactoryAcorde
    {
        public Acorde CriarAcorde(TipoNota tonica, TipoAcordeFormula tipoAcorde)
        {
            switch (tipoAcorde)
            {
                case TipoAcordeFormula.Maior:
                    return Acorde.CriarAcordeMaior(tonica);
                case TipoAcordeFormula.Menor:
                    return Acorde.CriarAcordeMenor(tonica);
                case TipoAcordeFormula.MaiorSetima:
                    return Acorde.CriarAcordePelosIntervalos(tonica, new List<TipoIntervalo>() { TipoIntervalo.TERCA_MAIOR, TipoIntervalo.QUINTA_JUSTA, TipoIntervalo.SETIMA_MENOR });
                case TipoAcordeFormula.MenorSetima:
                    return Acorde.CriarAcordePelosIntervalos(tonica, new List<TipoIntervalo>() { TipoIntervalo.TERCA_MENOR, TipoIntervalo.QUINTA_JUSTA, TipoIntervalo.SETIMA_MENOR });
                case TipoAcordeFormula.Diminuto:
                    return Acorde.CriarAcordeDiminuto(tonica);
                case TipoAcordeFormula.MeioDiminuto:
                    return Acorde.CriarAcordeMeioDiminuto(tonica);
                default:
                    return Acorde.CriarAcordeMaior(tonica);
            }
        }
    }
}
