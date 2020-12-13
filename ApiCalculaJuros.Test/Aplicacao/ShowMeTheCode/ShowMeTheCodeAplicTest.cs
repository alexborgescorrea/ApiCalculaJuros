using ApiCalculaJuros.Aplicacao.ShowMeTheCode;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApiCalculaJuros.Test.Aplicacao.ShowMeTheCode
{
    public class ShowMeTheCodeAplicTest
    {
        [Fact]
        public void GetUrlGitGub_TestaRetornoUrlGitHubApiTaxaJuros()
        {
            //Arrange
            var fakeUrlGitHubApiTaxaJuros = "http://teste.com.br/GitHubApiTaxaJuros";            

            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.SetupGet(p => p["UrlGitHubApiTaxaJuros"]).Returns(fakeUrlGitHubApiTaxaJuros);            

            //Act
            var view = new ShowMeTheCodeAplic(mockConfiguration.Object).GetUrlGitGub();

            //Test
            Assert.Equal(fakeUrlGitHubApiTaxaJuros, view.ApiTaxaJuros);
        }

        [Fact]
        public void GetUrlGitGub_TestaRetornoUrlGitHubApiCalculaJuros()
        {
            //Arrange
            var fakeUrlGitHubApiCalculaJuros = "http://teste.com.br/GitHubApiCalculaJuros";

            var mockConfiguration = new Mock<IConfiguration>();            
            mockConfiguration.SetupGet(p => p["UrlGitHubApiCalculaJuros"]).Returns(fakeUrlGitHubApiCalculaJuros);

            //Act
            var view = new ShowMeTheCodeAplic(mockConfiguration.Object).GetUrlGitGub();

            //Test
            Assert.Equal(fakeUrlGitHubApiCalculaJuros, view.ApiCalculaJuros);
        }
    }
}
