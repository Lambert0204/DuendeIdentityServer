using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InternalMvc.Models;
using Newtonsoft.Json;
using WeatherMVC.Models;
using InternalMVC.Services;
using IdentityModel.Client;

namespace InternalMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITokenService _tokenService;

    public HomeController(ILogger<HomeController> logger, ITokenService tokenService)
    {
        _logger = logger;
        _tokenService = tokenService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Weather()
    {
        using var client = new HttpClient();

        var token = await _tokenService.GetToken("weatherapi.read");

        client.SetBearerToken(token.AccessToken);

        var result = await client.GetAsync("https://localhost:5445/weatherforecast");

        if(result.IsSuccessStatusCode)
        {
            var model = await result.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<WeatherData>>(model);

            return View(data);
        }

        throw new Exception("Unable to get content");
    }    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
