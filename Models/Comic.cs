namespace MovieApp.Models;

internal class Comic {
    public string Title {get; set;}
    public string Genre {get; set;}
    public string Author {get; set;}
    public string Review {get; set;}
    public int Score {get; set;}

    public Comic(string title, string genre, string author, string review, int score) {
        Title = title;
        Genre = genre;
        Author = author;
        Review = review;
        Score = score;
    }

}
