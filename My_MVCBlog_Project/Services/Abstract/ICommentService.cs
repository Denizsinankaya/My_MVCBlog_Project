using My_MVCBlog_Project.Entities;
using My_MVCBlog_Project.Models;
using My_MVCBlog_Project.Models.DTO;

namespace My_MVCBlog_Project.Services.Abstract;

public interface ICommentService
{
    ServiceResponse<Comment> RemoveComment(int id);
    ServiceResponse<Comment> UpdateComment(int commentId);
    ServiceResponse<Comment> Find(int? commentId);
    ServiceResponse<Comment> EditCommment(int id, CommentEditViewModel model, HttpContext httpContext);

    //ServiceResponse<Comment> AddComment(AddCommentDTO commentDTO);
}
