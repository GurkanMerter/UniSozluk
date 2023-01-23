using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace UniSozluk.Controllers
{
    public class SituationApiController : Controller
    {
        [Authorize(Roles = "Admin,Person")]
        public IActionResult Index()
        {
            var httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);       //json atıyorum
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());
            var request = httpClient.GetAsync("https://localhost:5001/api/AuthController").Result;      //endpointe istek atma
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<AppUser>>(response);

            return View(value);
        }

    }
}
