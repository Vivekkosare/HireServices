using HireServices.Common.Inputs;
using HireServices.Common.Types;
using HireServices.Features.Customers.Data;
using HireServices.Features.Customers.Inputs;
using HireServices.Features.Customers.Mutations;
using HireServices.Features.Customers.Queries;
using HireServices.Features.Customers.Resolvers;
using HireServices.Features.Customers.Services;
using HireServices.Features.Customers.Types;
using HireServices.Features.ServiceProviders.Data;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Inputs;
using HireServices.Features.ServiceProviders.Mutations;
using HireServices.Features.ServiceProviders.Query;
using HireServices.Features.ServiceProviders.Services;
using HireServices.Features.ServiceProviders.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.AddServiceDefaults();


builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<CustomerQueryExtension>()
    .AddTypeExtension<ProviderQueryExtension>()

    .AddMutationType<Mutation>()
    .AddTypeExtension<CustomerMutationExtension>()
    .AddTypeExtension<ProviderMutationExtension>()

    .AddType<CustomerType>()
    .AddType<ContactInfoType>()
    .AddType<AddressType>()
    .AddType<InputObjectType<CustomerInput>>()
    .AddType<InputObjectType<ContactInfoInput>>()
    .AddType<InputObjectType<AddressInput>>()
    .AddResolver<CustomerResolvers>()

    //.AddQueryType<ServicesProviderQuery>()
    .AddType<InputObjectType<ProviderInput>>()
    .AddType<InputObjectType<CategoryInput>>()
    .AddType<InputObjectType<ProviderServiceInput>>()
    .AddType<InputObjectType<ProviderReviewInput>>()
    //.AddType<CustomTimeSpanType>()
    .AddType<ServiceType>()
    .AddType<ProviderType>()

    .AddType<CategoryOutput>()
    .AddType<ProviderOutput>()
    .AddType<ProviderReviewOutput>()
    .AddType<ProviderServiceOutput>();




builder.Services.AddDbContext<CustomerDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ProviderDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProviderServicesService, ProviderServicesService>();


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UsePlayground("/graphql", "/playground");
//}

app.MapGraphQL();

app.MapDefaultEndpoints();

app.Run();
