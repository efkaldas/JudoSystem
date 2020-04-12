using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Contracts.Interfaces
{
    public interface IJudokaRepository : IRepositoryBase<Judoka>
    {
        IQueryable<Judoka> FindByConditionFull(Expression<Func<Judoka, bool>> expression);
        List<Judoka> FindAllFull();
    }
}
