namespace Domain.ExceptionHandling
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public Error Errors { get; set; }
        public int StatusCode { get; set; }

        public ResponseDto(T data, int statusCode = 200, string message = "Request processed successfully.")
        {
            Success = true;
            Data = data;
            Message = message;
            Errors = null;
            StatusCode = statusCode;
        }

        public ResponseDto(string message, Error errors, int statusCode = 500)
        {
            Success = false;
            Data = default;
            Message = message;
            Errors = errors;
            StatusCode = statusCode;
        }
    }
    public class Error
    {
        public string ErrorLabel { get; set; }
        public string ErrorMessage { get; set; }
    }
}
