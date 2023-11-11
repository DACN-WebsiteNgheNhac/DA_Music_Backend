using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Music_Backend.Data;
using Music_Backend.Middlewares;
using Music_Backend.Repositories;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services;
using Music_Backend.Services.IServices;
using Music_Backend.Utils;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(opt => opt.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddCors();

builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Auth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "bearer token",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    opt.OperationFilter<SecurityRequirementsOperationFilter>();
    opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

#region Authentication and Authorization
builder.Services.AddAuthentication(op =>
{
    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(op =>
{
    op.SaveToken = true;
    op.RequireHttpsMetadata = false;
    op.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
        ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecureKey"]))
    };
});


// Authorization
//builder.Services.AddAuthorization(op =>
//{
//    op.AddPolicy("DepartmentPolicy", policy => policy.RequireClaim("department"));
//});
builder.Services.AddAuthorization();


#endregion Authentication and Authorization

AddDI(builder.Services);

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
//if (!app.Environment.IsDevelopment())
app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

#region use another middleware

app.ConfigureExceptionMiddleware();

#endregion

app.MapControllers();

app.Run();



void AddDI(IServiceCollection services)
{
    //services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

    services.AddDbContext<DataContext>();
    services.AddTransient<SeedData>();
    services.AddTransient<ExceptionMiddleware>();


    services.AddScoped<ISongService, SongService>();
    services.AddScoped<ISongRepository, SongRepository>();


    services.AddAutoMapper(typeof(Program).Assembly);
}

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedData>();
        service.SeedDataContext();
    }

}
