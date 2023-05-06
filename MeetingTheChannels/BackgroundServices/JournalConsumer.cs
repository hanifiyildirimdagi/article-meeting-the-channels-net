using MeetingTheChannels.Journal;
using MeetingTheChannels.Queue;

namespace MeetingTheChannels.BackgroundServices;

public sealed class JournalConsumer : BackgroundService
{
    private readonly IJournalQueue _journalQueue;
    private readonly IJournalRegistrar _registrar;
    private readonly ILogger<JournalConsumer> _logger;

    public JournalConsumer(IJournalQueue journalQueue, IJournalRegistrar registrar, ILogger<JournalConsumer> logger)
    {
        _journalQueue = journalQueue;
        _registrar = registrar;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var count = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = await _journalQueue.Consume(stoppingToken);
            await _registrar.Register(message);
            count++;
            _logger.LogInformation($"{message.EventName} : [{message.EventDate:O}]. {count} Message(s) Processed.");
        }
    }
}