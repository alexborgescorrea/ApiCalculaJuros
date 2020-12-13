using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculaJuros.Aplicacao.Helpers
{
    public static class CalculadoraJurosHelper
    {
        public static decimal Calcular(decimal valorInicial, int meses, decimal juros)
        {
            var valorJuros = (double)valorInicial * Math.Pow((1 + (double)juros), meses);

            return decimal.Truncate((decimal)valorJuros * 100m) / 100;
        }
    }
}
