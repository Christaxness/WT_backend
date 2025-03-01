namespace WTBackend.APIResponses
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ApiResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static ApiResponse SuccessResponse(string message)
            => new ApiResponse(true, message);

        public static ApiResponse ErrorResponse(string message)
            => new ApiResponse(false, message);

        public static ApiResponse ErrorResponse(string message, Exception ex)
            => new ApiResponse(false, $"{message} Error: {ex.Message}");
    }
}
