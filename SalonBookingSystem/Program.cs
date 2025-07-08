using SalonBookingSystem.Components;
using SalonBookingSystem.DataAccess.Services;
using SalonBookingSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ServiceService>();
builder.Services.AddSingleton<StaffService>();
builder.Services.AddSingleton<BookingService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<SkillService>();
builder.Services.AddSingleton<ReviewService>();
builder.Services.AddSingleton<UserStateService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
