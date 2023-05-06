using MeetingTheChannels.Requests;

namespace MeetingTheChannels.Notificator;

public class MockNotificator : INotificator
{
    public async Task Send(SendNotificationRequest request) => await Task.Delay(500);

    public async Task Schedule(ScheduleNotificationRequest request) => await Task.Delay(500);
}