using HireServices.Common.Exceptions;

namespace HireServices.Common.ErrorHandling;

public class GraphQLErrorFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
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

            _ => ErrorBuilder.New()
                .SetMessage("An unexpected error occurred.")
                .SetCode("INTERNAL_ERROR")
                .Build()
        };
    }
}
