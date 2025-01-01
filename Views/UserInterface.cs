using MovieApp.Controllers;
using Spectre.Console;

namespace MovieApp.Views;

public class UserInterface
{
    private MovieController _movieController = new MovieController();
    private ComicController _comicController = new ComicController();

    internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            var actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.MenuChoiceEnum>()
                    .Title("What do you want to do next?")
                    .AddChoices(Enum.GetValues<Enums.MenuChoiceEnum>())
            );

            var itemTypeChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.ItemType>()
                    .Title("Select the type of item:")
                    .AddChoices(Enum.GetValues<Enums.ItemType>())
            );

            switch(actionChoice) 
            {
                case Enums.MenuChoiceEnum.ViewItems:
                    ViewItems(itemTypeChoice);
                    break;
                case Enums.MenuChoiceEnum.AddItem:
                    AddItem(itemTypeChoice);
                    break;
                case Enums.MenuChoiceEnum.DeleteItems:
                    DeleteItem(itemTypeChoice);
                    break;
            }
        }
    }

    private void ViewItems(Enums.ItemType itemType)
    {
        switch(itemType)
        {
            case Enums.ItemType.Comic:
                _comicController.ViewItems();
                break;
            case Enums.ItemType.Movie:
                _movieController.ViewItems();
                break;
        }
    }

    private void AddItem(Enums.ItemType itemType)
    {
        switch(itemType)
        {
            case Enums.ItemType.Comic:
                _comicController.AddItem();
                break;
            case Enums.ItemType.Movie:
                _movieController.AddItem();
                break;
        }
    }

    private void DeleteItem(Enums.ItemType itemType)
    {
        switch(itemType)
        {
            case Enums.ItemType.Comic:
                _comicController.DeleteItem();
                break;
            case Enums.ItemType.Movie:
                _movieController.DeleteItem();
                break;
        }
    }

}
