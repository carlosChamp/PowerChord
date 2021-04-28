using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using PowerChords;

namespace PowerChords.TesteIntegracao
{
    public class Contexto
    {
        public HttpClient Client { get; set; }
        private TestServer _server;
        
        public Contexto()
        {
            Configurar();
        }

        private void Configurar()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}
