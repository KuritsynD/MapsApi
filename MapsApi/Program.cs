using Maps;
using Maps.Base;
using Maps.Services.Implimentations;
using Maps.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IBaseRepositry<Category>, BaseRepository<Category>>();
builder.Services.AddTransient<IBaseRepositry<Establishment>, BaseRepository<Establishment>>();
builder.Services.AddTransient<IBaseRepositry<Tag>, BaseRepository<Tag>>();
builder.Services.AddTransient<IRepairService, RepairService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();

