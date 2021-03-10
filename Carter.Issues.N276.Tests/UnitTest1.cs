using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Carter.Issues.N276.Tests
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task Test1()
        {
            var client = _factory.CreateClient();
            var result = await client.GetAsync("/actors?Id=1&Id=3");
            var str = await result.Content.ReadAsStringAsync();
            var array = JsonConvert.DeserializeObject<dynamic[]>(str);

            Assert.Equal(2, array.Length);
        }
    }
}
