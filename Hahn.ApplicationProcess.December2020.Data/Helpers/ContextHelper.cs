using Hahn.ApplicationProcess.December2020.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.December2020.Data.Helpers
{
    public static class ContextHelper
    {
        public static HahnContext GetContext()
        {
            var options = new DbContextOptionsBuilder<HahnContext>()
                .UseInMemoryDatabase(databaseName: "Hahn")
                .Options;

            using var context = new HahnContext(options);
            return context;
        }
    }
}