using Accounts.Domain.Entities;
using Accounts.Framework.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Accounts.Repository.Configuration
{
    class TransactionConfiguration : EntityModelBuilder<Transaction>
    {
        public TransactionConfiguration(ModelBuilder builder) : base(builder)
        {
        }

        protected override void Build(EntityTypeBuilder<Transaction> entity)
        {
            entity.ToTable("TRANSACTION");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasColumnName("ID")
                  .IsRequired()
                  .HasDefaultValue(Guid.NewGuid());

            entity.Property(e => e.OperationDate)
                  .HasColumnName("OPERATION_DATE")
                  .IsRequired()
                  .HasDefaultValueSql("getDate()");

            entity.Property(e => e.OperationType)
                  .HasColumnName("OPERATION_TYPE")
                  .IsRequired();

            entity.Property(e => e.SourceAccountId)
                  .HasColumnName("SOURCE_ACCOUNT_ID");

            entity.Property(e => e.DestinyAccountId)
                  .HasColumnName("DESTINY_ACCOUNT_ID");


            entity.Property(e => e.Value)
                  .HasColumnName("VALUE")
                  .IsRequired();

            entity.Property(e => e.IsReversed)
                  .HasColumnName("IS_REVERSED")
                  .IsRequired()
                  .HasDefaultValue(false);

            entity.HasOne(e => e.SourceAccount)
                  .WithMany()
                  .HasConstraintName("FK_TRANSACTION_SOURCE_ACCOUNT")
                  .HasForeignKey(e => e.SourceAccountId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.DestinyAccount)
                  .WithMany()
                  .HasConstraintName("FK_TRANSACTION_DESTINY_ACCOUNT")
                  .HasForeignKey(e => e.DestinyAccountId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
