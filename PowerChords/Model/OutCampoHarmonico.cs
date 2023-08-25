using Acordes;
using Acordes.DML;
using System.Collections.Generic;

namespace PowerChords
{
    /// <summary>
    /// Informações do campo harmônico
    /// </summary>
    public class OutCampoHarmonico : OutStatusBase
    {
        /// <summary>
        /// Graus do campo harmônico
        /// </summary>
        public IList<OutAcordeReferencia> Graus { get; set; } = new List<OutAcordeReferencia>();

        /// <summary>
        /// Converte um campo harmônico interno para OutCampoHarmonico
        /// </summary>
        /// <param name="campo"></param>
        public static implicit operator OutCampoHarmonico(CampoHarmonico campo)
        {
            OutCampoHarmonico outCampoHarmonico = new OutCampoHarmonico
            {
                Graus = new List<OutAcordeReferencia>()
            };

            foreach (Acorde acorde in campo.Graus)
            {
                OutAcordeReferencia outAcordeReferencia = new OutAcordeReferencia
                {
                    Acorde = acorde.Nome
                };

                outCampoHarmonico.Graus.Add(outAcordeReferencia);
            }

            return outCampoHarmonico;
        }
    }

}
