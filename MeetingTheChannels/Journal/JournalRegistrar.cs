using MeetingTheChannels.Models;

namespace MeetingTheChannels.Journal;

public class JournalRegistrar : IJournalRegistrar
{
    private readonly List<JournalItem> _journal = new();
    private readonly List<JournalItem> _pendingItems = new();
    private string AbsolutePath => Directory.GetCurrentDirectory() + "/journal.json";

    public JournalRegistrar()
    {
        if (!File.Exists(AbsolutePath))
            File.Create(AbsolutePath).Close();
        else
        {
            var content = File.ReadAllText(AbsolutePath);
            _journal = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JournalItem>>(content) ?? new();
        }
    }

    public async Task Register(JournalItem model)
    {
        _pendingItems.Add(model);
        await Write();
    }

    private async Task Write()
    {
        if (_pendingItems.Count <= 5) return;
        _journal.AddRange(_pendingItems);
        var content = Newtonsoft.Json.JsonConvert.SerializeObject(_journal);
        await File.WriteAllTextAsync(AbsolutePath, content);
        _pendingItems.Clear();
    }
}