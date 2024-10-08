using My_MVCBlog_Project.Entities;
using System.ComponentModel.DataAnnotations;

namespace My_MVCBlog_Project.Models;

public class CategoryViewModel
{
    [Required, StringLength(40), Display(Name = "Kategori Adı")]
    public string Name { get; set; }

    [StringLength(160), Display(Description = "Açıklama")]
    public string Description { get; set; }

}
