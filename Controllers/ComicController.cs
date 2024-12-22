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
        var comicTitle = AnsiConsole.Ask<string>("Enter the name of the comic title: ");
        var comicAuthor = AnsiConsole.Ask<string>("Enter the name of the author: ");
        var comicGenre = AnsiConsole.Ask<string>("Enter the genre of the comic: ");
        var comicReview = AnsiConsole.Ask<string>("Enter your review for the comic: ");
        var comicScore = AnsiConsole.Ask<int>("Enter the score that you rate the comic: ");
        
        if (MockDatabase.Comics.Exists(c => c.Title.Equals(comicTitle)))
        {
            AnsiConsole.MarkupLine("[red]Comic already exists[/]");
        }
        else 
        {
            var newComic = new Comic(comicTitle, comicAuthor, comicGenre, comicReview, comicScore);
            MockDatabase.Comics.Add(newComic);
            AnsiConsole.MarkupLine("[green]Comic has been successfully added[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue!");
        Console.ReadKey();

    }

    public void DeleteItem()
    {

    }
}
