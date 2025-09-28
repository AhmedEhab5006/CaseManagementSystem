namespace CaseManagementSystemAPI.ResponseHandlers
{
    public class APIResponseHandler<T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }
        public object Errors { get; set; }
        public APIResponseHandler(int statusCode, string message, T data = default, object errors = null) { Status = statusCode; Message = message ?? GetErrorMessageForStatusCode(statusCode); Data = data; Errors = errors; }
        private string? GetErrorMessageForStatusCode(int code) { return code switch { 200 => "Success", 201 => "Created", 302 => "Redirect", 400 => "Bad Request", 401 => "Unauthorized", 403 => "Forbidden", 404 => "Resource not found!", 500 => "Internal Server Error", 502 => "Bad Gateway", 503 => "Service Unavailable", _ => "Unknown Error" }; }
    }
}
