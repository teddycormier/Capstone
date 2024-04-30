namespace MyMvcApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public class TwilioController : Controller
{
    [HttpPost]
    public ActionResult SendMessage(string phoneNumber, string messageBody)
    {
        var accountSid = "AC2c0b9ced7ec78761a795181c11261a38";
        var authToken = "a1dbeabfce9a82069bf416fcee0fc6b3";
        TwilioClient.Init(accountSid, authToken);

        var messageOptions = new CreateMessageOptions(new PhoneNumber(phoneNumber))
        {
            From = new PhoneNumber("+18447402377"), // My Twilio phone number
            Body = messageBody
        };

        var message = MessageResource.Create(messageOptions);
        Console.WriteLine(message.Body);

        return Content("Message sent successfully!");
    }
}
