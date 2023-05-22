using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using NG_2023_Kanban.Models;
using NG_2023_Kanban.DTOs;
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

    public override async void OnActionExecuting(ActionExecutingContext actionContext)
    {
        var currentAccount = HttpContext.Session.GetInt32("Account");
        if (currentAccount.HasValue)
        {
            var userModel = await _userService.GetAsync(currentAccount.Value);
            bool isAdmin = await _userService.CheckAdminAsync(userModel.Id);
            if (!isAdmin)
            {
                actionContext.Result = StatusCode(403);
                return;
            }
            ViewData["Account"] = _mapper.Map<UserDto>(userModel);;
            ViewData["isAdmin"] = true;
        }
        else
            actionContext.Result = Redirect("/Auth/Login");
    }

    public async Task<IActionResult> Boards()
    {
        ViewData["Boards"] = _mapper.Map<ICollection<BoardDto>>(await _boardService.GetAllAsync());
        return View();
    }

    public async Task<IActionResult> Users()
    {
        ViewData["Users"] = _mapper.Map<ICollection<UserDto>>(await _userService.GetAllAsync());
        return View();
    }

    public async Task<IActionResult> EditUser(int id)
    {
        ViewData["EditedAccount"] = _mapper.Map<UserDto>(await _userService.GetAsync(id));
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EditUser(int id, UserDto user)
    {
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

    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDto user)
    {
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

    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userService.DeleteAsync(id);
        return Redirect("/Admin/Users");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
