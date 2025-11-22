using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MindCareWeb.Services
{
    public class IAService
    {
        private readonly HttpClient _httpClient;

        public IAService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8000")
            };
        }

        public async Task<string> ObterMensagemIA(int usuarioId)
        {
            var response = await _httpClient.GetAsync($"/api/ia/mensagem/{usuarioId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(json);

            return obj["mensagem"]!.ToString();
        }
    }
}
