var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HireServices>("hireservices");

builder.Build().Run();
