using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace PowerChords.TesteIntegracao.HttpStatusTests
{
    public class AcordeHttpStatusTests
    {
        private readonly Contexto contexto;
        public AcordeHttpStatusTests()
        {
            contexto = new Contexto();
        }

        [Fact]
        public async Task Acorde_EndpointInvalido()
        {
            var response = await contexto.Client.GetAsync("acordes/C");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Acorde_EndpointArgumentoInvalido()
        {
            var response = await contexto.Client.GetAsync("acorde/");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Acorde_InterpretacaoInvalida()
        {
            var response = await contexto.Client.GetAsync("acorde/Hm");
            string jsonResposta = await response.Content.ReadAsStringAsync();
            OutAcorde saida = JsonSerializer.Deserialize<PowerChords.OutAcorde>(jsonResposta);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(saida.Status.Sucesso);
        }
    }
}
