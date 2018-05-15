using System;
using System.ComponentModel.DataAnnotations;

namespace getfit
{
    public class User 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}