﻿using FSP.HBSIS.Infra.Data.UoW;

namespace FSP.HBSIS.Application
{
    public class AppService
    {
        private readonly IUnitOfWork _uow;

        public AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}