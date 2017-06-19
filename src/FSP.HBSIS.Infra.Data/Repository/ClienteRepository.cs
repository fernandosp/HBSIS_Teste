using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using FSP.HBSIS.Domain.Entities;
using FSP.HBSIS.Domain.Interfaces.Repository;
using FSP.HBSIS.Infra.Data.Context;

namespace FSP.HBSIS.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(HBSISContext context)
            :base(context)
        {
            
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorCodigo(string codigo)
        {
            return Buscar(c => c.Codigo == codigo).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => c.Ativo);
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Clientes where ativo = 1";

            return cn.Query<Cliente>(sql);
        }

        public override Cliente ObterPorId(Guid id)
        {
            return Buscar(c => c.ClienteId == id).FirstOrDefault();
        }

    }
}