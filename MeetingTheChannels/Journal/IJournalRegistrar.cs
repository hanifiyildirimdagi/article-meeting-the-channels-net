using MeetingTheChannels.Models;

namespace MeetingTheChannels.Journal;

public interface IJournalRegistrar
{
    Task Register(JournalItem model);
}