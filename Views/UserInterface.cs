using MovieApp.Controllers;
using Spectre.Console;

namespace MovieApp.Views;

public class UserInterface
{    
    internal void MainMenu()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuChoiceEnum>()
                    .Title("[cyan]Choose your choice:[/]")
                    .AddChoices(Enum.GetValues<MenuChoiceEnum>()));

            switch (choice)
            {
                case MenuChoiceEnum.AddMovie:
                    // add movie
                    MovieController.AddMovie();
                    break;
                case MenuChoiceEnum.ViewMovies:
                    // view movie
                    MovieController.ViewMovies();
                    break;
                case MenuChoiceEnum.DeleteMovies:
                    // delete movie
                    MovieController.DeleteMovie();
                    break;
                case MenuChoiceEnum.ExitProg:
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