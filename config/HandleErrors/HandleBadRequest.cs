using System;

namespace ApiChatOnline.config.HandleErrors;

public class HandleBadRequest : HandleErrorBase
{
    public HandleBadRequest(string message)
        : base(400, message) { }
}
