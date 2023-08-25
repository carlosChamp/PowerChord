using Acordes.DML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Acordes.Infra
{
    public static class EnumHelper
    {
        public static string GetCifraFromEnum(this TipoNota nota)
        {
            var tipoEnum = typeof(TipoNota);
            CifraAttribute cifraEnum = tipoEnum.
                                            GetField(Enum.GetName(tipoEnum, nota)).
                                            GetCustomAttributes(false).
                                            OfType<CifraAttribute>().FirstOrDefault();

            return cifraEnum?.NomeCifra;
        }
        public static string ToDefaultValue<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DefaultValueAttribute[] attributes = (DefaultValueAttribute[])fi.GetCustomAttributes(
                typeof(DefaultValueAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Value?.ToString();
            else return source.ToString();
        }

        public static TipoNota? GetEnumFromCifra(this string cifra)
        {
            var tipoEnum = typeof(TipoNota);
            foreach (var nota in Enum.GetValues(tipoEnum))
            {
                CifraAttribute cifraEnum = tipoEnum.
                                            GetField(Enum.GetName(tipoEnum, nota)).
                                            GetCustomAttributes(false).
                                            OfType<CifraAttribute>().FirstOrDefault();

                if (cifraEnum.NomeCifra.Equals(cifra))
                    return (TipoNota)nota;
            }

            return null;
        }

        public static TipoIntervalo? GetIntervaloPorValor(this int valorIntervalo)
        {
            var tipoEnum = typeof(TipoIntervalo);
            foreach (var intervalo in Enum.GetValues(tipoEnum))
            {
                ValorIntervaloAttribute intervaloEnum = tipoEnum.
                                            GetField(Enum.GetName(tipoEnum, intervalo)).
                                            GetCustomAttributes(false).
                                            OfType<ValorIntervaloAttribute>().FirstOrDefault();
                
                if (intervaloEnum != null && intervaloEnum.Valor.Contains(valorIntervalo))
                    return (TipoIntervalo)intervalo;
            }

            return null;
        }

    }
}
