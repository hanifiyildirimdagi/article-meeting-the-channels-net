using MeetingTheChannels.BackgroundServices;
using MeetingTheChannels.Journal;
using MeetingTheChannels.Notificator;
using MeetingTheChannels.Queue;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<INotificator, MockNotificator>();
builder.Services.AddSingleton<IJournalRegistrar, JournalRegistrar>();
builder.Services.AddSingleton<IJournalQueue, JournalQueue>();
builder.Services.AddHostedService<JournalConsumer>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();