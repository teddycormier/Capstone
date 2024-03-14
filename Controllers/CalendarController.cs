using Capstone.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class CalendarController : Controller
    {
        private string clientId = "651787363319-n581m7rneppaa1n9snc3a3l3ua9cbrvc.apps.googleusercontent.com";
        private string clientSecret = "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";
        private string redirectUri;

        public CalendarController()
        {
            redirectUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Calendar/OAuthCallback";
        }

        public ActionResult Authorize()
        {
            string[] scopes = { CalendarService.Scope.CalendarReadonly };

            var authFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                Scopes = scopes,
                DataStore = new FileDataStore("Calendar.Api.Auth.Store")
            });

            var authRequestUrl = authFlow.CreateAuthorizationCodeRequest(redirectUri);
            string authUrl = authRequestUrl.Build().ToString();

            return Redirect(authUrl);
        }

        public ActionResult OAuthCallback(string code)
        {
            var authCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                Scopes = new[] { CalendarService.Scope.CalendarReadonly },
                DataStore = new FileDataStore("Calendar.Api.Auth.Store")
            });

            TokenResponse tokenResponse = authCodeFlow.ExchangeCodeForTokenAsync("user", code, redirectUri, CancellationToken.None).Result;

            var credential = new UserCredential(authCodeFlow, "user", tokenResponse);

            var service = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            });

            var calendarListRequest = service.CalendarList.List();
            calendarListRequest.MaxResults = 10;
            var calendars = calendarListRequest.Execute().Items;

            List<CalendarEventViewModel> allEvents = new List<CalendarEventViewModel>();
            foreach (var calendar in calendars)
            {
                var eventsRequest = service.Events.List(calendar.Id);
                eventsRequest.TimeMinDateTimeOffset = DateTime.Now;
                eventsRequest.ShowDeleted = false;
                eventsRequest.SingleEvents = true;
                eventsRequest.MaxResults = 10;
                var events = eventsRequest.Execute().Items;
                foreach (var evt in events)
                {
                    allEvents.Add(new CalendarEventViewModel
                    {
                        Summary = evt.Summary,
                        Start = evt.Start?.DateTimeDateTimeOffset,
                        End = evt.End?.DateTimeDateTimeOffset
                    });
                }
            }

            return View(allEvents);
        }
    }
}
