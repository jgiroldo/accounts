using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Framework.Database
{
    /// <summary>
    /// Base para DbContext
    /// </summary>
    public abstract class BaseDbContext : DbContext
    {
        /// <summary>
        /// Transa~ção de banco de dados
        /// </summary>
        IDbContextTransaction transaction = null;

        /// <summary>
        /// Base para DbContext
        /// </summary>
        public BaseDbContext(DbContextOptions options)
        : base(options)
        {
        }

        /// <summary>
        /// Inicializa modelo
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Sobreescrita do savechanges
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        /// <summary>
        /// Inicia transacao
        /// </summary>
        public void BeginTransaction()
        {
            if (transaction == null)
                transaction = Database.BeginTransaction();
        }

        /// <summary>
        /// Desfaz transação
        /// </summary>
        public void RollbackTransaction()
        {
            if (transaction != null)
            {
                Database.RollbackTransaction();
                transaction = null;
            }
        }

        /// <summary>
        /// Commita transação
        /// </summary>
        public void CommitTransaction()
        {
            if (transaction != null)
            {
                Database.CommitTransaction();
                transaction = null;
            }
        }

        public override void Dispose()
        {
            RollbackTransaction();
            base.Dispose();
        }
    }
}
