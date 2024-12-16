using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
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
                .HasMany(p => p.ServiceCategories)
                .WithOne()
                .HasForeignKey("ProviderId");


            modelBuilder.Entity<ProviderService>()
                .Property(sps => sps.Id)
                .ValueGeneratedOnAdd();

            

            modelBuilder.Entity<ProviderService>()
                .HasOne<Provider>()
                .WithMany()
                .HasForeignKey(sps => sps.ServiceProviderId)
                .IsRequired(true);

            modelBuilder.Entity<ProviderService>()
                .Property(sps => sps.ServiceProviderId).IsRequired(true);

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
               .Property(sps => sps.Price).HasColumnType("money")
               .IsRequired(true);

            modelBuilder.Entity<ProviderService>()
                .Property(sps => sps.Duration).HasColumnType("interval")
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
