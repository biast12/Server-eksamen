public class Library
{
    public Books[]? Books { get; set; }
    public Genres[]? Genres { get; set; }
}

public class Books
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? genreID { get; set; }
}

public class Genres
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? bgColor { get; set; }
}

