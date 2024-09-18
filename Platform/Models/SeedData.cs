using Microsoft.EntityFrameworkCore;

namespace Platform.Models
{
    public class SeedData
    {
        private CalculationContext _context;
        private ILogger<SeedData> _logger;

        public SeedData(CalculationContext context, ILogger<SeedData> logger)
        {
            _context = context;
            _logger = logger;
        }
        private static Dictionary<int, long> data = new Dictionary<int, long>
        {
            { 1,2},{3,4},{4,16},{ 5,45},{6,4}
        };
        public void SeedDatabase()
        {
            _context.Database.Migrate();
            if (_context.Calculations?.Count() == 0)
            {
                _logger.LogInformation("preparing to seed the Database");
                _context.Calculations.AddRange(data.Select(kvp => new Calculation
                {
                    Count = kvp.Key,
                    Result = kvp.Value
                }));
                _context.SaveChanges();
                _logger.LogInformation("The database seeded");
            }
            else
            {
                _logger.LogInformation("The database not seeded");
            }
        }
    }
}
