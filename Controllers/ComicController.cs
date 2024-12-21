using MovieApp.Models;
using Spectre.Console;

namespace MovieApp.Controllers;

public class ComicController : IBaseController
{
    public void ViewItems()
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);

        table.AddColumn("[cyan]Title[/]");
        table.AddColumn("[cyan]Genre[/]");
        table.AddColumn("[cyan]Author[/]");
        table.AddColumn("[cyan]Review[/]");
        table.AddColumn("[cyan]Score[/]");

        foreach(var comic in MockDatabase.Comics) 
        {
            table.AddRow(
                    $"[cyan]{comic.Title}[/]",
                    $"[cyan]{comic.Author}[/]",
                    $"[cyan]{comic.Genre}[/]",
                    $"[cyan]{comic.Review}[/]",
                    $"[cyan]{comic.Score}[/]"
                    );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press any key to continue");
        Console.ReadKey();
    }

    public void AddItem()
    {
        
    }

    public void DeleteItem()
    {

    }
}
