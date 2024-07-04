using System.Net;

namespace WrapAround.AppHost.Tests.Integration;

// TODO: Can/should a test container be used for the db?
public class WebTests
{
    [Fact]
    public async Task GetWebResourceRootReturnsOkStatusCode()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.WrapAround_Web>();

        await using var app = await appHost.BuildAsync();
        await app.StartAsync();

        // Act
        var httpClient = app.CreateHttpClient("wraparound-web");
        var response = await httpClient.GetAsync("/");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
