using Acordes.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerChords.Controllers
{
    /// <summary>
    /// Informações relacionadas ao campo harmônico
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CampoHarmonicoController : ControllerBase
    {

        /// <summary>
        /// Retorna informações sobre um campo harmônico
        /// </summary>
        /// <param name="nome">Nome do campo</param>
        /// <returns>Campo Harmônico</returns>
        [HttpGet("{nome}")]
        public OutCampoHarmonico Get(string nome)
        {
            OutCampoHarmonico outCampoHarmonico = new OutCampoHarmonico();

            try
            {
                FactoryCampoHarmonico factoryCampoHarmonico = new FactoryCampoHarmonico();
                outCampoHarmonico = factoryCampoHarmonico.CriarCampoHarmonico(nome);

                outCampoHarmonico.Status.Sucesso = true;

            }
            catch (Acordes.Interpreter.ExpressaoInvalidaException ex)
            {
                this.HttpContext.Response.StatusCode = 400;
                outCampoHarmonico.Status.Sucesso = false;
                outCampoHarmonico.Status.MensagemErro = ex.Message;
            }
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 500;
                outCampoHarmonico.Status.Sucesso = false;
                outCampoHarmonico.Status.MensagemErro = "Erro interno na API";
            }

            return outCampoHarmonico;
        }
    }
}
