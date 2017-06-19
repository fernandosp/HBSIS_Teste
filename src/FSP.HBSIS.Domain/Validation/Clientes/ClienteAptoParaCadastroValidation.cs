using DomainValidation.Validation;
using FSP.HBSIS.Domain.Entities;
using FSP.HBSIS.Domain.Interfaces.Repository;
using FSP.HBSIS.Domain.Specifications.Clientes;

namespace FSP.HBSIS.Domain.Validation.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, "CPF já cadastrado! "));

        }
    }
}