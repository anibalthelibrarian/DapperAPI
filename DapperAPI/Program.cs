using Data;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<LibraryDBContext>();
builder.Services.AddTransient<PeopleDBContext>();
builder.Services.AddScoped<ILibraryRepo, LibraryRepo>();
builder.Services.AddScoped<IPeopleRepo, PeopleRepo>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConnectionStringsOptions>
    (builder.Configuration.GetSection(ConnectionStringsOptions.Conn));

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
