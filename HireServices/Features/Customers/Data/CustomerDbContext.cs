using HireServices.Common.ValueObjects;
using HireServices.Features.Customers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace HireServices.Features.Customers.Data;

public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.ContactInfo, ci =>
            {
                ci.Property(p => p.FirstName).HasColumnName("FirstName");
                ci.Property(p => p.LastName).HasColumnName("LastName");
                ci.Property(p => p.Email).HasColumnName("Email");
                ci.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
                ci.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth");
            });

        modelBuilder.Entity<Customer>()
            .Property(c => c.Addresses)
            .HasColumnType("jsonb")
            .HasConversion(
                new ValueConverter<JsonDocument, string>(
                    v => v != null ? v.RootElement.GetRawText() : string.Empty,
                    v => !string.IsNullOrEmpty(v) ? JsonDocument.Parse(v, default) : null))
            .IsRequired(false);
    }
}
public class ContactInfoConverter : ValueConverter<ContactInfo, string>
{
    public ContactInfoConverter() : base(
        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
        v => JsonSerializer.Deserialize<ContactInfo>(v, (JsonSerializerOptions)null!)!)
    {
    }
}
