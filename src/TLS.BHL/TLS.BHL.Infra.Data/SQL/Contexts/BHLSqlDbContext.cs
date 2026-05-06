using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.Lib.Data.Sql;

namespace AEC.ESoft.Infra.Data.SQL.Contexts
{
    public class ESoftSqlDbContext : SqlDbContext, IESoftDbContext
    {
        public ESoftSqlDbContext(DbContextOptions<ESoftSqlDbContext> options) : base(options)
        {
        }


        public DbSet<CategoryEntity>Categories { get; set; }

        public int SaveChanges()
        {
            ValidateEntities();
            return base.SaveChanges();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ValidateEntities();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void ValidateEntities()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    var validationResults = new List<ValidationResult>();
                    var validationContext = new ValidationContext(entry.Entity);

                    if (!Validator.TryValidateObject(entry.Entity, validationContext, validationResults, true))
                    {
                        throw new ValidationException("Entity validation failed.");
                    }
                }
            }
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("data source=192.168.222.13\\sql2014;initial catalog=TestNetCore;persist security info=True;user id=sa;password=dsvn@123456;multipleactiveresultsets=True;Max Pool Size=1000;Connect Timeout=600;TrustServerCertificate=true;");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<CategoryEntity>(entity =>
            {
                entity.Property(x => x.Id).UseIdentityColumn(1, 1);
                entity.Property(x => x.Name).IsUnicode().HasMaxLength(50);
                entity.Property(x => x.Description);
            });
        }
    }
}
