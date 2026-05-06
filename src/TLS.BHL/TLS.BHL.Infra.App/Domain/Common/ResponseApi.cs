namespace AEC.ESoft.Infra.App.Domain.Common
{
    public class ApiResponse<T> : ApiResponse
    {
        public T? Data { get; set; }
        public ApiResponse(T data) : base(true, null)
        {
            Data = data;
        }
        public ApiResponse(T data, string message) : base(true, message)
        {
            Data = data;
        }
        public ApiResponse(T data, bool IsSuccessed, string? message = null) : base(IsSuccessed, message)
        {
            Data = data;
        }
        public ApiResponse(T data, int status, string? message = null) : base(status, message)
        {
            Data = data;
        }
    }
    public class ApiResponse
    {
        public ApiResponse(bool IsSuccessed, string? message = null)
        {
            Status = IsSuccessed ? ApiResponseStatus.Success : ApiResponseStatus.Error;
            Message = message;
        }
        public ApiResponse(int status, string? message = null)
        {
            Status = status;
            Message = message;
        }

        public ApiResponse()
        {
        }

        public int Status { get; set; }
        public string? Message { get; set; }

        public static ApiResponse CreateSuccess(string? message = null)
        {
            return new ApiResponse(true, message);
        }

        public static ApiResponse CreateError(string? message = null)
        {
            return new ApiResponse(false, message);
        }

        public static ApiResponse Create(bool IsSuccessed, string? message = null)
        {
            return new ApiResponse(IsSuccessed, message);
        }

        public static ApiResponse Create(int status, string? message = null)
        {
            return new ApiResponse(status, message);
        }

        public static ApiResponse<T> CreateSuccess<T>(T data, string? message = null)
        {
            return new ApiResponse<T>(data, true, message);
        }

        public static ApiResponse<T> CreateError<T>(T data, string? message = null)
        {
            return new ApiResponse<T>(data, false, message);
        }

        public static ApiResponse<T> Create<T>(T data, bool IsSuccessed, string? message = null)
        {
            return new ApiResponse<T>(data, IsSuccessed, message);
        }

        public static ApiResponse<T> Create<T>(T data, int status, string? message = null)
        {
            return new ApiResponse<T>(data, status, message);
        }
    }
}
