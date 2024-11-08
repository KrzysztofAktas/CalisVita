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

         public Workout? GetWorkout(int id)
        {
            return _context.Workouts.Find(id);
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


    }
}
