using MovieApp.Controllers;
using MovieApp.Views;
using Spectre.Console;

namespace MovieApp;

class Program
{
    internal static void Main(string[] args)
    {
        UserInterface menu = new UserInterface();
        menu.MainMenu();
    }
}