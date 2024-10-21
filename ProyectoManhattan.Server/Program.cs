using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoManhattan.Infrastructure.Persistance;
using ProyectoManhattan.Application;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration["ConnectionStrings:ApplicationConnection"]);
    opts.EnableSensitiveDataLogging(true);
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
        });
});


builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
//builder.Services.AddHostedService((sp) => sp.GetRequiredService<CookieGetter>());
builder.Services.AddHostedService((sp) => sp.GetRequiredService<IJwtGetter>());
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IApplicationRepo, EFApplicationRepository>();
builder.Services.AddScoped<IReportRepo, EFReportRepository>();
//builder.Services.AddSingleton<IJwtGetter, CookieGetter>();
builder.Services.AddSingleton<IJwtGetter, PlaywrightJwtGetter>();
builder.Services.AddSingleton<PdfEditor>();
builder.Services.AddTransient<EciService>();
builder.Services.AddTransient<EmailService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddCors(policy =>
{
    policy.AddPolicy("_myAllowSpecificOrigins", builder => builder.WithOrigins("https://localhost:5000/")
         .SetIsOriginAllowed((host) => true)
         .AllowAnyMethod()
         .AllowAnyHeader()
         .AllowCredentials());
});*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
//app.UseCors("_myAllowSpecificOrigins");
app.UseCors();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
