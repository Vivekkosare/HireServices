using HireServices.Domain.Inputs;
using HireServices.Domain.Types;
using HireServices.Features.Customers.Data;
using HireServices.Features.Customers.GraphQL.Inputs;
using HireServices.Features.Customers.GraphQL.Mutations;
using HireServices.Features.Customers.GraphQL.Queries;
using HireServices.Features.Customers.GraphQL.Resolvers;
using HireServices.Features.Customers.GraphQL.Types;
using HireServices.Features.Customers.Services;
using HireServices.Features.ServiceProviders.Data;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using HireServices.Features.ServiceProviders.GraphQL.Mutations;
using HireServices.Features.ServiceProviders.GraphQL.Query;
using HireServices.Features.ServiceProviders.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.AddServiceDefaults();


builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<CustomerQuery>()
    .AddType<ServicesProviderQuery>()

    .AddMutationType<Mutation>()
    .AddType<CustomerMutation>()
    .AddType<ServicesProviderMutation>()

    .AddType<CustomerType>()
    .AddType<ContactInfoType>()
    .AddType<AddressType>()
    .AddType<InputObjectType<CustomerInput>>()
    .AddType<InputObjectType<ContactInfoInput>>()
    .AddType<InputObjectType<AddressInput>>()
    .AddResolver<CustomerResolvers>()

    //.AddQueryType<ServicesProviderQuery>()
    .AddType<InputObjectType<ServicesProviderInput>>()
    .AddType<InputObjectType<CategoryInput>>()
    .AddType<InputObjectType<ServiceInput>>();


builder.Services.AddDbContext<CustomerDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ServicesProviderDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IServicesProviderService, ServicesProviderService>();


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UsePlayground("/graphql", "/playground");
//}

app.MapGraphQL();

app.MapDefaultEndpoints();

app.Run();
