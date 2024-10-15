using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalisVita.Model
{
    public class User : IdentityUser
    {
       

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public int WorkoutLevel { get; set; }

        public List<UserWorkoutLog> UserWorkoutLogs { get; set; }
    }
}

