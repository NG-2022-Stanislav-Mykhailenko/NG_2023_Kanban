using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.Extensions;
using NG_2023_Kanban.DataLayer.Models;
using NG_2023_Kanban.BusinessLayer.Services;

namespace NG_2023_Kanban.Controllers;

public class HomeController : Controller
{
    private readonly UserService _userService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, UserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public IActionResult Index()
    {
        User? currentAccount = HttpContext.Session.GetObject<User>("Account");
        if (currentAccount != null)
        {
            ViewData["Account"] = currentAccount;
            return View();
        }
        return Redirect("/Home/Login");
    }

    public IActionResult Login()
    {
        User? currentAccount = HttpContext.Session.GetObject<User>("Account");
        if (currentAccount != null)
            return Redirect("/Home/Index");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(User user)
    {
        User? currentAccount = HttpContext.Session.GetObject<User>("Account");
        if (currentAccount != null)
            return Redirect("/Home/Index");

        User? account = await _userService.LoginAsync(user);
        if (account != null)
        {
            HttpContext.Session.SetObject("Account", account);
            return Redirect("/Home/Index");
        }
        else
        {
            ViewData["Error"] = "Invalid credentials.";
            return View();
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("Account");
        return Redirect("/Home/Login");
    }

    public IActionResult Register()
    {
        User? currentAccount = HttpContext.Session.GetObject<User>("Account");
        if (currentAccount != null)
            return Redirect("/Home/Index");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        User? currentAccount = HttpContext.Session.GetObject<User>("Account");
        if (currentAccount != null)
            return Redirect("/Home/Index");

        try
        {
            User account = await _userService.RegisterAsync(user);

            HttpContext.Session.SetObject("Account", account);
            return Redirect("/Home/Index");
        }
        catch
        {
            ViewData["Error"] = "This name is already taken.";
            return View();
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
