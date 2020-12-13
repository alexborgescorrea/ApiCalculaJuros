using ApiCalculaJuros.Aplicacao.CalculaJuros;
using ApiCalculaJuros.Aplicacao.CalculaJuros.Dto;
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
    public class CalculaJurosControllerTest
    {
        [Fact]
        public async Task CalcularAsync_TesteValorCorreto()
        {            
            var mockCalculaJurosAplic = new Mock<ICalculaJurosAplic>();
            mockCalculaJurosAplic.Setup(p => p.CalcularAsync(It.IsAny<CalculaJurosDto>())).ReturnsAsync(100m);            

            var calculaJurosController = new CalculaJurosController(mockCalculaJurosAplic.Object);
            var valorAtual = await calculaJurosController.CalcularAsync(new CalculaJurosDto());

            Assert.Equal(100m, valorAtual);
        }
    }
}
