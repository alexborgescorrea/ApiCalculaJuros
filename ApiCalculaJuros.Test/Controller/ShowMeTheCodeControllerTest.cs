using ApiCalculaJuros.Aplicacao.CalculaJuros;
using ApiCalculaJuros.Aplicacao.CalculaJuros.Dto;
using ApiCalculaJuros.Aplicacao.ShowMeTheCode;
using ApiCalculaJuros.Aplicacao.ShowMeTheCode.View;
using ApiCalculaJuros.Aplicacao.TaxaJuros;
using ApiCalculaJuros.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiCalculaJuros.Test.Controller
{
    public class ShowMeTheCodeControllerTest
    {
        [Fact]
        public void GetUrlGitGub_TestaRetornoUrlGitHubApiTaxaJuros()
        {
            //arrange
            var fakeUrlGitHubApiTaxaJuros = "http://teste.com.br/GitHubApiTaxaJuros";            

            var mockShowMeTheCodeAplic = new Mock<IShowMeTheCodeAplic>();
            mockShowMeTheCodeAplic.Setup(p => p.GetUrlGitGub()).Returns(new UrlGitHubView
            {
                ApiTaxaJuros = fakeUrlGitHubApiTaxaJuros,               
            });

            var showMeTheCodeController = new ShowMeTheCodeController(mockShowMeTheCodeAplic.Object);

            //act            
            var view = showMeTheCodeController.GetUrlGitGub();

            //test
            Assert.Equal(fakeUrlGitHubApiTaxaJuros, view.ApiTaxaJuros);
        }

        [Fact]
        public void GetUrlGitGub_TestaRetornoUrlGitHubApiCalculaJuros()
        {
            //arrange
            var fakeUrlGitHubApiCalculaJuros = "http://teste.com.br/GitHubApiCalculaJuros";

            var mockShowMeTheCodeAplic = new Mock<IShowMeTheCodeAplic>();
            mockShowMeTheCodeAplic.Setup(p => p.GetUrlGitGub()).Returns(new UrlGitHubView
            {
                ApiCalculaJuros = fakeUrlGitHubApiCalculaJuros,
            });

            var showMeTheCodeController = new ShowMeTheCodeController(mockShowMeTheCodeAplic.Object);

            //act            
            var view = showMeTheCodeController.GetUrlGitGub();

            //test
            Assert.Equal(fakeUrlGitHubApiCalculaJuros, view.ApiCalculaJuros);
        }
    }
}
