using ApiCalculaJuros.Aplicacao.CalculaJuros.Dto;
using ApiCalculaJuros.TesteIntegracao.Fixtures;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace ApiCalculaJuros.TesteIntegracao.Tests
{
    public class CalculaJurosTest
    {
        private readonly TestContext _testContext;
        private readonly string _controller = "/calculajuros";

        public CalculaJurosTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task CalcularAsync_RespostaOk()
        {
            var response = await _testContext.Client.GetAsync(_controller);

            response.EnsureSuccessStatusCode();

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task CalcularAsync_DeveRetornar181669_66()
        {
            var dto = new CalculaJurosDto
            { 
                ValorInicial = 100_000,
                Meses = 60
            };

            var url = QueryHelpers.AddQueryString(_controller, new Dictionary<string, string>
            {
                { nameof(dto.ValorInicial), dto.ValorInicial.ToString() },
                { nameof(dto.Meses), dto.Meses.ToString() }
            });

            var response = await _testContext.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var valorAtual = await JsonSerializer.DeserializeAsync<decimal>(await response.Content.ReadAsStreamAsync());

            Assert.Equal(181_669.66m, valorAtual);
        }        
    }
}
