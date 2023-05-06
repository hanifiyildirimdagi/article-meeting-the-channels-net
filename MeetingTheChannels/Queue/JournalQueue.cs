using System.Threading.Channels;
using MeetingTheChannels.Models;

namespace MeetingTheChannels.Queue;

public class JournalQueue : IJournalQueue
{
    private readonly Channel<JournalItem> _channel;

    public JournalQueue()
    {
        _channel = Channel.CreateBounded<JournalItem>(new BoundedChannelOptions(100)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true
        });
    }

    public async Task Produce(JournalItem message)
    {
        await _channel.Writer.WriteAsync(message);
    }

    public async ValueTask<JournalItem> Consume(CancellationToken cancellationToken)
    {
        return await _channel.Reader.ReadAsync(cancellationToken);
    }
}