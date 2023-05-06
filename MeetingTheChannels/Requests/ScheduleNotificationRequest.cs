namespace MeetingTheChannels.Requests;

public class ScheduleNotificationRequest : SendNotificationRequest
{
    public string DueDate { get; set; }
}