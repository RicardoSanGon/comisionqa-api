using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using ComisionQA;
using System.Text.Json.Serialization;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddNpgsql<ComisionQaContext>(connectionString: "Host=localhost;Port=5432;Database=comisionqa;Username=postgres;Password=root;");
builder.Services.AddControllersWithViews();



var app = builder.Build();
if (args.Length == 1 && args[0].ToLower() == "seed")
{
    Console.WriteLine("Seeding database...");
    SeedDatabase();
}


async void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
        try
        {
            var scopedContext = scope.ServiceProvider.GetRequiredService<ComisionQaContext>();
            bool res = await new DbInitializer(scopedContext).Seed();
            if (res)
            {
                Console.WriteLine("Data Seeded");
            }
            else
            {
                Console.WriteLine("Error seeding data");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
