using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Data;
using Project.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PrimaryDbConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.RegisterService();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

//Please update your endpoint route here
app.UseEndpoints(endpoints =>
{
    //endpoints.MapDefaultControllerRoute();
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=Index}/{Id?}");
});

app.Run();
