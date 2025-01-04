using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Movie
    {
        [Key] 
        public int Mid { get; set; }
        public string Moviename { get; set; }
        public DateTime DateofRelease { get; set; }
    }
}