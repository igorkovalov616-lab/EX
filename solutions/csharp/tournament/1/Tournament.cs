using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public static class Tournament
{
    public static void Tally(Stream input, Stream output)
    {
        var teams = new Dictionary<string, Team>();

        using (var reader = new StreamReader(input))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(';');
                var teamA = parts[0];
                var teamB = parts[1];
                var result = parts[2];

                if (!teams.ContainsKey(teamA))
                    teams[teamA] = new Team(teamA);

                if (!teams.ContainsKey(teamB))
                    teams[teamB] = new Team(teamB);

                teams[teamA].MP++;
                teams[teamB].MP++;

                switch (result)
                {
                    case "win":
                        teams[teamA].W++;
                        teams[teamA].P += 3;
                        teams[teamB].L++;
                        break;

                    case "loss":
                        teams[teamB].W++;
                        teams[teamB].P += 3;
                        teams[teamA].L++;
                        break;

                    case "draw":
                        teams[teamA].D++;
                        teams[teamB].D++;
                        teams[teamA].P++;
                        teams[teamB].P++;
                        break;
                }
            }
        }

        var sb = new StringBuilder();
        sb.AppendLine("Team                           | MP |  W |  D |  L |  P");

        foreach (var team in teams.Values
            .OrderByDescending(t => t.P)
            .ThenBy(t => t.Name))
        {
            sb.AppendLine(
                $"{team.Name,-31}| {team.MP,2} | {team.W,2} | {team.D,2} | {team.L,2} | {team.P,2}"
            );
        }

        using (var writer = new StreamWriter(output))
        {
            writer.Write(sb.ToString().TrimEnd());
        }
    }
}

public class Team
{
    public string Name;
    public int MP, W, D, L, P;

    public Team(string name)
    {
        Name = name;
    }
}
