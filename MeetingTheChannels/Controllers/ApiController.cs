using MeetingTheChannels.Models;
using MeetingTheChannels.Notificator;
using MeetingTheChannels.Queue;
using MeetingTheChannels.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MeetingTheChannels.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly INotificator _notificator;
    private readonly IJournalQueue _journalQueue;

    public ApiController(INotificator notificator, IJournalQueue journalQueue)
    {
        _notificator = notificator;
        _journalQueue = journalQueue;
    }

    /// <summary>
    /// Sends a notification to a user.
    /// </summary>
    /// <returns></returns>
    [HttpPost("SendNotification")]
    public async Task<IActionResult> SendNotification([FromBody] SendNotificationRequest request)
    {
        await _notificator.Send(request);
        await _journalQueue.Produce(new JournalItem(request, nameof(SendNotificationRequest)));
        return Ok();
    }

    /// <summary>
    /// Schedules a user to be sent a notification
    /// </summary>
    /// <returns></returns>
    [HttpPost("ScheduleNotification")]
    public async Task<IActionResult> ScheduleNotification([FromBody] ScheduleNotificationRequest request)
    {
        await _notificator.Schedule(request);
        await _journalQueue.Produce(new JournalItem(request, nameof(ScheduleNotificationRequest)));
        return Ok();
    }
}