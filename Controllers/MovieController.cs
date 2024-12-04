using MovieApp.Models;
using Spectre.Console;

namespace MovieApp.Controllers;

public class MovieController
{
    internal void ViewMovies()
    {
        AnsiConsole.MarkupLine("[yellow]List of movies: [/]");
        foreach (var movie in MockDatabase.Movies)
        {
            AnsiConsole.MarkupLine($"- [cyan]{movie}[/]");
        }
        AnsiConsole.MarkupLine("Press any key to continue");
        Console.ReadKey();
    }

    internal void AddMovie()
    {
        var movieTitle = AnsiConsole.Ask<string>("Enter the name of the movie you would like to add: ");
        
        if (MockDatabase.Movies.Contains(movieTitle))
        {
            AnsiConsole.MarkupLine("[red]Movie is already in the list![/]");
        }
        else
        {
            MockDatabase.Movies.Add(movieTitle);
            AnsiConsole.MarkupLine($"[green]{movieTitle} has been successfully added![/]");
        }
        
        AnsiConsole.MarkupLine("Press any key to continue!");
        Console.ReadKey();
    }

    internal void DeleteMovie()
    {
        if (MockDatabase.Movies.Count == 0)
        {
            AnsiConsole.MarkupLine("[red] No books have been found! [/]");
        }
        
        var movieTitle = AnsiConsole.Ask<string>("Enter the name of the movie that you would like to delete: ");

        if (MockDatabase.Movies.Remove(movieTitle))
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