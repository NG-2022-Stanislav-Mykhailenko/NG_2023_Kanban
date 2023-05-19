using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using NG_2023_Kanban.Models;
using NG_2023_Kanban.DTOs;
using NG_2023_Kanban.Enums;
using NG_2023_Kanban.BusinessLayer.Models;
using NG_2023_Kanban.BusinessLayer.Services;

namespace NG_2023_Kanban.Controllers;

public class AdminController : Controller
{
    private readonly UserService _userService;
    private readonly BoardService _boardService;
    private readonly ILogger<AdminController> _logger;
    private readonly IMapper _mapper;

    public AdminController(ILogger<AdminController> logger, UserService userService, BoardService boardService, IMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _boardService = boardService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Boards()
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount.HasValue)
        {
            var account = _mapper.Map<UserDto>(await _userService.GetAsync(currentAccount.Value));
            if (account.Role < (int)Roles.Administrator)
                return StatusCode(StatusCodes.Status403Forbidden);
            ViewData["Account"] = account;
            ViewData["Boards"] = _mapper.Map<ICollection<BoardDto>>(await _boardService.GetAllAsync());
            return View();
        }
        return Redirect("/Auth/Login");
    }

    public async Task<IActionResult> Users()
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount.HasValue)
        {
            var account = _mapper.Map<UserDto>(await _userService.GetAsync(currentAccount.Value));
            if (account.Role < (int)Roles.Administrator)
                return StatusCode(StatusCodes.Status403Forbidden);
            ViewData["Account"] = account;
            ViewData["Users"] = _mapper.Map<ICollection<UserDto>>(await _userService.GetAllAsync());
            return View();
        }
        return Redirect("/Auth/Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
