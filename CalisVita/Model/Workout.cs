using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalisVita.Model
{
    public class Workout
    {
        
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string WorkoutName { get; set; }

        [MaxLength(500)]
        public string WorkoutInfo { get; set; }

        [Required]
        [MaxLength(50)]
        public string WorkoutType { get; set; }

        [Required]
        public int WorkoutLevel { get; set; }

        public List<UserWorkoutLog> UserWorkoutLogs { get; set; }
    }

}
