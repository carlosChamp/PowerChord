using Acordes.DML;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace PowerChords
{
    /// <summary>
    /// Acorde 
    /// </summary>
    public class OutAcorde : OutStatusBase
    {
        /// <summary>
        /// Nome do acorde
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Lista de notas do acorde
        /// </summary>
        public IList<TipoNota> Notas { get; set; }

        /// <summary>
        /// Lista de intervalos do acorde
        /// </summary>
        public IList<TipoIntervalo> Intervalos { get; set; }
                
        /// <summary>
        /// Acorde relativo maior ou menor
        /// </summary>
        public OutAcordeReferencia Relativa { get; private set; }

        /// <summary>
        /// Baixo do acorde
        /// </summary>
        public TipoNota Baixo { get; private set; }

        /// <summary>
        /// Converte DML.Acorde para OutAcorde
        /// </summary>
        /// <param name="acorde"></param>
        public static implicit operator OutAcorde(Acorde acorde)
        {
            OutAcorde outAcorde = new OutAcorde
            {
                Nome = acorde.Nome,
                Intervalos = acorde.GetIntervalos(),
                Notas = acorde.GetNotas(),
                Relativa = new OutAcordeReferencia()
                {
                    Acorde = acorde.Relativa?.Nome
                },
                Baixo = acorde.Baixo
            };

            return outAcorde;
        }

    }
}
