namespace MovieApp.Models;

internal class TVShow
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Score { get; set; }

    public TVShow(string title, string genre, int score)
    {
        Title = title;
        Genre = genre;
        Score = score;
    }
}
