using Core.Services.EmailService.EmailService;
using EasyNetQ;
using EmailMicroserviceMinimalAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<EmailSender>();
builder.Services.AddHostedService<EmailSender>();

/*builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80);
});*/

var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapPost("/send-email", async (EmailSender emailSender, Email request) =>
{
    try
    {
        emailSender.SendEmailAsync(request.EmailTo, request.Subject, request.Body);
        return Results.Ok("Email sent successfully.");
    }
    catch (Exception ex)
    {
        return Results.Problem($"An error occurred: {ex.Message}");
    }
});

app.Run();
