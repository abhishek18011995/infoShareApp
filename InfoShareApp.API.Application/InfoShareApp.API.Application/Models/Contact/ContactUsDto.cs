using System.ComponentModel.DataAnnotations;

namespace InfoShareApp.API.Application.Models
{
    public class ContactUsDto
    {
        //[Required]
        //[MaxLength(50)]
        //public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
