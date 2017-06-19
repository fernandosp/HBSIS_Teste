using System;
using System.Collections.Generic;
using FSP.HBSIS.Domain.Entities;
using FSP.HBSIS.Domain.Interfaces.Repository;
using FSP.HBSIS.Domain.Interfaces.Services;
using FSP.HBSIS.Domain.Validation.Clientes;

namespace FSP.HBSIS.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return cliente;

            cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente);
            if (!cliente.ValidationResult.IsValid)
                return cliente;

            return _clienteRepository.Adicionar(cliente);
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }
                
        public IEnumerable<Cliente> ObterAtivos()
        {
            return _clienteRepository.ObterAtivos();
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}