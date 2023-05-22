using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AutoMapper;
using NG_2023_Kanban.Models;
using NG_2023_Kanban.DTOs;
using NG_2023_Kanban.BusinessLayer.Models;
using NG_2023_Kanban.BusinessLayer.Services;

namespace NG_2023_Kanban.Controllers;

public class AuthController : Controller
{
    private readonly UserService _userService;
    private readonly ILogger<AuthController> _logger;
    private readonly IMapper _mapper;

    public AuthController(ILogger<AuthController> logger, UserService userService, IMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _mapper = mapper;
    }

    public override void OnActionExecuting(ActionExecutingContext actionContext)
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount != null)
            actionContext.Result = Redirect("Home/Index");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserDto user)
    {
        var model = _mapper.Map<UserModel>(user);

        var account = _mapper.Map<UserDto>(await _userService.LoginAsync(model));

        if (account != null)
        {
            HttpContext.Session.SetInt32("Account", account.Id);
            return Redirect("/Home/Index");
        }
        else
        {
            ViewData["Error"] = "Invalid credentials.";
            return View();
        }
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserDto user)
    {
        try
        {
            var model = _mapper.Map<UserModel>(user);
            var account = _mapper.Map<UserDto>(await _userService.RegisterAsync(model));

            HttpContext.Session.SetInt32("Account", account.Id);
            return Redirect("/Home/Index");
        }
        catch
        {
            ViewData["Error"] = "This name is already taken.";
            return View();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
