using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PowerChords.TesteIntegracao.PerformanceTests
{
    public class CampoHarmonicoPerformanceTests
    {
        private const int TempoMaximoResposta = 200;
        private const int TamanhoMaximoDaResposta = 2048;

        private readonly Contexto contexto;
        public CampoHarmonicoPerformanceTests()
        {
            contexto = new Contexto();
        }

        [Fact]
        public async Task CampoHarmonico_DeveRespeitarLimiteDeTempo()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var response = await contexto.Client.GetAsync("campoharmonico/C");
            response.EnsureSuccessStatusCode();
            await response.Content.ReadAsByteArrayAsync();
            sw.Stop();
            long ellapsed = sw.ElapsedMilliseconds;
            
            Assert.True(ellapsed < TempoMaximoResposta);
        }

        [Fact]
        public async Task CampoHarmonico_DeveRespeitarTamanhoDaRequisicao()
        {
            var response = await contexto.Client.GetAsync("campoharmonico/C");
            response.EnsureSuccessStatusCode();
            
            byte[] resposta = await response.Content.ReadAsByteArrayAsync();
            Assert.True(resposta.Length < TamanhoMaximoDaResposta);
        }
    }
}
