using Spectre.Console;

namespace MovieApp;

class Program
{
    enum MenuChoices
    {
        AddMovie,
        ViewMovies,
        DeleteMovies,
        ExitProg,
    }
    internal static void Main(string[] args)
    {
        bool keepRunning = true;
        var moviesList = new List<string>()
        {
            "Star Wars: A New Hope", 
            "The Day After Tomorrow", 
            "Man on Fire", 
            "Avatar", 
            "Children of Men",
        };

        
        
        while (keepRunning)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuChoices>()
                    .Title("Choose your choice:")
                    .AddChoices(Enum.GetValues<MenuChoices>()));

            switch (choice)
            {
                case MenuChoices.AddMovie:
                    // add movie
                    break;
                case MenuChoices.ViewMovies:
                    // view movie
                    break;
                case MenuChoices.DeleteMovies:
                    // delete movie
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