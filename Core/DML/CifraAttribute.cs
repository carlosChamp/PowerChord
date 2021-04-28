using System;

namespace Acordes.DML
{
    internal class CifraAttribute : Attribute
    {
        public string NomeCifra { get; set; }

        public CifraAttribute(string nomeCifra)
        {
            NomeCifra = nomeCifra;
        }
    }
}