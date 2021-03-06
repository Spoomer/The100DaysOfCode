using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using The100DaysOfCode.MVC;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DayOfCodeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DayOfCodeContext")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(AutoMapperProfileV1));
builder.Services.AddScoped<IDbAccess,EFDbAccess>();
builder.Services.AddScoped<DayOfCodeService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DayOfCodeContext>();
    context.Database.EnsureCreated();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DaysOfCode}/{action=Index}/{id?}");

app.Run();
