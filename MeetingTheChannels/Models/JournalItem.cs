namespace MeetingTheChannels.Models;

public class JournalItem
{
    public DateTime EventDate { get; set; }
    public object Parameter { get; set; }
    public string EventName { get; set; }


    public JournalItem(object parameter, string eventName)
    {
        Parameter = parameter;
        EventName = eventName;
        EventDate = DateTime.Now;
    }

    public JournalItem()
    {
    }
}