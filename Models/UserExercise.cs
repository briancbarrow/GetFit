using System;
using System.ComponentModel.DataAnnotations;

namespace getfit
{
    public class UserExercise
    {
        [Key]
        public int UserExerciseId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string ExerciseName { get; set; }
        [Required]
        public double Weight {get; set;}
        public int Reps {get; set;}
        public double Distance {get; set;}
        public TimeSpan Time {get; set;}
        public string Comment {get; set;}
        public int UserId {get; set;}
        //Need to add Distance Unit
    }
}