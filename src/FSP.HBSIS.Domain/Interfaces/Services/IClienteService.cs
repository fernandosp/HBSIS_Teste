using System;
using System.Collections.Generic;
using FSP.HBSIS.Domain.Entities;

namespace FSP.HBSIS.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente ObterPorId(Guid id);
        IEnumerable<Cliente> ObterTodos();
        Cliente ObterPorCpf(string cpf);
        IEnumerable<Cliente> ObterAtivos();
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id); 
    }
}