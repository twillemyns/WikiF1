using WikiF1.API.Models;

namespace WikiF1.API.Services;

public class RecordService
{
    private static List<Record> Records;

    private static int nextId = 3;

    static RecordService()
    {
        Records = new List<Record>
        {
            new Record
            {
                Id = 1, NbTitles = 2, BestRacePlace = 1, NbPoles = 20, BestQuali = 1, NbPodiums = 77, NbRaces = 163,
                NbVictories = 35
            },
            new Record
            {
                Id = 2, NbTitles = 0, BestRacePlace = 1, NbPoles = 1, BestQuali = 1, NbPodiums = 26, NbRaces = 235,
                NbVictories = 4
            }
        };
    }
    
    public static List<Record> getAll() => Records;

    public static Record? Get(int id) => Records.FirstOrDefault(p => p.Id == id);

    public static void Add(Record record)
    {
        record.Id = nextId++;
        Records.Add(record);
    }

    public static void Delete(int id)
    {
        var record = Get(id);
        if (record is null) return;
        Records.Remove(record);
    }

    public static void Update(Record record)
    {
        var index = Records.FindIndex(r => r.Id == record.Id);
        if (index == -1) return;
        Records[index] = record;
    }
}