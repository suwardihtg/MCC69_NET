using MCC69_App.Models;
using MCC69_App.Repositories.Data;
using MCC69_App.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCC69_App.Controllers
{
    public class RegionController : BaseController<Regions,RegionRepository>
    {
        public RegionController(RegionRepository regionRepository): base(regionRepository)
        {

        }
        
        public IActionResult Index()
        {
            return View();
        }

        /*public async Task<IActionResult> Index()
        {
            Json<Regions> RegionList = new Json<Regions>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44335/api/Region"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    RegionList = JsonConvert.DeserializeObject<Json<Regions>>(apiResponse);
                }
            }
            return View(RegionList.data);

        }*/
        /*  HTTPClientGenerics<Regions> HttpApiRegion = new HTTPClientGenerics<Regions>("Region");
          public IActionResult Index()
          {
              IEnumerable<Regions> regions = null;
              string token = HttpContext.Session.GetString("token");
              regions = HttpApiRegion.Get(token);
              return View(regions);
          }*/

    }
}
