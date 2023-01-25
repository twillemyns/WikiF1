using WikiF1.API.Models;

namespace WikiF1.API.Services;

public class TeamService
{
    private static List<Team> Teams { get; }

    private static int nextId = 2;

    static TeamService()
    {
        Teams = new List<Team>
        {
            new Team
            {
                Id = 1, Name = "Red Bull Racing", LogoUrl = "", Driver1Id = 1, Driver2Id = 2, TeamPrincipalId = 1,
                RecordId = 1
            },
        };
    }

    public static List<Team> GetAll() => Teams;

    public static Team? Get(int id) => Teams.FirstOrDefault(t => t.Id == id);

    public static void Add(Team team)
    {
        team.Id = nextId++;
        Teams.Add(team);
    }

    public static void Delete(int id)
    {
        var team = Get(id);
        if (team is null) return;

        Teams.Remove(team);
    }

    public static void Update(Team team)
    {
        var index = Teams.FindIndex(t => t.Id == team.Id);
        if (index == -1) return;

        Teams[index] = team;
    }
}