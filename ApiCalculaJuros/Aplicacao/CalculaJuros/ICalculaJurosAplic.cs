using ApiCalculaJuros.Aplicacao.CalculaJuros.Dto;
using System.Threading.Tasks;

namespace ApiCalculaJuros.Aplicacao.CalculaJuros
{
    public interface ICalculaJurosAplic
    {
        Task<decimal> CalcularAsync(CalculaJurosDto dto);
    }
}