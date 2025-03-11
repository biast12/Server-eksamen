using System.Text.Json;

public class LibraryService
{
    private readonly HttpClient _httpClient;

    public LibraryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Genres>?> GetGenresAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("genres");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Genres>>(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching genres: {ex.Message}");
            return null;
        }
    }

    public async Task<Genres?> GetGenreAsync(int genreID)
    {
        try
        {
            var response = await _httpClient.GetAsync($"genres/{genreID}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Genres>(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching genre: {ex.Message}");
            return null;
        }
    }

    public async Task<List<Books>?> GetBooksByGenreAsync(int genreID)
    {
        try
        {
            var response = await _httpClient.GetAsync($"books/genreID/{genreID}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Books>>(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching books: {ex.Message}");
            return null;
        }
    }
}
