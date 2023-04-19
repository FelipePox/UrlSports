using HelpURL.Infra.Data.Context;

namespace HelpURL.Infra.Data.Transactions;

public sealed class UnitOfWork : IUnitOfWork
{
    private HelpURLContext _context;

    public UnitOfWork(HelpURLContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
}