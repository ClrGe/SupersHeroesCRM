using Microsoft.EntityFrameworkCore;
using SupersHerosCRM.Data;
using SupersHerosCRM.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Add our services
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IHeroService, HeroService>();


var connectionString = builder.Configuration.GetConnectionString("DbKey") ??
                       throw new InvalidOperationException("Connection string 'DbKey' not found.");

builder.Services.AddDbContext<SupersHerosCRMDbContext>(options =>
    options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

// create the database if it doesn't exist
var db = builder.Services.BuildServiceProvider().GetService<SupersHerosCRMDbContext>();
//db.Database.EnsureCreated();

// do the migration
db.Database.Migrate();
builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.UseCors("AllowAll");
app.Run();