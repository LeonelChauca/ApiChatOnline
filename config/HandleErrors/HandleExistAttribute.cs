using System;

namespace ApiChatOnline.config.HandleErrors;

public class HandleExistAttribute : HandleErrorBase
{
    public HandleExistAttribute(string message)
        : base(400, $"{message}") { }
}
