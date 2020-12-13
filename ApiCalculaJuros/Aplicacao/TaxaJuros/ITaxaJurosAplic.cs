using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculaJuros.Aplicacao.TaxaJuros
{
    public interface ITaxaJurosAplic
    {
        Task<decimal> TaxaPadraoAsync();
    }
}
