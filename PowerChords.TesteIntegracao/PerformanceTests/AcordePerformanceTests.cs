using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PowerChords.TesteIntegracao.PerformanceTests
{
    public class AcordePerformanceTests
    {
        private const int TempoMaximoResposta = 200;
        private const int TamanhoMaximoDaResposta = 2048;

        private readonly Contexto contexto;
        public AcordePerformanceTests()
        {
            contexto = new Contexto();
        }

        [Fact]
        public async Task Acorde_DeveRespeitarLimiteDeTempo()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var response = await contexto.Client.GetAsync("acorde/C");
            response.EnsureSuccessStatusCode();
            await response.Content.ReadAsByteArrayAsync();
            sw.Stop();
            long ellapsed = sw.ElapsedMilliseconds;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(ellapsed < TempoMaximoResposta);
        }

        [Fact]
        public async Task Acorde_DeveRespeitarTamanhoDaRequisicao()
        {
            var response = await contexto.Client.GetAsync("acorde/C");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            byte[] resposta = await response.Content.ReadAsByteArrayAsync();
            Assert.True(resposta.Length < TamanhoMaximoDaResposta);
        }

    }
}
