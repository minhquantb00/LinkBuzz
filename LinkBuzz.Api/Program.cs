using LinkBuzz.Api.Installers;
using LinkBuzz.Application.ImplementService;
using LinkBuzz.Application.InterfaceService;
using LinkBuzz.Domain.Entities.PostEntities;
using LinkBuzz.Domain.Helpers;
using LinkBuzz.Domain.InterfaceRepositories;
using LinkBuzz.Infrastructure.DataContexts;
using LinkBuzz.Infrastructure.ImplementRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InstallerServiceInAsssembly(builder.Configuration);
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString(Constants.AppSettingKeys.DEFAULT_CONNECTION), x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IRepository<Post>, Repository<Post>>();
builder.Services.AddScoped<IDbContext, AppDbContext>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
