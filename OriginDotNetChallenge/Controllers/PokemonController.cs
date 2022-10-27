using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace OriginDotNetChallenge.Controllers;

[ApiController]
[Route("pokemon")]
public class PokemonController : ControllerBase
{
    public readonly HttpClient _client;

    public PokemonController(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<IActionResult> Get(int page = 1)
    {
        _client.BaseAddress = new Uri("https://pokeapi.co/api/");
        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("origin-user", 
                "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTY2MjA0MjMzNCwiaWF0IjoxNjYyMDQyMzM0fQ.xi3uKpbHXXxE5iTOkDrkHJfpXQhGQGjLHXwC1SE-kFI");
        var response = await _client.GetAsync(BuildGetUrl(page));

        var result = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        var deserializedObject = JsonSerializer.Deserialize<PokeApiResponse>(result, options);
        

        return Ok(deserializedObject?.Results);
    }

    public string BuildGetUrl(int page)
    {
        var limit = 20;
        var offset = page - 1;
        
        return $"v2/pokemon?offset={offset}&limit={limit}";
    }
    
}

public class PokeApiResponse
{
    public List<PokemonDTO> Results { get; set; }
}

public class PokemonDTO
{
    public string Name { get; set; }
    public string Url { get; set; }
}