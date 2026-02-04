using System;

namespace ApiChatOnline.config.HandleErrors;

public abstract class HandleErrorBase : Exception
{
    public int Status { get; set; }

    protected HandleErrorBase(int status, string message)
        : base(message)
    {
        Status = status;
    }
}
