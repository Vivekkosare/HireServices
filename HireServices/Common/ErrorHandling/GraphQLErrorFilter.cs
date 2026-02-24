using HireServices.Common.Exceptions;

namespace HireServices.Common.ErrorHandling;

/// <summary>
/// Intercepts all GraphQL errors and maps known exceptions to
/// structured GraphQL error responses with consistent error codes.
/// Registered via .AddErrorFilter&lt;GraphQLErrorFilter&gt;() in Program.cs.
/// </summary>
public class GraphQLErrorFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        // Pass through errors that have no underlying exception (e.g. schema/parsing errors)
        if (error.Exception is null)
            return error;

        return error.Exception switch
        {
            Exceptions.ValidationException ex => ErrorBuilder.New()
                .SetMessage(ex.Message)
                .SetCode("VALIDATION_ERROR")
                .SetExtension("errors", ex.Errors)
                .Build(),

            NotFoundException ex => ErrorBuilder.New()
                .SetMessage(ex.Message)
                .SetCode("NOT_FOUND")
                .Build(),

            BusinessRuleException ex => ErrorBuilder.New()
                .SetMessage(ex.Message)
                .SetCode("BUSINESS_RULE_VIOLATION")
                .Build(),

            // Covers manually thrown UnauthorizedException from application code
            UnauthorizedException ex => ErrorBuilder.New()
                .SetMessage(ex.Message)
                .SetCode("UNAUTHORIZED")
                .Build(),

            _ => ErrorBuilder.New()
                .SetMessage("An unexpected error occurred.")
                .SetCode("INTERNAL_ERROR")
                .Build()
        };
    }
}
