using System;
using ARE.Shared.Responses;

namespace ARE.API.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }
}

