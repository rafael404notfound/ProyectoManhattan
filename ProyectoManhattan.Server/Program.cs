using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoManhattan.Infrastructure.Persistance;
using ProyectoManhattan.Application;
using System;
using ProyectoManhattan.Server;
using ProyectoManahttan.Application;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

/*builder.WebHost.UseKestrel(options => options.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps(adapterOptions =>
                        {
                            adapterOptions.ServerCertificate = new X509Certificate2("/home/app/.aspnet/https/aspnetapp.pfx", "supersecret");
                        })));*/

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration["ConnectionStrings:ApplicationDockerConnection"]);
    opts.EnableSensitiveDataLogging(true);
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("open", 
        policy =>
        {
            policy.AllowAnyOrigin()            
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

/*builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
    options.HttpsPort = 5000;
});*/


builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
//builder.Services.AddHostedService((sp) => sp.GetRequiredService<CookieGetter>());
builder.Services.AddHostedService((sp) => sp.GetRequiredService<IJwtGetter>());
builder.Services.AddHostedService((sp) => sp.GetRequiredService<PendingReportQueue>());
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IApplicationRepo, EFApplicationRepository>();
builder.Services.AddScoped<IReportRepo, EFReportRepository>();
//builder.Services.AddSingleton<IJwtGetter, CookieGetter>();
builder.Services.AddSingleton<IJwtGetter, PlaywrightJwtGetter>();
builder.Services.AddSingleton<PendingReportQueue>();
builder.Services.AddSingleton<PdfEditor>();
builder.Services.AddTransient<EciService>();
builder.Services.AddTransient<EmailService>();
builder.Services.AddTransient<WebFetcher>();
builder.Services.AddTransient<IServiceProvider, ServiceProvider>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
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
    app.ApplyMigrations();
}
//app.UseCors("_myAllowSpecificOrigins");


app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("open");
app.UseAuthorization();

/*app.MapWhen(
    context => context.Request.Path.StartsWithSegments("/api"),
    builder => builder.RunProxy(new ProxyOptions
    {
        Scheme = "https",
        Host = "localhost",
        Port = "80",
    })
);*/

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.MapHub<NotificationHub>("notifications");

app.Run();
