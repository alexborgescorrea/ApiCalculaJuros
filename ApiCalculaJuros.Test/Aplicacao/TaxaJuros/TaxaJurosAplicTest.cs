using ApiCalculaJuros.Aplicacao.TaxaJuros;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Contrib.HttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiCalculaJuros.Test.Aplicacao.TaxaJuros
{
    public class TaxaJurosAplicTest
    {
        [Fact]
        public async Task TaxaPadrao_TestaValorRetornado()
        {
            //Arrange
            var fakeUrl = "http://teste.com.br/";            
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.SetupGet(p => p["UrlApiTaxaJuros"]).Returns(fakeUrl);

            var handler = new Mock<HttpMessageHandler>();            
            var factory = handler.CreateClientFactory();

            Mock.Get(factory).Setup(x => x.CreateClient("api"))
                .Returns(() =>
                {
                    var client = handler.CreateClient();
                    client.BaseAddress = new Uri(fakeUrl);

                    return client;
                });

            handler.SetupRequest(HttpMethod.Get, fakeUrl)
                   .ReturnsResponse("0.01");

            //Act
            var taxaJurosAplic = await new TaxaJurosAplic(factory, mockConfiguration.Object).TaxaPadraoAsync();

            //Test
            Assert.Equal(0.01m, taxaJurosAplic);
        }
    }
}
