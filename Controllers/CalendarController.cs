
// using Microsoft.AspNetCore.Mvc;
// using System.Net;
// using System.Net.Http;

// public class CalendarController : Controller
// {
//     [HttpGet]
//     public async Task<HttpResponseMessage> GetCalendar(DateTime startTime, DateTime endTime)
//     {
//         string url = $"https://calendar22.p.rapidapi.com/v1/calendars/7faec8c9-7202-4be5-9fc4-0de4e0d31d5f/events?startTime={startTime:yyyy-MM-ddTHH:mm:ssZ}&endTime={endTime:yyyy-MM-ddTHH:mm:ssZ}";

//         using (HttpClient client = new HttpClient())
//         {
//             client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "7091effc2emshfa536272507b037p129d0djsn67dea0cf8dea");
//             client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "calendar22.p.rapidapi.com");

//             HttpResponseMessage response = await client.GetAsync(url);

//             if (response.IsSuccessStatusCode)
//             {
//                 return response;
//             }
//             else
//             {
//                 var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
//                 {
//                     Content = new StringContent($"Failed to fetch calendar: {response.StatusCode}")
//                 };
//                 return errorResponse;
//             }
//         }
//     }
// }
