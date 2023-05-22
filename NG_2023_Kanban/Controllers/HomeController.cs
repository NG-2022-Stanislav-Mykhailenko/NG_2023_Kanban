using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AutoMapper;
using NG_2023_Kanban.Models;
using NG_2023_Kanban.DTOs;
using NG_2023_Kanban.BusinessLayer.Models;
using NG_2023_Kanban.BusinessLayer.Services;

namespace NG_2023_Kanban.Controllers;

public class HomeController : Controller
{
    private readonly UserService _userService;
    private readonly ILogger<HomeController> _logger;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, UserService userService, IMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _mapper = mapper;
    }

    public override async void OnActionExecuting(ActionExecutingContext actionContext)
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount.HasValue)
        {
            var userModel = await _userService.GetAsync(currentAccount.Value);
            ViewData["Account"] = _mapper.Map<UserDto>(userModel);
            ViewData["isAdmin"] = await _userService.CheckAdminAsync(userModel.Id);
        }
        else
            actionContext.Result = Redirect("/Auth/Login");
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("Account");
        return Redirect("/Auth/Login");
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
