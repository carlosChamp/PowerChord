namespace Acordes.DML
{
    public enum TipoIntervalo
    {
        TONICA,
        SEGUNDA_MENOR,
        [ValorIntervalo(2, 9)]
        SEGUNDA_MAIOR,
        TERCA_MENOR,
        TERCA_MAIOR,
        [ValorIntervalo(4, 11)]
        QUARTA_JUSTA,
        QUARTA_AUMENTADA,
        [ValorIntervalo(5)]
        QUINTA_JUSTA,
        SEXTA_MENOR,
        [ValorIntervalo(13, 6)]
        SEXTA_MAIOR,
        [ValorIntervalo(7)]
        SETIMA_MENOR,
        SETIMA_MAIOR,

    }

}