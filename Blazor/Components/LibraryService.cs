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

    public async Task<List<Items>?> GetItemsByCategoryAndGenreAsync(int categoryID, int genreID)
    {
        try
        {
            var response = await _httpClient.GetAsync($"items/category/{categoryID}/genre/{genreID}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Items>>(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching items by category and genre: {ex.Message}");
            return null;
        }
    }

    public async Task<List<Items>?> GetItemsByGenreAsync(int genreID)
    {
        try
        {
            var response = await _httpClient.GetAsync($"items/genreID/{genreID}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Items>>(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching items: {ex.Message}");
            return null;
        }
    }

    public async Task<List<Categories>?> GetCategoriesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("categories");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Categories>>(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching categories: {ex.Message}");
            return null;
        }
    }

    public async Task<Categories?> GetCategoryAsync(int categoryID)
    {
        try
        {
            var response = await _httpClient.GetAsync($"categories/{categoryID}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Categories>(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching category: {ex.Message}");
            return null;
        }
    }

    public async Task<List<Items>?> GetItemsByCategoryAsync(int categoryID)
    {
        try
        {
            var response = await _httpClient.GetAsync($"items/categoryID/{categoryID}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Items>>(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching items by category: {ex.Message}");
            return null;
        }
    }
}
