﻿using FSP.HBSIS.Domain.Entities;
using FSP.HBSIS.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FSP.HBSIS.Domain.Tests.Specification
{
    [TestClass]
    public class CPFSpecificationTests
    {
         // AAA -> Arrange, Act, Assert

        [TestMethod]
        public void CPFSpecification_IsSatisfied_True()
        {
            // Arrange
            var cliente = new Cliente()
            {
                CPF = "30390600822"
            };

            // Act
            var specReturn = new ClienteDeveTerCpfValidoSpecification()
                                 .IsSatisfiedBy(cliente);

            // Assert
            Assert.IsTrue(specReturn);
        }

        [TestMethod]
        public void CPFSpecification_IsSatisfied_False()
        {
            // Arrange
            var cliente = new Cliente()
            {
                CPF = "30390600821"
            };

            // Act
            var specReturn = new ClienteDeveTerCpfValidoSpecification()
                                 .IsSatisfiedBy(cliente);

            // Assert
            Assert.IsFalse(specReturn);
        }
    }
}