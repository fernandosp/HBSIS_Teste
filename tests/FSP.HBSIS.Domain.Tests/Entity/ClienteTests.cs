using System;
using System.Linq;
using FSP.HBSIS.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FSP.HBSIS.Domain.Tests.Entity
{
    [TestClass]
    public class ClienteTests
    {
        // AAA -> Arrange, Act, Assert

        [TestMethod]
        public void Cliente_ValidarConsistencia_True()
        {
            // Arrange
            var cliente = new Cliente()
            {
                Codigo = "xpto1234",
                Nome = "Fernando 1",
                CPF = "30390600821",
                Telefone = "(11)99234-1123"
            };

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Cliente_ValidarConsistencia_False()
        {
            // Arrange
            var cliente = new Cliente()
            {
                Codigo = "xpto1234",
                Nome = "Fernando 1",
                CPF = "30390600821",               
                Telefone = "(11)99234-1123"
            };

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido."));
        }
    }
}
