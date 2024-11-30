using Spectre.Console;

namespace MovieApp.Controllers;

public class MovieController
{
    private static List<string> moviesList = new()
    {
        "Star Wars: A New Hope",
        "The Day After Tomorrow",
        "Man on Fire",
        "Avatar",
        "Children of Men",
    };
    internal static void ViewMovies()
    {
        AnsiConsole.MarkupLine("[yellow]List of movies: [/]");
        foreach (var movie in moviesList)
        {
            AnsiConsole.MarkupLine($"- [cyan]{movie}[/]");
        }
        AnsiConsole.MarkupLine("Press any key to continue");
        Console.ReadKey();
    }
}