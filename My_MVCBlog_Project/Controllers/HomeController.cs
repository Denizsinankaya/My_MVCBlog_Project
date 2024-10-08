using Microsoft.AspNetCore.Mvc;
using My_MVCBlog_Project.Core;
using My_MVCBlog_Project.Entities;
using My_MVCBlog_Project.Models;
using My_MVCBlog_Project.Models.DTO;
using My_MVCBlog_Project.Services;
using My_MVCBlog_Project.Services.Abstract;
using System.Diagnostics;

namespace My_MVCBlog_Project.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly INoteService _noteService;
   

    public HomeController(ILogger<HomeController> logger,INoteService noteService/*, ICommentService commentService*/)
    {
        _noteService = noteService;
        _logger = logger;
    }

    public IActionResult Index(int? categoryId,string mode)
    {
        if (categoryId == null && string.IsNullOrEmpty(mode))
        {
            return View(_noteService.List(null, null).Data);
        }
        else
        {
            return View(_noteService.List(categoryId, mode).Data);
        }
    }
    public IActionResult GetNoteComments(int noteId)
    {
        ServiceResponse<Note> result = _noteService.Find(noteId);
        AddCommentDTO comment = new AddCommentDTO();
        comment.NoteId = noteId;
        MyViewModel model = new()
        {
            CommentDTO = comment,
            Note = result.Data,
        };
        if(result.Data == null)
        {
            return NotFound();
        }
        return View(model);
    }

    //[HttpPost]
    //public IActionResult CreateComment(AddCommentDTO commentDTO)
    //{
    //    int? userId = HttpContext.Session.GetInt32(Constants.UserId);
    //    commentDTO.UserId = userId;
    //    var result = _commentService.AddComment(commentDTO);
    //    if(result.Data == null)
    //    {
    //        return NotFound();
    //    }
    //    return RedirectToAction($"/Home/GetNoteComments/{commentDTO.NoteId}");

    //}

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
