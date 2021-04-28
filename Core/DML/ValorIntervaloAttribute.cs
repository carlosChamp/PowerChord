using System;

namespace Acordes.DML
{
    internal class ValorIntervaloAttribute : Attribute
    {
        public int[] Valor { get; set; }

        public ValorIntervaloAttribute(params int[] valor)
        {
            Valor = valor;
        }
    }
}