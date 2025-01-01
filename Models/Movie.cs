namespace MovieApp.Models;

internal class Movie
{
    public string Title { get; set; }
    public string Genre { get; set; } 
    public int Score { get; set; } 

    public Movie(string title, string genre, int score)
    {
        Title = title;
        Genre = genre;
        Score = score;
    }
}
