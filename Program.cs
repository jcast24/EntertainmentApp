using MovieApp.Views;

namespace MovieApp;

class Program
{
    internal static void Main(string[] args)
    {
        UserInterface menu = new UserInterface();
        menu.MainMenu();
    }
}