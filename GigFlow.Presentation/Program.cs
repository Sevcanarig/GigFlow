using GigFlow.Application;
using GigFlow.Persistence;
using GigFlow.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPersistenceServices(builder.Configuration); 
builder.Services.AddApplicationServices(); 


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GigFlowDbContext>();
    context.Database.Migrate();
    SeedData.Initialize(context);
}


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();


app.Run();