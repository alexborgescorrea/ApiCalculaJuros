using ApiCalculaJuros.Aplicacao.CalculaJuros;
using ApiCalculaJuros.Aplicacao.CalculaJuros.Dto;
using ApiCalculaJuros.Aplicacao.TaxaJuros;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiCalculaJuros.Test.Aplicacao.CalculaJuros
{
    public class CalculaJurosAplicTest
    {
        [Fact]
        public async Task CalcularAsync_TesteValorCorreto()
        {
            //arrange
            var mockTaxaJurosAplic = new Mock<ITaxaJurosAplic>();
            mockTaxaJurosAplic.Setup(p => p.TaxaPadraoAsync()).ReturnsAsync(0.01m);

            var calculaJurosAplic = new CalculaJurosAplic(mockTaxaJurosAplic.Object);
            var dto = new CalculaJurosDto
            {
                ValorInicial = 100_000,
                Meses = 60                
            };

            //act
            var valorAtual = await calculaJurosAplic.CalcularAsync(dto);

            //test
            Assert.Equal(181_669.66m, valorAtual);
        }
    }
}
