using Shopping.DAL.Contract.Contract;
using Shopping.DAL.DbContexts;

namespace Shopping.DAL.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly EFDbContext _dbContext;

    public UnitOfWork(EFDbContext eFDbContext)
    {
        _dbContext = eFDbContext;
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}