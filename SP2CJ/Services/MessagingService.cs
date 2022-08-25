using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SP2CJ.Services;

public class MessagingService
{
    public void sendMessage(string body)
    {
        var accountSid = "AC4949c571478ab07236118a95edc92a7a";
        var authToken = "9d4d7f932ec590d6f7cfdf7a606a2891";
        TwilioClient.Init(accountSid, authToken);

        var messageOptions = new CreateMessageOptions(
            new PhoneNumber("+628999962828"));
        messageOptions.MessagingServiceSid = "MG8f80ddd7ee48b0ed1f6615955487d41f";
        messageOptions.Body = body;

        var message = MessageResource.Create(messageOptions);
    }
}