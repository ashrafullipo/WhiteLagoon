using Microsoft.EntityFrameworkCore;
using Serilog;
using WhiteLagoon.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Step 1: Bootstrap Logger শুরু (Log.Logger, না log.logger ❌)
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/bootstrap_log.txt", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

Log.Information("Starting up the application...");

try
{
    // ✅ Step 2: Full Serilog configuration (after app settings loaded)
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logs/full_log.txt", rollingInterval: RollingInterval.Day));

    // ✅ Step 3: Add services to the container
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnectionString")));

    var app = builder.Build();

    // ✅ Step 4: Configure middleware
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    Log.Information("Application is now running 🚀");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start correctly 💥");
}
finally
{
    Log.CloseAndFlush();
}
