using System;
using System.Collections.Generic;
using System.Text;
using Acordes.Infra;

namespace Acordes.DML
{
    public class Acorde
    {
        #region atributos
        private readonly List<TipoIntervalo> intervalos = new List<TipoIntervalo> { TipoIntervalo.TONICA };
        #endregion

        #region Propriedades

        public string Nome { get; set; }

        public TipoNota Tonica { get; set; }

        public List<TipoNota> GetNotas()
        {
            List<TipoNota> Notas = new List<TipoNota>();

            foreach (TipoIntervalo intervalo in intervalos)
            {
                TipoNota nota = Tonica.Add((int)intervalo);
                Notas.Add(nota);
            }

            return Notas;
        }

        internal void DiminuirIntervalo(TipoIntervalo? intervalo)
        {
            int indexIntervalo = intervalos.IndexOf(intervalo.GetValueOrDefault());
            if (indexIntervalo >= 0)
                intervalos[indexIntervalo]--;

        }

        internal void AumentarIntervalo(TipoIntervalo? intervalo)
        {
            int indexIntervalo = intervalos.IndexOf(intervalo.GetValueOrDefault());
            if (indexIntervalo >= 0)
                intervalos[indexIntervalo]++;
        }

        public ModoDoAcorde TriadeFormadora { get; set; }

        public Acorde Relativa { get; set; }

        public bool IsAcordeDiminuto
        {
            get
            {
                return intervalos.Count == 4 &&
                    intervalos.ContainsAll(TipoIntervalo.TERCA_MENOR, TipoIntervalo.QUARTA_AUMENTADA, TipoIntervalo.SEXTA_MAIOR);
            }
        }

        public bool IsAcordeMeioDiminuto
        {
            get
            {
                return intervalos.Count == 4 &&
                    intervalos.ContainsAll(TipoIntervalo.TERCA_MENOR, TipoIntervalo.QUARTA_AUMENTADA, TipoIntervalo.SETIMA_MENOR);
            }
        }

        public TipoNota Baixo { get; set; }


        #endregion

        #region Métodos

        public Acorde()
        {

        }

        public Acorde(string nomeAcorde)
        {
            Nome = nomeAcorde;
        }

        private Acorde(TipoNota tonica, List<TipoIntervalo> intervalos, TipoNota? baixo = null)
        {
            AddIntervalos(intervalos);

            this.Tonica = tonica;
            this.Baixo = baixo ?? Tonica;

            Nome = GerarNome(this);

        }


        public void AddIntervalo(TipoIntervalo intervalo)
        {
            if (!intervalos.Contains(intervalo))
                intervalos.Add(intervalo);
        }

        public void AddIntervalos(IEnumerable<TipoIntervalo> intervalos)
        {
            foreach (var intervalo in intervalos)
                if (!this.intervalos.Contains(intervalo))
                    this.intervalos.Add(intervalo);
        }

        public List<TipoIntervalo> GetIntervalos()
        {
            return intervalos;
        }

        public static Acorde CriarAcordePelosIntervalos(TipoNota Tonica, List<TipoIntervalo> intervalos, TipoNota? Baixo = null)
        {
            Acorde acorde = new Acorde(Tonica, intervalos, Baixo);
            return acorde;
        }

        public static Acorde CriarAcordeMenor(TipoNota Tonica, TipoNota? Baixo = null)
        {
            Acorde acorde = new Acorde(Tonica, new List<TipoIntervalo>() { TipoIntervalo.TERCA_MENOR, TipoIntervalo.QUINTA_JUSTA }, Baixo);
            return acorde;
        }

        public static Acorde CriarAcordeMaior(TipoNota Tonica, TipoNota? Baixo = null)
        {
            Acorde acorde = new Acorde(Tonica, new List<TipoIntervalo>() { TipoIntervalo.TERCA_MAIOR, TipoIntervalo.QUINTA_JUSTA }, Baixo);
            return acorde;
        }

        public static Acorde CriarAcordeDiminuto(TipoNota Tonica, TipoNota? Baixo = null)
        {
            Acorde acorde = new Acorde(Tonica, new List<TipoIntervalo>() { TipoIntervalo.TERCA_MENOR, TipoIntervalo.QUARTA_AUMENTADA, TipoIntervalo.SEXTA_MAIOR }, Baixo);
            return acorde;
        }

        public static Acorde CriarAcordeMeioDiminuto(TipoNota Tonica, TipoNota? Baixo = null)
        {
            Acorde acorde = new Acorde(Tonica, new List<TipoIntervalo>() { TipoIntervalo.TERCA_MENOR, TipoIntervalo.QUARTA_AUMENTADA, TipoIntervalo.SETIMA_MENOR }, Baixo);
            return acorde;
        }

        public static string GerarNome(in Acorde acorde)
        {
            StringBuilder nome = new StringBuilder();
            nome.Append(acorde.Tonica.GetCifraFromEnum());

            //Caso especial de acorde diminuto
            if (acorde.IsAcordeDiminuto)
            {

                nome.Append("º");
                return nome.ToString();
            }

            //Caso especial de acorde meio diminuto
            if (acorde.IsAcordeMeioDiminuto)
            {
                nome.Append("m7(5-)");
                return nome.ToString();
            }


            if (acorde.GetIntervalos().ContainsAll(TipoIntervalo.TERCA_MENOR, TipoIntervalo.QUINTA_JUSTA))
                nome.Append("m");

            if (acorde.GetIntervalos().ContainsAll(TipoIntervalo.SETIMA_MAIOR))
                nome.Append("7+");

            if (acorde.GetIntervalos().Contains(TipoIntervalo.QUARTA_JUSTA))
                nome.Append("4");

            if (acorde.GetIntervalos().ContainsAll(TipoIntervalo.SEGUNDA_MAIOR))
                nome.Append("9");

            if (acorde.GetIntervalos().ContainsAll(TipoIntervalo.SEXTA_MAIOR))
                nome.Append("(13)");

            return nome.ToString();
        }

        #endregion
    }

}