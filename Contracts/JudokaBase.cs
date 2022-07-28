using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Contracts
{
    public abstract class JudokaBase : RepositoryBase<Judoka>, IJudokaRepository
    {
        public JudokaBase(JudoDbContext repositoryContext) : base(repositoryContext)
        {
        }
        public IQueryable<Judoka> FindByConditionFull(Expression<Func<Judoka, bool>> expression)
        {
            return this.RepositoryContext.Set<Judoka>().Where(expression).AsNoTracking()
                .Include(x => x.DanKyu);
        }
        public List<Judoka> FindAllFull()
        {
            return this.RepositoryContext.Set<Judoka>().AsNoTracking()
                .Include(x => x.DanKyu).ToList();
        }
    }
}
