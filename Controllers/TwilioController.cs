namespace MyMvcApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public class TwilioController : Controller
{
    private readonly IConfiguration _configuration;

    public TwilioController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public ActionResult SendMessage(string phoneNumber, string messageBody)
    {
        var accountSid = _configuration["Twilio:AccountSid"];
        var authToken = _configuration["Twilio:AuthToken"];
        var twilioPhoneNumber = _configuration["Twilio:PhoneNumber"];
        TwilioClient.Init(accountSid, authToken);

        var messageOptions = new CreateMessageOptions(new PhoneNumber(phoneNumber))
        {
            From = new PhoneNumber(twilioPhoneNumber), // My Twilio phone number
            Body = messageBody
        };

        var message = MessageResource.Create(messageOptions);
        Console.WriteLine(message.Body);

        return Content("Message sent successfully!");
    }
}