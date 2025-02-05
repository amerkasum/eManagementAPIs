using Core.Services.EmailService.EmailService;
using EmailMicroserviceMinimalAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapPost("/send-email", async (EmailSender emailSender, EmailRequest request) =>
{
    try
    {
        await emailSender.SendEmailAsync(request.EmailTo, request.Subject, request.Message);
        return Results.Ok("Email sent successfully.");
    }
    catch (Exception ex)
    {
        return Results.Problem($"An error occurred: {ex.Message}");
    }
});

app.Run();
