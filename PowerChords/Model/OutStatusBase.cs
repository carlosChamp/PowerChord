namespace PowerChords
{

    /// <summary>
    /// Objeto base do Status
    /// </summary>
    public abstract class OutStatusBase
    {
        /// <summary>
        /// Objeto de status
        /// </summary>
        public OutStatus Status { get; set; } = new OutStatus();

    }

    /// <summary>
    /// Status do retorno da API
    /// </summary>
    public class OutStatus
    {
        /// <summary>
        /// Sucesso na API
        /// </summary>
        public bool Sucesso { get; set; }

        /// <summary>
        /// Mensagem de erro da API
        /// </summary>
        public string MensagemErro { get; set; }
    }
}