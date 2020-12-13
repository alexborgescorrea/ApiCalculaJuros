using ApiCalculaJuros.Aplicacao.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApiCalculaJuros.Test.Aplicacao.Helpers
{
    public class CalculadoraJurosHelperTest
    {
        [Theory]
        [InlineData(100_000, 60, 0.01, 181_669.66)]
        [InlineData(200_000, 120, 0.005, 363_879.34)]
        public void Calcular_CalculaValorCorreto(decimal valorInicial, int meses, decimal juros, decimal valorEsperado)
        {
            var valorCalculado = CalculadoraJurosHelper.Calcular(valorInicial, meses, juros);

            Assert.Equal(valorEsperado, valorCalculado);
        }
    }
}
