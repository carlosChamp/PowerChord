using System.ComponentModel;

namespace Acordes.DML
{
    public enum TipoAcordeFormula
    {
        [DefaultValue("M")]
        Maior,
        [DefaultValue("m")]
        Menor,
        [DefaultValue("7+")]
        MaiorSetima,
        [DefaultValue("7")]
        MenorSetima,
        [DefaultValue("º")]
        Diminuto,
        [DefaultValue("m7(5-)")]
        MeioDiminuto
    }

}