public class Library
{
    public Items[]? Items { get; set; }
    public Genres[]? Genres { get; set; }
    public Categories[]? Categories { get; set; }
}

public class Items
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public int genreID { get; set; }
    public string? categoryID { get; set; }
}

public class Genres
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? bgColor { get; set; }
}

public class Categories
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? icon { get; set; }
}

