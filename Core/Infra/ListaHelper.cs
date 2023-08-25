using System;
using System.Collections.Generic;
using System.Text;

namespace Acordes.Infra
{
    public static class ListaHelper
    {

        public static bool ContainsAll<T>(this IList<T> lista, params T[] values)
        {
            bool containsValues = true;
            foreach (var item in values)
            {
                containsValues &= lista.Contains(item);
            }

            return containsValues && lista?.Count > 0;
        }
    }
}
