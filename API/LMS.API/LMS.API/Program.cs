using GamaLearn.LMS.API.DependencyConfig;
using GamaLearn.LMS.API.Middelwares;
using GamaLearn.LMS.Infrastructure.Repository;

var MyAllowSpecificOrigins = "TaskPolicy";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(BookMappingProfile));
DependencyConfig dependancyConfig = new DependencyConfig(builder.Services, builder.Configuration, builder.Environment);
dependancyConfig.ConfigureServices();
builder.Logging.AddJsonConsole();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
