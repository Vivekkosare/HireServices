using HireServices.Domain.Common;
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
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using HireServices.Features.ServiceProviders.GraphQL.Mutations;
using HireServices.Features.ServiceProviders.GraphQL.Query;
using HireServices.Features.ServiceProviders.GraphQL.Types;
using HireServices.Features.ServiceProviders.Services;
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
    //.AddType<ResultResponseType<ProviderOutput>>();
    //.BindRuntimeType(typeof(ResultResponse<>), typeof(ResultResponseType<>));




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
