namespace CalisVita.Context
{
    public class WorkoutProvider
    {
        private readonly DatabaseContext _context;

        public WorkoutProvider(DatabaseContext context) {  _context = context; }


    }
}
