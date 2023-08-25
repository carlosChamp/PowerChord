using Acordes.DML;

namespace Acordes.Infra
{
    public static class UtilHelper
    {
        public static bool In<T>(this T valor, params T[] values)
        {
            foreach (var item in values)
            {
                if (valor.Equals(item))
                    return true;
            }
            return false;
        }


        public static TipoNota Add(this TipoNota nota, TipoDistanciaEntreInvervalos meioTom)
        {
            return nota.Add((int)meioTom);
        }

        public static TipoNota Add(this TipoNota nota, TipoIntervalo intervalo)
        {
            return nota.Add((int)intervalo);
        }

        public static TipoNota Add(this TipoNota nota, int intervaloEmMeioTom)
        {
            return (TipoNota)(((int)nota + intervaloEmMeioTom) % 12);
        }
    }
}
