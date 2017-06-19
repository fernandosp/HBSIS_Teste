using DomainValidation.Validation;
using FSP.HBSIS.Domain.Entities;
using FSP.HBSIS.Domain.Specifications.Clientes;

namespace FSP.HBSIS.Domain.Validation.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var CPFCliente = new ClienteDeveTerCpfValidoSpecification();

            base.Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido."));
        }
    }
}