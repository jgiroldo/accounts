﻿// <auto-generated />
using System;
using Accounts.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Accounts.Repository.Migrations
{
    [DbContext(typeof(AccountsContext))]
    [Migration("20180921165006_adjustsTransactions1")]
    partial class adjustsTransactions1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Accounts.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BALANCE")
                        .HasDefaultValue(0f);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CREATION_DATE")
                        .HasDefaultValueSql("getDate()");

                    b.Property<int?>("MasterAccount")
                        .HasColumnName("MASTER_ACCOUNT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(100);

                    b.Property<int?>("ParentAccount")
                        .HasColumnName("PARENT_ACCOUNT");

                    b.Property<int>("PersonId")
                        .HasColumnName("PERSON_ID");

                    b.Property<int>("Status")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("ACCOUNT");
                });

            modelBuilder.Entity("Accounts.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnName("BIRTH_DATE");

                    b.Property<string>("ConpanyName")
                        .HasColumnName("COMPANY_NAME");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnName("CPF_CNPJ");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(100);

                    b.Property<string>("SocialName")
                        .HasColumnName("SOCIAL_NAME");

                    b.HasKey("Id");

                    b.ToTable("PERSON");
                });

            modelBuilder.Entity("Accounts.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasDefaultValue(new Guid("666d53a9-c81e-4605-905b-e5ea91ceefe7"));

                    b.Property<int>("DestinyAccountId")
                        .HasColumnName("DESTINY_ACCOUNT_ID");

                    b.Property<DateTime>("OperationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OPERATION_DATE")
                        .HasDefaultValueSql("getDate()");

                    b.Property<int>("OperationType")
                        .HasColumnName("OPERATION_TYPE");

                    b.Property<int?>("SourceAccountId")
                        .HasColumnName("SOURCE_ACCOUNT_ID");

                    b.Property<float>("Value")
                        .HasColumnName("VALUE");

                    b.HasKey("Id");

                    b.HasIndex("DestinyAccountId");

                    b.HasIndex("SourceAccountId");

                    b.ToTable("TRANSACTION");
                });

            modelBuilder.Entity("Accounts.Domain.Entities.Account", b =>
                {
                    b.HasOne("Accounts.Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .HasConstraintName("FK_ACCOUNT_PERSON")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Accounts.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Accounts.Domain.Entities.Account", "DestinyAccount")
                        .WithMany()
                        .HasForeignKey("DestinyAccountId")
                        .HasConstraintName("FK_TRANSACTION_DESTINY_ACCOUNT")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Accounts.Domain.Entities.Account", "SourceAccount")
                        .WithMany()
                        .HasForeignKey("SourceAccountId")
                        .HasConstraintName("FK_TRANSACTION_SOURCE_ACCOUNT")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
