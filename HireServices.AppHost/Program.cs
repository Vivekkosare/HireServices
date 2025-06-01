
using Aspire.Hosting;
using Aspire.Hosting.Postgres; // This provides AddPostgres extension method

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("pgsql")
    .WithImage("postgres:16")
    .WithEnvironment("POSTGRES_USER", "postgres")
    .WithEnvironment("POSTGRES_PASSWORD", "Netgear@980")
    .WithHostPort(5432)
    .WithVolume("pgdata", "/var/lib/postgresql/data");

var postgresDb = postgres.AddDatabase("postgres");

builder.AddProject<Projects.HireServices>("hireservices")
    .WithReference(postgresDb);

builder.Build().Run();
