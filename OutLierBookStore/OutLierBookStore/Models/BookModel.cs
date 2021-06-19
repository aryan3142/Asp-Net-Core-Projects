using OutLierBookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutLierBookStore.Context
{
    public class BookModel
    {

        public int Id { get; set; }
        [StringLength(100,MinimumLength = 5)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int LangaugeId { get; set; }

        [Required(ErrorMessage = "Please enter the Total number of pages")]
        public int? TotalPages { get; set; }

        public Language Language { get; set; }
    }
}
