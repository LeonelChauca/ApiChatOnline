using ApiChatOnline.config.Response;
using Microsoft.AspNetCore.Mvc;

namespace ApiChatOnline.Extensions;

public static class ResponseExtension
{
    public static OkObjectResult ToOkResponse<T>(this T data, string message)
    {
        var response = new ApiResponseOk<T>(message, data);
        return new OkObjectResult(response);
    }

    public static CreatedAtActionResult ToCreatedResponse<T>(
        this T data,
        string message,
        string actionName,
        object routeValues
    )
    {
        var response = new ApiResponseOk<T>(message, data);

        return new CreatedAtActionResult(actionName, null, routeValues, response);
    }
}
