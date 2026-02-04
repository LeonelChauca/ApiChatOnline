using System;

namespace ApiChatOnline.config.Response;

public class ApiResponseOk<T> : ApiResponse
{
    public T? Data { get; set; }

    public ApiResponseOk(string message, T? data)
        : base(true, message)
    {
        Data = data;
    }
}
