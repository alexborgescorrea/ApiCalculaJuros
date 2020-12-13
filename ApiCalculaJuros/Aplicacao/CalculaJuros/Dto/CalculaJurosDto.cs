using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculaJuros.Aplicacao.CalculaJuros.Dto
{
    public class CalculaJurosDto
    {
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
    }
}
