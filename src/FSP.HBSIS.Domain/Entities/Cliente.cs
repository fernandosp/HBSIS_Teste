using System;
using System.Collections.Generic;
using DomainValidation.Validation;
using FSP.HBSIS.Domain.Validation.Clientes;

namespace FSP.HBSIS.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
        }

        public Guid ClienteId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
       public string Telefone { get; set; }
        
        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }
        

        public bool EhValido()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}