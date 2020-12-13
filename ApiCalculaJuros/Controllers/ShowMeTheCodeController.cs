using ApiCalculaJuros.Aplicacao.ShowMeTheCode;
using ApiCalculaJuros.Aplicacao.ShowMeTheCode.View;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculaJuros.Controllers
{
    [ApiController]
    [Route("ShowMeTheCode")]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly IShowMeTheCodeAplic _showMeTheCodeAplic;

        public ShowMeTheCodeController(IShowMeTheCodeAplic showMeTheCodeAplic)
        {
            _showMeTheCodeAplic = showMeTheCodeAplic;
        }

        [HttpGet]
        public UrlGitHubView CalcularAsync()
        {
            return _showMeTheCodeAplic.GetUrlGitGub();
        }
    }
}
