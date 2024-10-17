using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalisVita.Model
{
    public class User : IdentityUser
    {

        [Required]
        public int WorkoutLevel { get; set; }

        public List<UserWorkoutLog> UserWorkoutLogs { get; set; }
    }
}

