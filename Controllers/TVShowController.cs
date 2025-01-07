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
        throw new NotImplementedException();
    }

    public void DeleteItem()
    {
        throw new NotImplementedException();
    }
}
