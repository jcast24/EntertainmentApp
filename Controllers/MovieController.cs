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

    internal static void AddMovie()
    {
        var movieTitle = AnsiConsole.Ask<string>("Enter the name of the movie you would like to add: ");
        
        if (moviesList.Contains(movieTitle))
        {
            AnsiConsole.MarkupLine("[red]Movie is already in the list![/]");
        }
        else
        {
            moviesList.Add(movieTitle);
            AnsiConsole.MarkupLine($"[green]{movieTitle} has been successfully added![/]");
        }
        
        AnsiConsole.MarkupLine("Press any key to continue!");
        Console.ReadKey();
    }

    internal static void DeleteMovie()
    {
        if (moviesList.Count == 0)
        {
            AnsiConsole.MarkupLine("[red] No books have been found! [/]");
        }
        
        var movieTitle = AnsiConsole.Ask<string>("Enter the name of the movie that you would like to delete: ");

        if (moviesList.Remove(movieTitle))
        {
            AnsiConsole.MarkupLine($"[green] {movieTitle} has been successfully deleted. [/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]Book not found[/]");
        }
        AnsiConsole.MarkupLine("Press any key to continue!");
        Console.ReadKey();
    }
}