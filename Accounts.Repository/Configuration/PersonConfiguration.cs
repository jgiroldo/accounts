using Accounts.Domain.Entities;
using Accounts.Framework.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Repository.Configuration
{
    internal class PersonConfiguration : EntityModelBuilder<Person>
    {
        public PersonConfiguration(ModelBuilder builder) : base(builder)
        {
        }

        protected override void Build(EntityTypeBuilder<Person> entity)
        {
            entity.ToTable("PERSON");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasColumnName("ID")
                  .IsRequired()
                  .UseSqlServerIdentityColumn();

            entity.Property(e => e.CpfCnpj)
                  .HasColumnName("CPF_CNPJ")
                  .IsRequired();

            entity.Property(e => e.Name)
                  .HasColumnName("NAME")
                  .HasMaxLength(100);

            entity.Property(e => e.BirthDate)
                  .HasColumnName("BIRTH_DATE");

            entity.Property(e => e.SocialName)
                  .HasColumnName("SOCIAL_NAME");

            entity.Property(e => e.ConpanyName)
                  .HasColumnName("COMPANY_NAME");
        }
    }
}
