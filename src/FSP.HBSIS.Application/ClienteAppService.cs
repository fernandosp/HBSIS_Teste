using System;
using System.Collections.Generic;
using AutoMapper;
using FSP.HBSIS.Application.Interfaces;
using FSP.HBSIS.Application.ViewModels;
using FSP.HBSIS.Domain.Entities;
using FSP.HBSIS.Domain.Interfaces.Repository;
using FSP.HBSIS.Domain.Interfaces.Services;
using FSP.HBSIS.Domain.Services;
using FSP.HBSIS.Infra.Data.Repository;
using FSP.HBSIS.Infra.Data.UoW;

namespace FSP.HBSIS.Application
{
    public class ClienteAppService : AppService, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork uow)
            :base(uow)
        {
            _clienteService = clienteService;
        }

        public ClienteViewModel Adicionar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            
           var clienteReturn = _clienteService.Adicionar(cliente);

            // Se deu tudo certo no dominio
            if (clienteReturn.ValidationResult.IsValid)
            {
                Commit();
            }
            clienteViewModel = Mapper.Map<ClienteViewModel>(clienteReturn);

            return clienteViewModel;
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);

            return Mapper.Map<ClienteViewModel>(_clienteService.Atualizar(cliente));
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}