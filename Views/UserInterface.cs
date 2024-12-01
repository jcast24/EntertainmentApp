using MovieApp.Controllers;
using Spectre.Console;

namespace MovieApp.Views;

public class UserInterface
{    
    enum MenuChoices
     {
         AddMovie,
         ViewMovies,
         DeleteMovies,
         ExitProg,
     }
    internal void MainMenu()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuChoices>()
                    .Title("[cyan]Choose your choice:[/]")
                    .AddChoices(Enum.GetValues<MenuChoices>()));

            switch (choice)
            {
                case MenuChoices.AddMovie:
                    // add movie
                    MovieController.AddMovie();
                    break;
                case MenuChoices.ViewMovies:
                    // view movie
                    MovieController.ViewMovies();
                    break;
                case MenuChoices.DeleteMovies:
                    // delete movie
                    MovieController.DeleteMovie();
                    break;
                case MenuChoices.ExitProg:
                    AnsiConsole.MarkupLine("[red]Goodbye![/]");
                    keepRunning = false;
                    break;
                default:
                    AnsiConsole.MarkupLine("Choose an option!");
                    break;
            }
        } 
    }
}