using System;
using System.Threading.Tasks;
using DevLuan.Business.Intefaces;
using DevLuan.Business.Models;
using DevLuan.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevLuan.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}