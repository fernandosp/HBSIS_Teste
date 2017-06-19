using System;
using FSP.HBSIS.Infra.Data.Context;

namespace FSP.HBSIS.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HBSISContext _context;
        private bool _disposed;

        public UnitOfWork(HBSISContext context)
        {
            _context = context;
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}