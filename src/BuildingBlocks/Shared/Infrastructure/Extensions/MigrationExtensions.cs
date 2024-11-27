using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Infrastructure.Extensions;
public static class MigrationExtensions
{
    public static void MigrationDatabase<TDbContext>(this WebApplication app)
        where TDbContext : DbContext
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
        dbContext.Database.Migrate();
    }
}
