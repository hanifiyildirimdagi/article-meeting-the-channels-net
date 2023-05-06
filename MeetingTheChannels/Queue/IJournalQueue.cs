using MeetingTheChannels.Models;

namespace MeetingTheChannels.Queue;

public interface IJournalQueue
{
    Task Produce(JournalItem message);
    ValueTask<JournalItem> Consume(CancellationToken cancellationToken);
}