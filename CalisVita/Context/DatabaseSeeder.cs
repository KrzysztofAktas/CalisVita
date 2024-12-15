using System;
using System.Collections.Generic;
using System.Linq;
using CalisVita.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CalisVita.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

       

        public DatabaseSeeder(DatabaseContext context, UserManager<User> usermanager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = usermanager;
            _roleManager = roleManager;

        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");


            }
            if (!_context.Workouts.Any())
            {
                var workouts = GetWorkouts();
                _context.Workouts.AddRange(workouts);
                await _context!.SaveChangesAsync();
            }

        }
        private List<Workout> GetWorkouts()
        {
            return
                [
                // Chest Workouts
            new Workout
            {
                WorkoutName = "Wall Push-Ups",
                WorkoutInfo = "Stand about an arm's length from a wall, place your hands on the wall at shoulder height. Lower your chest towards the wall, keeping your body straight, and then push back up.",
                WorkoutType = "Chest",
                WorkoutLevel = 0
            },
            new Workout
            {
                WorkoutName = "Knee Push-Ups",
                WorkoutInfo = "Start in a high plank position with your knees on the ground. Lower your chest to the floor, then push back up. Keep your body in a straight line from your knees to your shoulders.",
                WorkoutType = "Chest",
                WorkoutLevel = 1
            },
            new Workout
            {
                WorkoutName = "Incline Push-Ups",
                WorkoutInfo = "Place your hands on a raised surface like a bench or chair. Lower your chest towards the surface, keeping your body in a straight line, then push back up.",
                WorkoutType = "Chest",
                WorkoutLevel = 2
            },
            new Workout
            {
                WorkoutName = "Regular Push-Ups",
                WorkoutInfo = "Start in a high plank position. Lower your chest to the floor, then push back up, keeping your body in a straight line from your head to your feet.",
                WorkoutType = "Chest",
                WorkoutLevel = 3
            },
            new Workout
            {
                WorkoutName = "Decline Push-Ups",
                WorkoutInfo = "Place your feet on a raised surface like a chair or bench and your hands on the floor. Lower your chest to the floor, then push back up.",
                WorkoutType = "Chest",
                WorkoutLevel = 4
            },
            new Workout
            {
                WorkoutName = "Clapping Push-Ups",
                WorkoutInfo = "Start in a regular push-up position. Lower yourself and explode up, clapping your hands before catching yourself in the push-up position again.",
                WorkoutType = "Chest",
                WorkoutLevel = 5
            },

            // Legs Workouts
            new Workout
            {
                WorkoutName = "Wall Sit",
                WorkoutInfo = "Lean your back against a wall, slide down until your knees are at a 90-degree angle, and hold the position.",
                WorkoutType = "Legs",
                WorkoutLevel = 0
            },
            new Workout
            {
                WorkoutName = "Bodyweight Squats",
                WorkoutInfo = "Stand with your feet shoulder-width apart, lower your hips as if sitting back into a chair, keeping your chest up and knees over your toes, then stand back up.",
                WorkoutType = "Legs",
                WorkoutLevel = 1
            },
            new Workout
            {
                WorkoutName = "Lunges",
                WorkoutInfo = "Step forward with one leg, lower your hips until both knees are bent at 90-degree angles. Push back to the starting position and switch legs.",
                WorkoutType = "Legs",
                WorkoutLevel = 2
            },
            new Workout
            {
                WorkoutName = "Bulgarian Split Squats",
                WorkoutInfo = "Stand a couple of feet in front of a bench or chair, place one foot on the bench behind you. Lower your hips, then push back up, focusing on your front leg.",
                WorkoutType = "Legs",
                WorkoutLevel = 3
            },
            new Workout
            {
                WorkoutName = "Pistol Squats (Assisted)",
                WorkoutInfo = "Stand on one leg, slowly lower your hips while extending the other leg forward. You can hold onto a chair or wall for balance. Push back up using the leg on the ground.",
                WorkoutType = "Legs",
                WorkoutLevel = 4
            },
            new Workout
            {
                WorkoutName = "Jump Squats",
                WorkoutInfo = "Lower into a squat and then jump as high as you can, landing softly and returning to the squat position. Focus on explosive power.",
                WorkoutType = "Legs",
                WorkoutLevel = 5
            },

            // Core Workouts
            new Workout
            {
                WorkoutName = "Plank (Knee)",
                WorkoutInfo = "Start on your elbows and knees, keeping your body straight from shoulders to knees. Hold the position for as long as possible.",
                WorkoutType = "Core",
                WorkoutLevel = 0
            },
            new Workout
            {
                WorkoutName = "Regular Plank",
                WorkoutInfo = "Start on your elbows and toes, keeping your body in a straight line from your head to your heels. Hold the position.",
                WorkoutType = "Core",
                WorkoutLevel = 1
            },
            new Workout
            {
                WorkoutName = "Leg Raises",
                WorkoutInfo = "Lie flat on your back with your legs straight. Lift your legs up towards the ceiling while keeping them straight, then lower them back down without touching the floor.",
                WorkoutType = "Core",
                WorkoutLevel = 2
            },
            new Workout
            {
                WorkoutName = "Mountain Climbers",
                WorkoutInfo = "Start in a high plank position. Drive one knee towards your chest, then switch legs quickly as if running in place.",
                WorkoutType = "Core",
                WorkoutLevel = 3
            },
            new Workout
            {
                WorkoutName = "V-Ups",
                WorkoutInfo = "Lie on your back with your arms extended overhead. Simultaneously lift your legs and torso to form a 'V' shape, then lower back down.",
                WorkoutType = "Core",
                WorkoutLevel = 4
            },
            new Workout
            {
                WorkoutName = "Dragon Flags",
                WorkoutInfo = "Lie on a bench and grab the sides for support. Slowly raise your entire body off the bench except your upper back and shoulders, then lower back down without letting your legs touch.",
                WorkoutType = "Core",
                WorkoutLevel = 5
            },

            // Back Workouts
            new Workout
            {
                WorkoutName = "Superman",
                WorkoutInfo = "Lie face down on the floor with your arms extended in front of you. Lift your arms, chest, and legs off the ground as high as you can, then lower back down.",
                WorkoutType = "Back",
                WorkoutLevel = 1
            },
            new Workout
            {
                WorkoutName = "Bridge",
                WorkoutInfo = "Lie on your back with your knees bent and feet flat on the floor. Lift your hips towards the ceiling, squeezing your glutes, then lower back down.",
                WorkoutType = "Back",
                WorkoutLevel = 2
            },
            new Workout
            {
                WorkoutName = "Bird-Dog",
                WorkoutInfo = "Start on your hands and knees. Extend one arm and the opposite leg, keeping your body stable. Return to the start and switch sides.",
                WorkoutType = "Back",
                WorkoutLevel = 2
            },
            new Workout
            {
                WorkoutName = "Plank to Push-Up",
                WorkoutInfo = "Start in a plank position on your elbows. Push up onto your hands one at a time, then lower back down to your elbows.",
                WorkoutType = "Back",
                WorkoutLevel = 3
            },
            new Workout
            {
                WorkoutName = "Reverse Snow Angels",
                WorkoutInfo = "Lie face down with your arms at your sides. Lift your arms and legs off the ground, then move your arms in a snow angel motion without touching the ground.",
                WorkoutType = "Back",
                WorkoutLevel = 4
            },
            new Workout
            {
                WorkoutName = "Arch Hold",
                WorkoutInfo = "Lie face down on the floor, extend your arms overhead and your legs straight behind. Lift your chest and thighs off the floor, holding a 'banana' shape.",
                WorkoutType = "Back",
                WorkoutLevel = 5
            },

            // Shoulder Workouts
            new Workout
            {
                WorkoutName = "Arm Circles",
                WorkoutInfo = "Stand with your arms extended to the sides at shoulder height. Slowly make small circles forward and backward.",
                WorkoutType = "Shoulders",
                WorkoutLevel = 0
            },
            new Workout
            {
                WorkoutName = "Shoulder Taps",
                WorkoutInfo = "Start in a high plank position. Lift one hand and tap the opposite shoulder, then switch sides. Try to keep your hips stable.",
                WorkoutType = "Shoulders",
                WorkoutLevel = 1
            },
            new Workout
            {
                WorkoutName = "Pike Push-Ups",
                WorkoutInfo = "Start in a downward dog position. Lower your head towards the ground, then push back up. Keep your hips high and focus on your shoulders.",
                WorkoutType = "Shoulders",
                WorkoutLevel = 2
            },
            new Workout
            {
                WorkoutName = "Decline Pike Push-Ups",
                WorkoutInfo = "Place your feet on an elevated surface and perform a pike push-up. This increases the intensity on your shoulders.",
                WorkoutType = "Shoulders",
                WorkoutLevel = 3
            },
            new Workout
            {
                WorkoutName = "Wall Walks",
                WorkoutInfo = "Start in a high plank position with your feet against a wall. Slowly walk your feet up the wall while walking your hands closer to the wall, then reverse the motion.",
                WorkoutType = "Shoulders",
                WorkoutLevel = 4
            },
            new Workout
            {
                WorkoutName = "Handstand Hold (Against Wall)",
                WorkoutInfo = "Kick up into a handstand against a wall. Hold the position as long as possible, keeping your arms and core engaged.",
                WorkoutType = "Shoulders",
                WorkoutLevel = 5
            }
                ];
        }
        


    }



}


