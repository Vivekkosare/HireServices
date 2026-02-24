using FluentValidation;
using HireServices.Common.Behaviors;
using HireServices.Common.ErrorHandling;
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
using HireServices.Features.ServiceProviders.Queries;
using HireServices.Features.ServiceProviders.Services;
using HireServices.Features.ServiceProviders.Types;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.AddServiceDefaults();

// ── Firebase Authentication ───────────────────────────────────────────────────
// Firebase tokens are standard RS256 JWTs. ASP.NET Core's JwtBearer middleware
// fetches Firebase's public keys automatically from the Authority URL and
// validates every incoming Bearer token without any service-account credentials.
var firebaseProjectId = builder.Configuration["Firebase:ProjectId"];

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Google's token authority for this Firebase project
        options.Authority = $"https://securetoken.google.com/{firebaseProjectId}";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"https://securetoken.google.com/{firebaseProjectId}",

            ValidateAudience = true,
            ValidAudience = firebaseProjectId, // Must match your Firebase project ID

            ValidateLifetime = true
        };
    });

// Required for [Authorize] to work in both ASP.NET Core and HotChocolate
builder.Services.AddAuthorization();


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
    .AddType<ProviderServiceOutput>()
    .AddErrorFilter<GraphQLErrorFilter>()
    // Wires HotChocolate's [Authorize] directive to ASP.NET Core's auth pipeline
    .AddAuthorization();




builder.Services.AddDbContext<CustomerDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ProviderDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProviderServicesService, ProviderServicesService>();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options =>
{
    // options.AddPolicy("AllowSpecificOrigins", policy =>
    // {
    //     policy.WithOrigins(allowedOrigins)
    //           .AllowAnyHeader()
    //           .AllowAnyMethod();
    // });
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// app.UseCors("AllowSpecificOrigins");
app.UseCors("AllowAll");

// Middleware order matters: Authentication → Authorization → GraphQL
// UseAuthentication reads the Bearer token and populates HttpContext.User.
// UseAuthorization enforces [Authorize] directives on the GraphQL resolvers.
app.UseAuthentication();
app.UseAuthorization();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UsePlayground("/graphql", "/playground");
//}

app.MapGraphQL();

app.MapDefaultEndpoints();

app.Run();
