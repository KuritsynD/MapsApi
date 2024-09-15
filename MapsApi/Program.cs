using Maps;
using Maps.Services.Implimentations;
using Maps.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IBaseRepositry<Category>, BaseRepository<Category>>();
// builder.Services.AddTransient<IBaseRepositry<Establishment>, BaseRepository<Establishment>>();
// builder.Services.AddTransient<IBaseRepositry<Tag>, BaseRepository<Tag>>();
// builder.Services.AddTransient<IRepairService, RepairService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();

