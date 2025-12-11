using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Auto-create databases if they don't exist
using (var scope = app.Services.CreateScope())
{
    try
    {
        var userContext = new eUseControl.BusinessLogic.DBModel.UserContext();
        userContext.Database.EnsureCreated();
        
        var membershipContext = new eUseControl.BusinessLogic.DBModel.MembershipContext();
        membershipContext.Database.EnsureCreated();
        
        var coachContext = new eUseControl.BusinessLogic.DBModel.CoachContext();
        coachContext.Database.EnsureCreated();
        
        var orderContext = new eUseControl.BusinessLogic.DBModel.OrderContext();
        orderContext.Database.EnsureCreated();
        
        var eventContext = new eUseControl.BusinessLogic.DBModel.EventContext();
        eventContext.Database.EnsureCreated();
        
        var discountContext = new eUseControl.BusinessLogic.DBModel.DiscountContext();
        discountContext.Database.EnsureCreated();
        
        var feedbackContext = new eUseControl.BusinessLogic.DBModel.FeedbackContext();
        feedbackContext.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error creating database: {ex.Message}");
    }
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
