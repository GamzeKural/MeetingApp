using MeetingApp.Web.Business.Services.Abstracts;
using MeetingApp.Web.Business.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IHttpService, HttpService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IMeetingService, MeetingService>();
builder.Services.AddTransient<IMeetingParticipantService, MeetingParticipantService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IEmailRecipientService, EmailRecipientService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}");

app.Run();
