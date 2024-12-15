using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.Data
{
    public class ServicesProviderDbContext(DbContextOptions<ServicesProviderDbContext> options) : DbContext(options)
    {
        public DbSet<ServicesProvider> ServiceProviders { get; set; }
        public DbSet<ServicesProviderService> ServicesProviderServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServicesProvider>()
                .Property(sp => sp.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServicesProvider>()
                .OwnsOne(sp => sp.ContactInfo, ci =>
                {
                    ci.Property(p => p.FirstName).HasColumnName("FirstName");
                    ci.Property(p => p.LastName).HasColumnName("LastName");
                    ci.Property(p => p.Email).HasColumnName("Email");
                    ci.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
                    ci.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth");
                });

            modelBuilder.Entity<ServicesProvider>()
                .Property(sp => sp.Address)
                .HasColumnType("jsonb")
                .HasConversion(
                    new ValueConverter<JsonDocument, string>(
                        v => v != null ? v.RootElement.GetRawText() : string.Empty,
                        v => !string.IsNullOrEmpty(v) ? JsonDocument.Parse(v, default) : null))
                .IsRequired(true);

            modelBuilder.Entity<ServicesProvider>()
                .Property(sp => sp.ServiceTags)
                .HasColumnType("TEXT[]")
                .IsRequired(true);

            //modelBuilder.Entity<ServicesProvider>()
            //    .Property(sp => sp.Services)
            //    .HasColumnType("jsonb")
            //    .HasConversion(
            //        new ValueConverter<JsonDocument, string>(
            //            v => v != null ? v.RootElement.GetRawText() : string.Empty,
            //            v => !string.IsNullOrEmpty(v) ? JsonDocument.Parse(v, default): null))
            //    .IsRequired(true);
        }
    }
}
