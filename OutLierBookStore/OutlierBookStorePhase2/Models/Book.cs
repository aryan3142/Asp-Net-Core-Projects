using Microsoft.AspNetCore.Http;
using OutlierBookStorePhase2.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Choose the cover photo of your book")]
        [Required(ErrorMessage = "Please upload the cover image for your book")]
        [NotMapped]
        public IFormFile CoverPhoto { get; set; }
        public string CoverPhotoUrl { get; set; }

        [Display(Name = "Choose the gallery images for your book")]
        [Required(ErrorMessage ="Please upload gallery images for your book")]
        [NotMapped]
        public IFormFileCollection GalleryFiles { get; set; }
        public List<Gallery> Gallery { get; set; }

        [Display(Name = "Upload Pdf of your book")]
        [Required(ErrorMessage = "Please upload the pdf of your book")]
        [NotMapped]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

    }
}
