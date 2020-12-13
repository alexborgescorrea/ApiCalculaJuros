using ApiCalculaJuros.Aplicacao.CalculaJuros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiCalculaJuros.Test.Aplicacao.CalculaJuros
{
    public class CalculaJurosAplicTest
    {
        public async Task CalcularAsync_TesteValorCorreto()
        {
            var calculaJurosAplic = new CalculaJurosAplic();

            var valorAtual = await calculaJurosAplic.CalcularAsync();

            Assert.True(false);
        }
    }
}
