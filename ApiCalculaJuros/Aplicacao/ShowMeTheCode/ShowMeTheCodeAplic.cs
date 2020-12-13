using ApiCalculaJuros.Aplicacao.ShowMeTheCode.View;
using Microsoft.Extensions.Configuration;

namespace ApiCalculaJuros.Aplicacao.ShowMeTheCode
{
    public class ShowMeTheCodeAplic : IShowMeTheCodeAplic
    {
        private readonly IConfiguration _configuration;

        public ShowMeTheCodeAplic(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UrlGitHubView GetUrlGitGub()
        {
            return new UrlGitHubView
            {
                ApiTaxaJuros = _configuration["UrlGitHubApiTaxaJuros"],
                ApiCalculaJuros = _configuration["UrlGitHubApiCalculaJuros"]
            };
        }
    }
}
