namespace HireServices.Common.Exceptions;

/// <summary>
/// Thrown when a request is made without a valid Firebase token
/// or the token does not have the required claims/roles.
/// </summary>
public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message = "You are not authorized to perform this action.")
        : base(message)
    {
    }
}
