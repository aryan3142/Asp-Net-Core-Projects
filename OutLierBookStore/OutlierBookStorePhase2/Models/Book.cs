using OutlierBookStorePhase2.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
       [StringLength(100,MinimumLength = 5)]
       [Required(ErrorMessage ="Please enter the title of the book")]
      // [MyCustomValidation(text = "MVC")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter the name of the Author")]
        public string Author { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the Total number of pages")]
        public int? TotalPages { get; set; }
        public int LanguageId { get; set; }
        public string Category { get; set; }
        public Language Language { get; set; }
    }
}
