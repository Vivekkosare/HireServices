using HireServices.Features.ServiceProviders.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.Data
{
    public class ProviderDbContext(DbContextOptions<ProviderDbContext> options) : DbContext(options)
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderService> ProviderServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Provider>()
                .Property(sp => sp.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Provider>()
                .OwnsOne(sp => sp.ContactInfo, ci =>
                {
                    ci.Property(p => p.FirstName).HasColumnName("FirstName");
                    ci.Property(p => p.LastName).HasColumnName("LastName");
                    ci.Property(p => p.Email).HasColumnName("Email");
                    ci.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
                    ci.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth");
                });

            modelBuilder.Entity<Provider>()
                .Property(sp => sp.Address)
                .HasColumnType("jsonb")
                .HasConversion(
                    new ValueConverter<JsonDocument, string>(
                        v => v != null ? v.RootElement.GetRawText() : string.Empty,
                        v => !string.IsNullOrEmpty(v) ? JsonDocument.Parse(v, default) : null))
                .IsRequired(true);

            modelBuilder.Entity<Provider>()
                .Property(sp => sp.ServiceTags)
                .HasColumnType("TEXT[]")
                .IsRequired(true);

            modelBuilder.Entity<Provider>()
                .HasIndex(p => p.ServiceTags)
                .HasMethod("gin");

            modelBuilder.Entity<Provider>()
                .Property(p => p.ServiceCategories)
                .HasColumnType("TEXT[]")
                .IsRequired(true);

            modelBuilder.Entity<Provider>()
                .HasIndex(p => p.ServiceCategories)               
                .HasMethod("gin");

            modelBuilder.Entity<Provider>()
                .Property(p => p.HighlightedServices)
                .HasColumnType("jsonb")
                .HasConversion(
                    new ValueConverter<JsonDocument, string>(
                        v => v != null ? v.RootElement.GetRawText() : string.Empty,
                        v => !string.IsNullOrEmpty(v) ? JsonDocument.Parse(v, default) : null))
                .IsRequired(true);

            modelBuilder.Entity<Provider>()
                .Property(p => p.AverageRating)
                .HasColumnType("decimal");

            modelBuilder.Entity<Provider>()
                .Property(p => p.CustomersServed)
                .HasColumnType("int");

            modelBuilder.Entity<Provider>()
                .Property(p => p.LatestReviews)
                .HasColumnType("jsonb")
                .HasConversion(
                    new ValueConverter<JsonDocument, string>(
                        v => v != null ? v.RootElement.GetRawText() : string.Empty,
                        v => !string.IsNullOrEmpty(v) ? JsonDocument.Parse(v, default) : null));

            //***************************************--------PROVIDER SERVICE--------***************************************//


            modelBuilder.Entity<ProviderService>()
                .Property(sps => sps.Id)
                .ValueGeneratedOnAdd();

            //modelBuilder.Entity<ProviderService>()
            //    .HasOne<Provider>()
            //    .WithMany()
            //    .HasForeignKey(sps => sps.ProviderId)
            //    .IsRequired(true);

            modelBuilder.Entity<ProviderService>()
                .HasOne(sp => sp.Provider)
                .WithMany(sps => sps.ProviderServices)
                .HasForeignKey(sps => sps.ProviderId)
                .IsRequired(true);

            modelBuilder.Entity<ProviderService>()
                .Property(sps => sps.ProviderId).IsRequired(true);

            modelBuilder.Entity<ProviderService>()
                .Property(sps => sps.Name)
                .IsRequired(true);

            modelBuilder.Entity<ProviderService>()
                .Property(p => p.Description).IsRequired(false);

            modelBuilder.Entity<ProviderService>()
                .Property(p => p.Category)
                .HasColumnType("jsonb")
                .HasConversion(
                    new ValueConverter<JsonDocument, string>(
                        v => v != null ? v.RootElement.GetRawText() : string.Empty,
                        v => !string.IsNullOrEmpty(v) ? JsonDocument.Parse(v, default) : null))
                .IsRequired(true);

            modelBuilder.Entity<ProviderService>()
               .Property(sps => sps.Price).HasColumnType("decimal(12,2)")
               .IsRequired(true);

            modelBuilder.Entity<ProviderService>()
                .Property(sps => sps.Currency)
                .HasColumnType("varchar(3)")
                .IsRequired(true);

            modelBuilder.Entity<ProviderService>()
                .Property(sps => sps.Duration).HasColumnType("interval")
                .IsRequired(true);
        }
    }
}
