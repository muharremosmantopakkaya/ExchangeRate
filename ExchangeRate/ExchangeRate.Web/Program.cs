using ExchangeRate.Core.Repositories;
using ExchangeRate.Core.Services;
using ExchangeRate.Core.UnitOfWork;
using ExchangeRate.Helpers.Models.Dtos.DbModelDtos;
using ExchangeRate.Logging.Methods;
using ExchangeRate.Repository.Context;
using ExchangeRate.Repository.Repositories;
using ExchangeRate.Repository.UnitOfWork;
using ExchangeRate.Service.Mapping;
using ExchangeRate.Service.Services;
using ExchangeRate.Web.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// ConnectionString değerini kontrol et
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new ArgumentException("The string argument 'ConnectionString' cannot be empty.");
}

// Add services to the container
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
    });
});

builder.Services.AddControllersWithViews(); // MVC hizmetlerini eklemek için
builder.Services.AddRazorPages(); // Razor Pages kullanıyorsanız bunu ekleyin

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
builder.Services.AddScoped<IExchangeRateService, ExchangeRate.Service.Services.ExchangeRateService>();
builder.Services.AddScoped<IExchangeRateRepository, ExchangeRate.Repository.Repositories.ExchangeRateRepository>();
builder.Services.AddHttpClient();

builder.Services.Configure<ApplicationDto>(options =>
{
    options.Name = Assembly.GetEntryAssembly().GetName().Name;

    var dns = Dns.GetHostAddresses(Dns.GetHostName());
    if (dns.Length > 0)
    {
        options.Ip = dns[dns.Length - 1].ToString();
        if (dns.Length > 1 && options.Ip.Length > 20)
        {
            options.Ip = dns[0].ToString();
        }
    }
});

builder.Services.AddScoped<IUserLogService, UserLogService>();
builder.Services.AddScoped<IApplicationLogService, ApplicationLogService>();
builder.Services.AddScoped<IErrorLogService, ErrorLogService>();

builder.Services.AddSingleton<LogWorker>();
builder.Services.AddHostedService(provider => provider.GetService<LogWorker>());

builder.Services.AddSingleton<TimerWorker>();
builder.Services.AddHostedService(provider => provider.GetService<TimerWorker>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Razor Pages kullanıyorsanız bunu ekleyin

app.UseWebSockets();
app.UseMiddleware<WebSocketHandler>();

app.Run();
