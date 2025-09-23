using System.Text.Json;

namespace NetFoundy.AsynchronousProgramming;

class LibraryService(HttpClient httpClient)
{
    public async Task<List<LibratyModel>> GetLibraries()
    {
        var response = await httpClient.GetAsync("https://api.github.com/orgs/dotnet/repos");
        response.EnsureSuccessStatusCode();
        
        var stream = await response.Content.ReadAsStreamAsync();
        var libraries = await JsonSerializer.DeserializeAsync<List<LibratyModel>>(stream);
        
        return libraries ?? throw new InvalidOperationException("Failed to deserialize libraries");
    }
}

class LibratyModel
{
    public required string Name { get; set; }
}

//TODO: Create IAsyncStateMachine example