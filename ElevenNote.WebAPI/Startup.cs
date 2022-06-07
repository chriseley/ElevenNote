using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public class Startup {

    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services) {
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ElevenNote.WebAPI", Version = "v1" });
        });
    }
    public void Configure(WebApplication app, IWebHostEnvironment env) {
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}