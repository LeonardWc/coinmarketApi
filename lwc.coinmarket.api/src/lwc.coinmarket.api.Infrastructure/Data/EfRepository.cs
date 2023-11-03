﻿using Ardalis.Specification.EntityFrameworkCore;
using Ardalis.SharedKernel;

namespace lwc.coinmarket.api.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
