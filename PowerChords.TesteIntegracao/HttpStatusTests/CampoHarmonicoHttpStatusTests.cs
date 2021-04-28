using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace PowerChords.TesteIntegracao.HttpStatusTests
{
    public class CampoHarmonicoHttpStatusTests
    {
        private readonly Contexto contexto;
        public CampoHarmonicoHttpStatusTests()
        {
            contexto = new Contexto();
        }

        [Fact]
        public async Task CampoHarmonico_EndpointInvalido()
        {
            var response = await contexto.Client.GetAsync("campoharmonicos/C");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CampoHarmonico_EndpointArgumentoInvalido()
        {
            var response = await contexto.Client.GetAsync("campoharmonico/");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CampoHarmonico_InterpretacaoInvalida()
        {
            var response = await contexto.Client.GetAsync("campoharmonico/Hm");
            string jsonResposta = await response.Content.ReadAsStringAsync();
            OutAcorde saida = JsonSerializer.Deserialize<OutAcorde>(jsonResposta);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(saida.Status.Sucesso);
        }
    }
}
