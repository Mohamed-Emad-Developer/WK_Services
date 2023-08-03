using Microsoft.EntityFrameworkCore;
using WK_Services.Data.Context;
using WK_Services.Domain.Models.User;
using WK_Services.Ioc;

var builder = WebApplication.CreateBuilder(args);

 

builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("WriteConnection"))
);

builder.Services.AddDbContext<ReadDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ReadConnection") )
);


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
 
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages()
    .AddViewLocalization()
    .AddSessionStateTempDataProvider()
    .AddRazorRuntimeCompilation()    
;
DependencyContainer.RegisterServices(builder.Services);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
