using ApiCalculaJuros.Aplicacao.CalculaJuros;
using ApiCalculaJuros.Aplicacao.CalculaJuros.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculaJuros.Controllers
{
    [ApiController]
    [Route("CalculaJuros")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosAplic _calculaJurosAplic;

        public CalculaJurosController(ICalculaJurosAplic calculaJurosAplic)
        {
            _calculaJurosAplic = calculaJurosAplic;
        }

        [HttpGet]        
        public async Task<decimal> CalcularAsync([FromQuery]CalculaJurosDto dto)
        {
            return await _calculaJurosAplic.CalcularAsync(dto);
        }
    }
}
