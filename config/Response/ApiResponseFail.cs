using System;

namespace ApiChatOnline.config.Response;

public class ApiResponseFail<T> : ApiResponse
{
    public T? Errors { get; set; }

    public ApiResponseFail(string message, T? errors)
        : base(false, message)
    {
        Errors = errors;
    }
}
