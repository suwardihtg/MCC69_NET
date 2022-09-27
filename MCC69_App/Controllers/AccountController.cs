using MCC69_App.Models;
using MCC69_App.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MCC69_App.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<User> users = null;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44335/api/");
                // http get
                var responseTask = client.GetAsync("User");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // Get the response
                    var ResultJsonString = result.Content.ReadAsStringAsync();
                    ResultJsonString.Wait();
                    JObject rss = JObject.Parse(ResultJsonString.Result);
                    JArray data = (JArray)rss["data"];
                    users = JsonConvert.DeserializeObject<List<User>>(JsonConvert.SerializeObject(data));
                }
                else
                {
                    users = Enumerable.Empty<User>();
                    ModelState.AddModelError(string.Empty, "Server Error");
                }
            }
            return View(users);
        }
        public IActionResult Login()
        {

            return View();
        }
        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
            string token = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335/api/");
                var postTask = client.PostAsJsonAsync<Login>("auth/Login", login);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultJsonString = result.Content.ReadAsStringAsync();
                    resultJsonString.Wait();
                    JObject rss = JObject.Parse(resultJsonString.Result);
                    JValue tokenObject = (JValue)rss["token"];
                    token = tokenObject.ToString();
                    HttpContext.Session.SetString("token", token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    //return (RedirectToAction("Index", new { token  }));
                    return View("Success");
                }
            }
            return View("Login");
        }
        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
