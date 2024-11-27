using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using lsbu_solutionise.Data;
using lsbu_solutionise.Sevices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddSingleton<EmailService>();
builder.Services.AddControllersWithViews();

//var date = new CalDateTime(2024, 10, 15, 11, 0, 0);
//var calendarEvent = new CalendarEvent
//{
//    // If Name property is used, it MUST be RFC 5545 compliant
//    Summary = "Event Title12", // Should always be present
//    Description = "Event description goes here", // optional
//    Start = new CalDateTime(date),
//    End = new CalDateTime(date.AddHours(2)),
//};

//var calendar = new Ical.Net.Calendar();
//calendar.Events.Add(calendarEvent);
//calendar.AddTimeZone(new VTimeZone("Europe/Copenhagen")); // TZ should be added
//var serializer = new CalendarSerializer();
//var serializedCalendar = serializer.SerializeToString(calendar);
//Console.WriteLine(serializedCalendar);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
