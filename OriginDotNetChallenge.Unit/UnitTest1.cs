using OriginDotNetChallenge.Controllers;

namespace OriginDotNetChallenge.Unit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var controller = new PokemonController(new HttpClient());
        var expectedUrl = "v2/pokemon?offset=0&limit=20";

        var actualUrl = controller.BuildGetUrl(1);
        
        Assert.Equal(expectedUrl, actualUrl);
    }
    
    [Fact]
    public void Test2()
    {
        var controller = new PokemonController(new HttpClient());
        var expectedUrl = "v2/pokemon?offset=20&limit=20";

        var actualUrl = controller.BuildGetUrl(2);
        
        Assert.Equal(expectedUrl, actualUrl);
    }
}