using System.Linq;
using FSP.HBSIS.Domain.Entities;
using FSP.HBSIS.Domain.Interfaces.Repository;
using FSP.HBSIS.Domain.Validation.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace FSP.HBSIS.Domain.Tests.Validation
{
    [TestClass]
    public class ClienteAptoParaCadastroTests
    {
        // AAA -> Arrange, Act, Assert
        [TestMethod]
        public void ClienteApto_IsValid_True()
        {
            // Arrange
            var cliente = new Cliente()
            {
                CPF = "30390600822",
                Codigo = "cliente@cliente.com"
            };

            // Act
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(null);
            repo.Stub(s => s.ObterPorCodigo(cliente.Codigo)).Return(null);

            var valitationReturn = new ClienteAptoParaCadastroValidation(repo)
                                       .Validate(cliente);

            // Assert
            Assert.IsTrue(valitationReturn.IsValid);
        }

        [TestMethod]
        public void ClienteApto_IsValid_False()
        {
            // Arrange
            var cliente = new Cliente()
            {
                CPF = "30390600822",
                Codigo = "cliente@cliente.com"
            };

            // Act
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(cliente);
            repo.Stub(s => s.ObterPorCodigo(cliente.Codigo)).Return(cliente);

            var validationReturn = new ClienteAptoParaCadastroValidation(repo)
                                       .Validate(cliente);

            // Assert
            Assert.IsFalse(validationReturn.IsValid);
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "CPF já cadastrado! "));
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "E-mail já cadastrado! "));
        }
    }
}