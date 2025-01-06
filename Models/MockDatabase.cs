namespace MovieApp.Models;

public class MockDatabase
{

   internal static List<Movie> Movies = new List<Movie>()
   {
       new Movie("Star Wars: A New Hope", "Sci-fi", 10),
       new Movie("The Day After Tomorrow", "Sci-fi", 8),
       new Movie("Man on Fire", "Action", 8),
       new Movie("Avatar", "Sci-fi", 9),
   };

   internal static List<Comic> Comics = new List<Comic>(){
       new Comic("Daredevil", "Superhero", "Zdarsky", "Love Daredevil", 10 )
   };
}
