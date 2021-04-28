using Acordes.DML;
using Acordes.Interpreter;
using System;
using Acordes.Infra;
using System.Collections.Generic;
using System.Text;

namespace Acordes.Factory
{

    public class FactoryCampoHarmonico
    {
        private static Tuple<int, TipoAcordeFormula>[] FormulaCampoHarmonicoMaior
        {
            get
            {
                Tuple<int, TipoAcordeFormula>[] formula = new Tuple<int, TipoAcordeFormula>[]
                {
                    //new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Maior),
                    new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Menor),
                    new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Menor),
                    new Tuple<int, TipoAcordeFormula>(1, TipoAcordeFormula.Maior),
                    new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Maior),
                    new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Menor),
                    new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Diminuto),

                };
                return formula;
            }
        }

        private static Tuple<int, TipoAcordeFormula>[] FormulaCampoHarmonicoMenor
        {
            get
            {
                Tuple<int, TipoAcordeFormula>[] formula = new Tuple<int, TipoAcordeFormula>[]
                {
                    //new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Menor),
                    new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Diminuto),
                    new Tuple<int, TipoAcordeFormula>(1, TipoAcordeFormula.Maior),
                    new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Menor),
                    new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Menor),
                    new Tuple<int, TipoAcordeFormula>(1, TipoAcordeFormula.Maior),
                    new Tuple<int, TipoAcordeFormula>(2, TipoAcordeFormula.Maior),

                };
                return formula;
            }
        }

        public Tuple<int, TipoAcordeFormula>[] ObterFormulaPorAcordeBase(Acorde acorde)
        {
            if (acorde.TriadeFormadora == ModoDoAcorde.PerfeitoMaior)
            {
                return FormulaCampoHarmonicoMaior;
            }
            else
            {
                return FormulaCampoHarmonicoMenor;
            }
        }

        public CampoHarmonico CriarCampoHarmonico(string nomeAcorde)
        {
            InterpreterAcorde interpreter = new InterpreterAcorde();
            Acorde acorde = new Acorde(nomeAcorde);
            interpreter.Interpret(acorde);
            CampoHarmonico campo = CriarCampoHarmonicoPelaFormula(acorde, ObterFormulaPorAcordeBase(acorde));
           
            return campo;
        }

        public CampoHarmonico CriarCampoHarmonico(Acorde acorde)
        {
            CampoHarmonico campo = CriarCampoHarmonicoPelaFormula(acorde, ObterFormulaPorAcordeBase(acorde));

            return campo;
        }

        private CampoHarmonico CriarCampoHarmonicoPelaFormula(Acorde acorde, Tuple<int, TipoAcordeFormula>[] formula)
        {
            CampoHarmonico campoHarmonico = new CampoHarmonico();
            FactoryAcorde factory = new FactoryAcorde();
            TipoNota tonicaBase = acorde.Tonica;
            campoHarmonico.Graus.Add(acorde);
            foreach (var item in formula)
            {
                tonicaBase = tonicaBase.Add(item.Item1);
                campoHarmonico.
                    Graus.Add(factory.CriarAcorde(tonicaBase, item.Item2));

            }

            return campoHarmonico;
        }
    }
}
