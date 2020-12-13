using ApiCalculaJuros.Aplicacao.CalculaJuros.Dto;
using ApiCalculaJuros.Aplicacao.ShowMeTheCode.View;
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
    public class ShowMeTheCodeTest
    {
        private readonly TestContext _testContext;
        private readonly string _controller = "/showmethecode";

        public ShowMeTheCodeTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task GetUrlGitGub_RespostaOk()
        {
            var response = await _testContext.Client.GetAsync(_controller);

            response.EnsureSuccessStatusCode();

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetUrlGitGub_TestaRetorno()
        {
            var fakeUrlGitHubApiTaxaJuros = "https://github.com/alexborgescorrea/ApiTaxaJuros.git";
            var fakeUrlGitHubApiCalculaJuros = "https://github.com/alexborgescorrea/ApiCalculaJuros.git";

            var response = await _testContext.Client.GetAsync(_controller);

            response.EnsureSuccessStatusCode();

            var str = await response.Content.ReadAsStringAsync();
            str.ToString();

            var view = await JsonSerializer.DeserializeAsync<UrlGitHubView>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions
            {                
                PropertyNameCaseInsensitive = true
            });

            Assert.Equal(view.ApiTaxaJuros, fakeUrlGitHubApiTaxaJuros);
            Assert.Equal(view.ApiCalculaJuros, fakeUrlGitHubApiCalculaJuros);
        }        
    }
}
