using Acordes.DML;

namespace PowerChords
{
    /// <summary>
    /// Referência para um acorde
    /// </summary>
    public class OutAcordeReferencia
    {
        /// <summary>
        /// Nome do acorde
        /// </summary>
        public string Acorde { get; set; }

        /// <summary>
        /// URL do acorde
        /// </summary>
        public string UrlAcorde 
        { 
            get 
            { 
                return Util.GerarURLAcorde(this.Acorde); 
            } 
        }
    }

}
