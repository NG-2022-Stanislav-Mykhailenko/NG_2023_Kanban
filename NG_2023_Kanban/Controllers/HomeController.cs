using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<IActionResult> Index()
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount.HasValue)
        {
            ViewData["Account"] = _mapper.Map<UserDto>(await _userService.GetAsync(currentAccount.Value));
            return View();
        }
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
