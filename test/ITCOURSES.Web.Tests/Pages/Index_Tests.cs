using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ITCOURSES.Pages;

[Collection(ITCOURSESTestConsts.CollectionDefinitionName)]
public class Index_Tests : ITCOURSESWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
