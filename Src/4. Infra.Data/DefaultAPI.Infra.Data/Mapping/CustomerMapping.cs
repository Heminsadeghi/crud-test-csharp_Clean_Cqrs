using DefaultAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultAPI.Infra.Data.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        private EntityTypeBuilder<Customer> _builder;

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            _builder = builder;
            _builder.ToTable("Customers");
            ConfigureColumns();
        }

        private void ConfigureColumns()
        {
            _builder.HasKey(x => x.Id);
            _builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1).HasColumnName("Id");
            _builder.Property(x => x.Firstname).IsRequired().HasMaxLength(100).HasColumnName("Firstname");
            _builder.Property(x => x.Lastname).IsRequired().HasMaxLength(100).HasColumnName("Lastname");
            _builder.Property(x => x.Email).IsRequired().HasMaxLength(100).HasColumnName("Email");

            _builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20).HasColumnName("PhoneNumber");
            _builder.Property(x => x.BankAccountNumber).IsRequired().HasMaxLength(20).HasColumnName("BankAccountNumber");
            _builder.Property(x => x.DateOfBirth).IsRequired().HasColumnName("DateOfBirth");

            _builder.Property(x => x.CreatedTime).HasDefaultValue(DateTime.Now).HasColumnName("Created_Time");
            _builder.Property(x => x.UpdateTime).HasColumnName("Update_Time");
            _builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnName("Is_Active");
        }
    }
}