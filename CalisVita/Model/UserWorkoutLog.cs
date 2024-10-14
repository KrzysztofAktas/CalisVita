using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalisVita.Model
{
    public class UserWorkoutLog
    {
       
       public int Id { get; set; }

       [Required]
       public DateTime LogDate { get; set; }

       public int Reps { get; set; }

       public User User { get; set; }

       public Workout Workout { get; set; }
        
    }
}
