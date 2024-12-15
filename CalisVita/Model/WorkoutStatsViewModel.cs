using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalisVita.Model
{
    public class WorkoutStatsViewModel
    {
        public int Id { get; set; }
        public int TotalWorkouts { get; set; }
        public int WorkoutStreak { get; set; }
        

    }
}
