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
        private static (TipoDistanciaEntreInvervalos, TipoAcordeFormula)[] FormulaCampoHarmonicoMaior
        {
            get
            {
                (TipoDistanciaEntreInvervalos, TipoAcordeFormula)[] formula = new (TipoDistanciaEntreInvervalos, TipoAcordeFormula)[]
                {
                    (TipoDistanciaEntreInvervalos.Tom, TipoAcordeFormula.Menor),
                    (TipoDistanciaEntreInvervalos.Tom, TipoAcordeFormula.Menor),
                    (TipoDistanciaEntreInvervalos.MeioTom, TipoAcordeFormula.Maior),
                    (TipoDistanciaEntreInvervalos.Tom, TipoAcordeFormula.Maior),
                    (TipoDistanciaEntreInvervalos.Tom, TipoAcordeFormula.Menor),
                    (TipoDistanciaEntreInvervalos.Tom, TipoAcordeFormula.Diminuto),
                };
                return formula;
            }
        }

        private static (TipoDistanciaEntreInvervalos, TipoAcordeFormula)[] FormulaCampoHarmonicoMenor
        {
            get
            {
                (TipoDistanciaEntreInvervalos, TipoAcordeFormula)[] formula = new (TipoDistanciaEntreInvervalos, TipoAcordeFormula)[]
                {
                    (TipoDistanciaEntreInvervalos.Tom, TipoAcordeFormula.Diminuto),
                    (TipoDistanciaEntreInvervalos.MeioTom, TipoAcordeFormula.Maior),
                    (TipoDistanciaEntreInvervalos.Tom, TipoAcordeFormula.Menor),
                    (TipoDistanciaEntreInvervalos.Tom, TipoAcordeFormula.Menor),
                    (TipoDistanciaEntreInvervalos.MeioTom, TipoAcordeFormula.Maior),
                    (TipoDistanciaEntreInvervalos.Tom, TipoAcordeFormula.Maior),
                };
                return formula;
            }
        }

        public (TipoDistanciaEntreInvervalos, TipoAcordeFormula)[] ObterFormulaPorAcordeBase(Acorde acorde)
        {
            if (acorde.TriadeFormadora == ModoDoAcorde.PerfeitoMaior)
                return FormulaCampoHarmonicoMaior;

            if (acorde.TriadeFormadora == ModoDoAcorde.PerfeitoMenor)
                return FormulaCampoHarmonicoMenor;

            throw new CampoHarmonicoException("Campo harmônico não suportado.");
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

        private CampoHarmonico CriarCampoHarmonicoPelaFormula(Acorde acorde, (TipoDistanciaEntreInvervalos, TipoAcordeFormula)[] formula)
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
