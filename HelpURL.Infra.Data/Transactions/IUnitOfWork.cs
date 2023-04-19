﻿namespace HelpURL.Infra.Data.Transactions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
