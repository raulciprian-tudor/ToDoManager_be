using TodoManagerBe.Entities;
using TodoManagerBe.Services;

var builder = WebApplication.CreateBuilder(args); // create web app
var MyAllowSpecificOrigins = "https://localhost:4200";
// Add services to the container.

// add dependency injection
builder.Services.AddControllers(); // add controllers
builder.Services.AddEndpointsApiExplorer(); // add endpoint api explorer for swagger
builder.Services.AddSwaggerGen(); // add swagger
builder.Services.AddCors(options => // add cors
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200",
                                "https://localhost:4200");
        });
});
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<BooksService>(); // add books dependency injection
// end of dependency injection

var app = builder.Build(); // build app

if (app.Environment.IsDevelopment()) // if in development environment
{
    app.UseSwagger(); // use swagger
    app.UseSwaggerUI(); // use swagger ui
}

app.UseCors(MyAllowSpecificOrigins); // use cors
app.UseHttpsRedirection(); // use https redirection for security - redirect http to https
app.UseAuthorization(); // use authorization for security - authorize user
app.MapControllers(); // map controllers before running app
app.Run(); // run app
