using System;
using System.ComponentModel.DataAnnotations;

namespace getfit
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}