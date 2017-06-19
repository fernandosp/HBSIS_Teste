using System;
using System.Collections.Generic;
using FSP.HBSIS.Application.ViewModels;

namespace FSP.HBSIS.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteViewModel Adicionar(ClienteViewModel clienteViewModel);
        ClienteViewModel ObterPorId(Guid id);
        IEnumerable<ClienteViewModel> ObterTodos();
        ClienteViewModel ObterPorCpf(string cpf);
        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
        void Remover(Guid id);  
    }
}