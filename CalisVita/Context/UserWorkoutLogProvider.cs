using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalisVita.Context;
using CalisVita.Model;
using Microsoft.EntityFrameworkCore;

namespace CalisVita.Data
{
    public class UserWorkoutLogProvider
    {
        private readonly DatabaseContext _context;

        public UserWorkoutLogProvider(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new UserWorkoutLog to the database.
        /// </summary>
        /// <param name="log">The UserWorkoutLog to add.</param>
        public async Task AddUserWorkoutLogAsync(UserWorkoutLog log)
        {
            if (log == null)
                throw new ArgumentNullException(nameof(log));

            _context.UserWorkoutLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all workout logs for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of UserWorkoutLogs.</returns>
        public async Task<List<UserWorkoutLog>> GetWorkoutLogsByUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));

            return await _context.UserWorkoutLogs
                .Where(log => log.User.Id == userId)
                .OrderByDescending(log => log.LogDate)
                .ToListAsync();
        }

        /// <summary>
        /// Gets the total reps completed by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The total reps count.</returns>
        public async Task<int> GetTotalRepsByUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));

            return await _context.UserWorkoutLogs
                .Where(log => log.User.Id == userId)
                .SumAsync(log => log.Reps);
        }

        /// <summary>
        /// Gets the total logs for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The total number of workout logs.</returns>
        public async Task<int> GetLogCountByUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));

            return await _context.UserWorkoutLogs
                .Where(log => log.User.Id == userId)
                .CountAsync();
        }
    }
}
