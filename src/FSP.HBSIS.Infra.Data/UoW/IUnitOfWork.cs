namespace FSP.HBSIS.Infra.Data.UoW
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}