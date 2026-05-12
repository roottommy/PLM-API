using PLM_API.Extensions;
using PLM_API.Infrastructure.MSSql;
using PLM_API.Services;
using Microsoft.EntityFrameworkCore;
using PLM_API.PLM.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<PLM_API.Utilities.AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IPartService, PartService>();
builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.AddScoped<IInspectionBaseService, InspectionBaseService>();
builder.Services.AddScoped<IInspectionBaseRepository, InspectionBaseRepository>();
builder.Services.AddScoped<IERPBaseService, ERPBaseService>();
builder.Services.AddScoped<IERPBaseRepository, ERPBaseRepository>();
builder.Services.AddScoped<IAppLogService, AppLogService>();
builder.Services.AddDbContext<AppSPCDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SPCConnection")));
builder.Services.AddDbContext<AppERPDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ERPConnection")));
builder.Services.AddDbContext<AppERPSysDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ERPSysConnection")));
builder.Services.AddDbContext<AppLogDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GizmoLogConnection")));
builder.Services.AddDbContext<AppModelDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ModelConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PLMPolicy", policy =>
    {
        policy.SetIsOriginAllowed((string origin) => true)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// 註冊 Mongo（appsettings.json 須有 "Mongo" 節點）
builder.Services.AddMongo(builder.Configuration);

var logPath = Path.Combine(AppContext.BaseDirectory, "logs", "log-.txt");
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .Enrich.WithThreadId()
    .Enrich.WithProcessId()
    .WriteTo.File(
        path: logPath,
        rollingInterval: RollingInterval.Day, // 每日產生新檔
        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
    )
    .CreateLogger();
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); c.RoutePrefix = ""; });
//}

// 全域 CORS 設定
app.Use(async (context, next) =>
{
    // 1. 取得瀏覽器傳過來的來源網址
    string origin = context.Request.Headers["Origin"];

    // 2. 定義允許的白名單
    var allowedOrigins = new[] {
        "http://127.0.0.1",
        "http://plm"
    };

    // 3. 如果來源在白名單內，就動態塞入該 Origin
    if (allowedOrigins.Contains(origin))
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", origin);
        context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
        context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
        context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
    }


    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 200;
        await context.Response.CompleteAsync();
        return;
    }

    await next();
});

app.UseHttpsRedirection();

//app.UseRouting();

//app.UseCors("PLMPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
