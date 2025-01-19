namespace WTBackend.APIResponses
{
    //Besere Antworten bei Fehlern die an den Client zurück geschickt werden
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ApiResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        // Hilfsmethoden
        public static ApiResponse SuccessResponse(string message)
            => new ApiResponse(true, message);

        public static ApiResponse ErrorResponse(string message)
            => new ApiResponse(false, message);
    }
}
