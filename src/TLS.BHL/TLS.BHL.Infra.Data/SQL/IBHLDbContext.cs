using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.Lib.Data.Sql;

namespace AEC.ESoft.Infra.Data.SQL
{
    public interface IESoftDbContext : IDbContext
    {
        DbSet<CategoryEntity> Categories { get; }
    }
}
