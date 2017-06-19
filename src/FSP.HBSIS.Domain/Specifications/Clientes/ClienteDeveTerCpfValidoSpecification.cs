using DomainValidation.Interfaces.Specification;
using FSP.HBSIS.Domain.Entities;
using FSP.HBSIS.Domain.Validation.Documentos;

namespace FSP.HBSIS.Domain.Specifications.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPFValidation.Validar(cliente.CPF);
        }
    }
}