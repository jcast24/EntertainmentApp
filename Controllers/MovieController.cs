using MovieApp.Models;
using Spectre.Console;

namespace MovieApp.Controllers;

public class MovieController
{
    internal void ViewMovies()
    {
        // AnsiConsole.MarkupLine("[yellow]List of movies: [/]");
        // foreach (var movie in MockDatabase.Movies)
        // {
        //     AnsiConsole.MarkupLine(
        //         $"- [cyan]{movie.Title} - [yellow]{movie.Genre}[/] - [purple]{movie.Score}[/][/]"
        //     );
        // }
        // AnsiConsole.MarkupLine("Press any key to continue");
        // Console.ReadKey();

        var table = new Table();
        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Genre[/]");
        table.AddColumn("[yellow]Score[/]");

        foreach (var movie in MockDatabase.Movies)
        {
            table.AddRow(
                    $"[cyan]{movie.Title}[/]",
                    $"[cyan]{movie.Genre}[/]",
                    $"[cyan]{movie.Score}[/]"
                    );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press any key to continue");
        Console.ReadKey();

    }

    internal void AddMovie()
    {
        var movieTitle = AnsiConsole.Ask<string>(
            "Enter the name of the movie you would like to add: "
        );
        var movieGenre = AnsiConsole.Ask<string>(
            "Enter the genre fo the movie that you would like to add: "
        );
        var movieScore = AnsiConsole.Ask<int>("What is your score for the movie: ");

        if (
            MockDatabase.Movies.Exists(m =>
                m.Title.Equals(movieTitle, StringComparison.OrdinalIgnoreCase)
            )
        )
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

        // var movieTitle = AnsiConsole.Ask<string>("Enter the name of the movie that you would like to delete: ");
        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Movie>()
                .Title("Select a movie to delete: ")
                .UseConverter(m => $"{m.Title}")
                .AddChoices(MockDatabase.Movies)
        );

        if (MockDatabase.Movies.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine($"[green] Movie has been successfully deleted. [/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]Movie is not found[/]");
        }
        AnsiConsole.MarkupLine("Press any key to continue!");
        Console.ReadKey();
    }
}
