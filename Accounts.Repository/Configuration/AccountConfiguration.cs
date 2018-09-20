using Accounts.Domain.Entities;
using Accounts.Framework.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Repository.Configuration
{
    internal class AccountConfiguration : EntityModelBuilder<Account>
    {
        public AccountConfiguration(ModelBuilder builder) : base(builder)
        {
        }

        protected override void Build(EntityTypeBuilder<Account> entity)
        {
            entity.ToTable("ACCOUNT");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasColumnName("ID")
                  .IsRequired()
                  .UseSqlServerIdentityColumn();

            entity.Property(e => e.CreationDate)
                  .HasColumnName("CREATION_DATE")
                  .IsRequired()
                  .HasDefaultValueSql("getDate()");

            entity.Property(e => e.Name)
                  .HasColumnName("NAME")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.ParentAccount)
                  .HasColumnName("PARENT_ACCOUNT");

            entity.Property(e => e.MasterAccount)
                  .HasColumnName("MASTER_ACCOUNT");

            entity.Property(e => e.Status)
                  .HasColumnName("STATUS")
                  .IsRequired();

            entity.Property(e => e.PersonId)
                  .HasColumnName("PERSON_ID")
                  .IsRequired();

            entity.HasOne(e => e.Person)
                  .WithMany()
                  .HasConstraintName("FK_ACCOUNT_PERSON")
                  .HasForeignKey(e => e.PersonId)
                  .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
