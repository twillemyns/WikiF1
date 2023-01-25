using WikiF1.API.Models;

namespace WikiF1.API.Services;

public class TrackService
{
    private static List<Track> Tracks { get; }

    private static int nextId = 3;

    static TrackService()
    {
        Tracks = new List<Track>
        {
            new Track
            {
                Id = 1, Country = "Barheïn", Name = "Circuit International de Sakhir", PictureUrl = "",
                BeginYearInF1 = "2004", NbRaces = 18, NextGPDate = new DateTime(2023, 03, 05)
            },
            new Track
            {
                Id = 2, Country = "Arabie Saoudite", Name = "Jeddah Corniche Circuit", PictureUrl = "",
                BeginYearInF1 = "2021", NbRaces = 2, NextGPDate = new DateTime(2023, 03, 19)
            }
        };
    }

    public static List<Track> GetAll() => Tracks;

    public static Track? Get(int id) => Tracks.FirstOrDefault(t => t.Id == id);

    public static void Add(Track track)
    {
        track.Id = nextId++;
        Tracks.Add(track);
    }

    public static void Delete(int id)
    {
        var track = Get(id);
        if (track is null) return;
        
        Tracks.Remove(track);
    }

    public static void Update(Track track)
    {
        var index = Tracks.FindIndex(t => t.Id == track.Id);
        if (index == -1) return;

        Tracks[index] = track;
    }

}