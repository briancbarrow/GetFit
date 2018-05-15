using System;
using System.ComponentModel.DataAnnotations;

namespace getfit
{
    public class Exercise 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Category { get; set; }
        public string Notes { get; set; }
    }

    public enum Type
    {
        Reps,
        Time
    }
}