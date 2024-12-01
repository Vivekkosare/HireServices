using HireServices.Domain.Inputs;
using HireServices.Domain.Types;
using HireServices.Features.Customers.Data;
using HireServices.Features.Customers.GraphQL.Inputs;
using HireServices.Features.Customers.GraphQL.Mutations;
using HireServices.Features.Customers.GraphQL.Queries;
using HireServices.Features.Customers.GraphQL.Resolvers;
using HireServices.Features.Customers.GraphQL.Types;
using HireServices.Features.Customers.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.AddServiceDefaults();


builder.Services.AddGraphQLServer()
    .AddQueryType<CustomerQuery>()
    .AddMutationType<CustomerMutation>()
    .AddType<CustomerType>()
    .AddType<ContactInfoType>()
    .AddType<AddressType>()
    .AddType<InputObjectType<CustomerInput>>()
    .AddType<InputObjectType<ContactInfoInput>>()
    .AddType<InputObjectType<AddressInput>>()
    .AddResolver<CustomerResolvers>();

builder.Services.AddDbContext<CustomerDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerService, CustomerService>();


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UsePlayground("/graphql", "/playground");
//}

app.MapGraphQL();

app.MapDefaultEndpoints();

app.Run();
