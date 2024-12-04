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
        var movieGenre = AnsiConsole.Ask<string>("Enter the genre fo the movie that you would like to add: ");
        var movieScore = AnsiConsole.Ask<int>("What is your score for the movie: ");
        
        if (MockDatabase.Movies.Exists(m => m.Title.Equals(movieTitle, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine("[red]Movie is already in the list![/]");
        }
        else
        {
            var newMovie = new Movie(movieTitle, movieGenre, movieScore);
            MockDatabase.Movies.Add(newMovie);
            AnsiConsole.MarkupLine($"[green]New movie has been successfully added![/]");
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