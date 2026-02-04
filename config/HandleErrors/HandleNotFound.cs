using System;

namespace ApiChatOnline.config.HandleErrors;

public class HandleNotFound : HandleErrorBase
{
    public HandleNotFound(string message)
        : base(404, message) { }
}
