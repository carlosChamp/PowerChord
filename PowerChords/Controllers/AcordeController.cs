using Acordes.Factory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PowerChords.Controllers
{
    /// <summary>
    /// Informações de acordes
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AcordeController : ControllerBase
    {

        /// <summary>
        /// Retorna informações sobre o acorde
        /// </summary>
        /// <param name="nome">Nome do acorde</param>
        /// <returns></returns>
        [HttpGet("{nome}")]
        public OutAcorde Get(string nome)
        {

            nome = HttpUtility.UrlDecode(nome);
            OutAcorde outAcorde = new OutAcorde();
            Acordes.DML.Acorde acorde = new Acordes.DML.Acorde(nome);

            Acordes.Interpreter.InterpreterAcorde interpreterAcorde = new Acordes.Interpreter.InterpreterAcorde();

            try
            {
                interpreterAcorde.Interpret(acorde);

                outAcorde = acorde;
                outAcorde.Status.Sucesso = true;

            }
            catch (Acordes.Interpreter.ExpressaoInvalidaException ex)
            {
                this.HttpContext.Response.StatusCode = 400;
                outAcorde.Status.Sucesso = false;
                outAcorde.Status.MensagemErro = ex.Message;
            } 
            catch (Exception)
            {
                this.HttpContext.Response.StatusCode = 500;
                outAcorde.Status.Sucesso = false;
                outAcorde.Status.MensagemErro = "Erro interno na API";
            }

            return outAcorde;

        }

    }
}
