using MeetingTheChannels.Requests;

namespace MeetingTheChannels.Notificator;

/// <summary>
/// Mock notification sender service. To stay on topic, let's assume that this service can actually send notifications. All methods will only wait for a certain amount of time.
/// </summary>
public interface INotificator
{
    Task Send(SendNotificationRequest request);
    Task Schedule(ScheduleNotificationRequest request);
}