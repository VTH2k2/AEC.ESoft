using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.Data.SQL.Contexts;
using AEC.Core.Data;
using AEC.Lib.Data.SQL;

namespace AEC.ESoft.Infra.Data.SQL
{
    public class ESoftRepositoryBase<T> : RepositoryBase<T> where T : class, IRepository
    {
        protected ESoftRepositoryBase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        protected override string DefaultConnectionName
        {
            get
            {
                return "ESoft";
            }
        }

        protected void UseDefaultDbContext(Action<ESoftSqlDbContext> action)
        {
            UseDbContext(action);
        }
        protected TOut UseDefaultDbContext<TOut>(Func<ESoftSqlDbContext, TOut> action)
        {
            return UseDbContext(action);
        }
        protected Task<TOut> UseDefaultDbContext<TOut>(Func<ESoftSqlDbContext, Task<TOut>> action)
        {
            return UseDbContext(action);
        }
    }
}
