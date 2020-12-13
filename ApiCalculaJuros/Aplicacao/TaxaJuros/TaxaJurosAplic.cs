using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace ApiCalculaJuros.Aplicacao.TaxaJuros
{
    public class TaxaJurosAplic : ITaxaJurosAplic
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public TaxaJurosAplic(IHttpClientFactory httpClientFactory, 
                              IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<decimal> TaxaPadraoAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var resp = await httpClient.GetAsync(GetUrl());

            resp.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<decimal>(await resp.Content.ReadAsStreamAsync());
        }

        private Uri GetUrl()
        {
            return new Uri(_configuration["UrlApiTaxaJuros"]);            
        }
    }
}