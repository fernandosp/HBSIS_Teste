using System.Collections.Generic;
using FSP.HBSIS.Domain.Entities;

namespace FSP.HBSIS.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorCodigo(string codigo);
        IEnumerable<Cliente> ObterAtivos();
    }
}