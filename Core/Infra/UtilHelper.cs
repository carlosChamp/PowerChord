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


        public static TipoNota Add(this TipoNota nota, int meioTom)
        {
            return (TipoNota)(((int)nota + meioTom) % 12);
        }
    }
}
