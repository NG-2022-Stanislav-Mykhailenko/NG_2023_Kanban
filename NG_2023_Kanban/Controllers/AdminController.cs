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

    public async Task<IActionResult> EditUser(int id)
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount.HasValue)
        {
            var account = _mapper.Map<UserDto>(await _userService.GetAsync(currentAccount.Value));
            if (account.Role < (int)Roles.Administrator)
                return StatusCode(StatusCodes.Status403Forbidden);
            ViewData["Account"] = account;
            ViewData["EditedAccount"] = _mapper.Map<UserDto>(await _userService.GetAsync(id));
            return View();
        }
        return Redirect("/Auth/Login");
    }

    [HttpPost]
    public async Task<IActionResult> EditUser(int id, UserDto user)
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount.HasValue)
        {
            var account = _mapper.Map<UserDto>(await _userService.GetAsync(currentAccount.Value));
            if (account.Role < (int)Roles.Administrator)
                return StatusCode(StatusCodes.Status403Forbidden);
            ViewData["Account"] = account;
            ViewData["EditedAccount"] = _mapper.Map<UserDto>(await _userService.GetAsync(id));
            //try
            //{
                user.Id = id;
                var model = _mapper.Map<UserModel>(user);
                await _userService.UpdateAsync(id, model);
                return Redirect("/Admin/Users");
            //}
            //catch
            //{
            //    ViewData["Error"] = "This name is already taken.";
            //    return View();
            //}
        }
        return Redirect("/Auth/Login");
    }

    public async Task<IActionResult> CreateUser()
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount.HasValue)
        {
            var account = _mapper.Map<UserDto>(await _userService.GetAsync(currentAccount.Value));
            if (account.Role < (int)Roles.Administrator)
                return StatusCode(StatusCodes.Status403Forbidden);
            ViewData["Account"] = account;
            return View();
        }
        return Redirect("/Auth/Login");
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDto user)
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount.HasValue)
        {
            var account = _mapper.Map<UserDto>(await _userService.GetAsync(currentAccount.Value));
            if (account.Role < (int)Roles.Administrator)
                return StatusCode(StatusCodes.Status403Forbidden);
            ViewData["Account"] = account;
            try
            {
                var model = _mapper.Map<UserModel>(user);
                await _userService.RegisterAsync(model);
                return Redirect("/Admin/Users");
            }
            catch
            {
                ViewData["Error"] = "This name is already taken.";
                return View();
            }
        }
        return Redirect("/Auth/Login");
    }

    public async Task<IActionResult> DeleteUser(int id)
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount.HasValue)
        {
            var account = _mapper.Map<UserDto>(await _userService.GetAsync(currentAccount.Value));
            if (account.Role < (int)Roles.Administrator)
                return StatusCode(StatusCodes.Status403Forbidden);
            await _userService.DeleteAsync(id);
            return Redirect("/Admin/Users");
        }
        return Redirect("/Auth/Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
