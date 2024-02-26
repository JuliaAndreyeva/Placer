using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Placer.Infrastructure.Data
{
    public static class SeedingExtensions
    {
        public static async Task DatabaseEnsureCreated(this IApplicationBuilder applicationBuilder )
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PlacerCodeFirstDbContext>();
                var database = dbContext.Database;

                await database.EnsureDeletedAsync();
                await database.EnsureCreatedAsync();
            }
        }
    }
}
