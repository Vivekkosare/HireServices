using System.Net;

namespace HireServices.Domain.Common
{
    public class ResultResponse<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; set; }
        public string? ErrorMessage { get; }
        public HttpStatusCode StatusCode { get; }

        private ResultResponse(T value, HttpStatusCode statusCode)
        {
            IsSuccess = true;
            Value = value;
            StatusCode = statusCode;
        }

        private ResultResponse(string errorMessage, HttpStatusCode statusCode)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }

        public static ResultResponse<T> Success(T value, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ResultResponse<T>(value, statusCode);
        }

        public static ResultResponse<T> Fail(string errorMessage, HttpStatusCode statusCode)
        {
            return new ResultResponse<T>(errorMessage, statusCode);
        }
    }
}
