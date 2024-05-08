using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Web.ViewModels
{
    public class BookVM
    {
        public Book? Book { get; set; } = null!;

        [ValidateNever]
        public IEnumerable<SelectListItem>? BookList { get; set; }
    }
}
