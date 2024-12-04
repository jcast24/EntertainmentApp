using MovieApp.Controllers;
using Spectre.Console;

namespace MovieApp.Views;

public class UserInterface
{
    private MovieController _movieController = new MovieController();
    
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
                    _movieController.AddMovie();
                    break;
                case MenuChoiceEnum.ViewMovies:
                    // view movie
                    _movieController.ViewMovies();
                    break;
                case MenuChoiceEnum.DeleteMovies:
                    // delete movie
                    _movieController.DeleteMovie();
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