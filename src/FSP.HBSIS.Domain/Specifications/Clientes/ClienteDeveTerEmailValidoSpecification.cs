using DomainValidation.Interfaces.Specification;
using FSP.HBSIS.Domain.Entities;
using FSP.HBSIS.Domain.Validation.Documentos;

namespace FSP.HBSIS.Domain.Specifications.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return EmailValidation.Validar(cliente.Codigo);
        }
    }
}