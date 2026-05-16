using Presentation.ConfigurationEndpoints;
using Presentation.ConfigurationExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration Extensions
builder.Services.AddDapperExtension();
builder.Services.AddFluentValidationExtension();
builder.Services.AddTodoExtension();

var app = builder.Build();

// Docker - Utilizar Swagger em ambiente de desenvolvimento e produção
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();

//    // Swagger - Configuração para ordenar os endpoints DELETE - GET - POST - PUT
//    //app.UseSwaggerUI();
//    app.UseSwaggerUI(c =>
//    {
//        c.ConfigObject.AdditionalItems["operationsSorter"] = "method";
//    });
//}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.ConfigObject.AdditionalItems["operationsSorter"] = "method";
});

// Docker - Está utilizando HTTP, então não é necessário redirecionar para HTTPS
//app.UseHttpsRedirection();
if (app.Environment.IsDevelopment()) 
{
    app.UseHttpsRedirection();
}

// Configuration Endpoints
app.AddTodoEndpoint();

app.Run();
