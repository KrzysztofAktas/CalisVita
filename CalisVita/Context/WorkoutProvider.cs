using CalisVita.Model;
using Microsoft.EntityFrameworkCore;

namespace CalisVita.Context
{
    public class WorkoutProvider
    {
        private readonly DatabaseContext _context;

        public WorkoutProvider(DatabaseContext context) {  _context = context; }

        public async Task<List<Workout>> GetAllWorkoutsAsync()
        {
            return await _context.Workouts.OrderBy(workout => workout.WorkoutName).ToListAsync();
        }

         public async Task<Workout> GetWorkoutByIdAsync(int id)
        {
            return await _context.Workouts.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task AddWorkoutAsync(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorkoutAsync(Workout workout)
        {
            _context.Workouts.Update(workout);
            await _context.SaveChangesAsync();
        }

        public async Task<List<string>> GetWorkoutTypesAsync()
        {
            return await _context.Workouts
                                 .Select(w => w.WorkoutType)
                                 .Distinct()
                                 .ToListAsync();
        }

        public async Task<int> GetTotalWorkoutsCompletedAsync(string userId)
        {
            return await _context.UserWorkoutLogs
                                 .Where(log => log.User.Id == userId)
                                 .CountAsync();
        }

        public async Task<int> GetWorkoutStreakAsync(string userId)
        {
            var logs = await _context.UserWorkoutLogs
                                      .Where(log => log.User.Id == userId)
                                      .OrderByDescending(log => log.LogDate)
                                      .ToListAsync();

            if (!logs.Any()) return 0;

            int streak = 0;
            DateTime currentDate = DateTime.Now.Date;

            foreach (var log in logs)
            {
                if (log.LogDate.Date == currentDate)
                {
                    streak++;
                    currentDate = currentDate.AddDays(-1); // Check the previous day
                }
                else if (log.LogDate.Date < currentDate)
                {
                    break;
                }
            }

            return streak;
        }

        public async Task<List<Workout>> GetWorkoutsByTypeAsync(string workoutType)
        {
            using (var context = _context)
            {
                return await context.Workouts
                    .Where(w => w.WorkoutType == workoutType)
                    .ToListAsync();
            }
        }

        private static readonly Dictionary<DayOfWeek, string> DailyWorkoutTypes = new()
{
    { DayOfWeek.Monday, "Shoulders" },
    { DayOfWeek.Tuesday, "Core" },
    { DayOfWeek.Wednesday, "Chest" },
    { DayOfWeek.Thursday, "Back" },
    { DayOfWeek.Friday, "Legs" },
};

        public string GetWorkoutTypeForToday()
        {
            return DailyWorkoutTypes[DateTime.Today.DayOfWeek];
        }

        public async Task<Workout> GetDailyWorkoutAsync(string workoutType, string userLevel)
        {
            int level = ConvertUserLevelToInt(userLevel);
            return await _context.Workouts
                .Where(w => w.WorkoutType == workoutType && w.WorkoutLevel == level)
                .OrderBy(w => Guid.NewGuid()) // Randomly select a workout
                .FirstOrDefaultAsync();
        }

        private int ConvertUserLevelToInt(string userLevel)
        {
            return userLevel switch
            {
                "Beginner" => 1,
                "Intermediate" => 2,
                "Advanced" => 3,
                _ => 1 // Default to Beginner
            };
        }





    }
}
