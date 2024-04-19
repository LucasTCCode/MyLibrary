using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? FinishedDate { get; set; }
    }
}
