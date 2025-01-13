using MovieApp.Models;
using Spectre.Console;

namespace MovieApp.Controllers;

public class TVShowController : IBaseController
{
    public void ViewItems()
    {
        var table = new Table();

        table.Border(TableBorder.Rounded);

        table.AddColumn("[cyan]Title[/]");
        table.AddColumn("[cyan]Genre[/]");
        table.AddColumn("[cyan]Score[/]");

        foreach (var tvShow in MockDatabase.TV)
        {
            table.AddRow(
                $"[cyan]{tvShow.Title}[/]",
                $"[cyan]{tvShow.Genre}[/]",
                $"[cyan]{tvShow.Score}[/]"
            );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press any key to continue");
        Console.ReadKey();
    }

    public void AddItem()
    {
        var tvShowTitle = AnsiConsole.Ask<string>(
            "Enter the name of the TV show you would like to add: "
        );
        var tvShowGenre = AnsiConsole.Ask<string>("Enter the genre of the TV show: ");
        var tvShowScore = AnsiConsole.Ask<int>("What do you rate the TV show:  ");

        if (
            MockDatabase.TV.Exists(tv =>
                tv.Title.Equals(tvShowTitle, StringComparison.OrdinalIgnoreCase)
            )
        )
        {
            AnsiConsole.MarkupLine("[red]Movie is already in the list [/]");
        }
        else
        {
            var newTVShow = new TVShow(tvShowTitle, tvShowGenre, tvShowScore);
            MockDatabase.TV.Add(newTVShow);
            AnsiConsole.MarkupLine("[green]New TV Show has been added.[/]");
        }
        AnsiConsole.MarkupLine("Press any key to continue!");
        Console.ReadKey();
    }

    public void DeleteItem()
    {
        if (MockDatabase.TV.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No TV show has been found![/]");
        }

        var tvShowToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<TVShow>()
                .Title("Select a TV Show to delete: ")
                .UseConverter(tv => $"{tv.Title}")
                .AddChoices(MockDatabase.TV)
        );

        if (MockDatabase.TV.Remove(tvShowToDelete))
        {
            AnsiConsole.MarkupLine($"[green]TV show has been successfully deleted.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]TV Show is not found.[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue!");
        Console.ReadKey();
    }
}
