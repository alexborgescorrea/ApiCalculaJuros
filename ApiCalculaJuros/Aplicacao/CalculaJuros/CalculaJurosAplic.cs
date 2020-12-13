using ApiCalculaJuros.Aplicacao.CalculaJuros.Dto;
using ApiCalculaJuros.Aplicacao.Helpers;
using ApiCalculaJuros.Aplicacao.TaxaJuros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculaJuros.Aplicacao.CalculaJuros
{
    public class CalculaJurosAplic : ICalculaJurosAplic
    {
        private readonly ITaxaJurosAplic _taxaJurosAplic;

        public CalculaJurosAplic(ITaxaJurosAplic taxaJurosAplic)
        {
            _taxaJurosAplic = taxaJurosAplic;
        }

        public async Task<decimal> CalcularAsync(CalculaJurosDto dto)
        {
            var juros = await _taxaJurosAplic.TaxaPadraoAsync();

            return CalculadoraJurosHelper.Calcular(dto.ValorInicial, dto.Meses, juros);
        }
    }
}
