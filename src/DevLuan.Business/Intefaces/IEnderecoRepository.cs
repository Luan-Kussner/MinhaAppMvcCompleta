using System;
using System.Threading.Tasks;
using DevLuan.Business.Models;

namespace DevLuan.Business.Intefaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}