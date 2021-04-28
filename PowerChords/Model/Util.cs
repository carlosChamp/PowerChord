using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace PowerChords
{
    internal class Util
    {
        internal static string GerarURLAcorde(string nome)
        {
            HttpContext current = new HttpContextAccessor().HttpContext;
            string BaseURL = $"{current.Request.Scheme}://{current.Request.Host}{current.Request.PathBase}";
            nome = Uri.EscapeUriString(nome);
            return $"{BaseURL}/PowerChords/acorde/{nome}";
        }
    }
}