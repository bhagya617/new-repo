using System;
using System.ComponentModel.DataAnnotations;

namespace Movie_MVC.Models
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }

        [Required]
        public string Moviename { get; set; }

        [Required]
        public DateTime DateofRelease { get; set; }
    }
}