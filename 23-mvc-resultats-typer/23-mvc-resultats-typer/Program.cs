using Microsoft.AspNetCore.Routing;
using mvc_resultats_typer.ActionFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(CustomStringFilterAttribute));
});

var app = builder.Build();

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

// Custom route for services/people/{id}
app.MapControllerRoute(
    name: "PeopleDetails",
    pattern: "services/people/{id}",
    defaults: new { controller = "Person", action = "Details" }
    );

// Custom route for services
app.MapControllerRoute(
    name: "CustomRoute",
    pattern: "services/{action=Index}/{id?}",
    defaults: new { controller = "Person" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
