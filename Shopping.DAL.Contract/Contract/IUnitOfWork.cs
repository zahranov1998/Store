namespace Shopping.DAL.Contract.Contract;

public interface IUnitOfWork
{
    Task Commit();
}