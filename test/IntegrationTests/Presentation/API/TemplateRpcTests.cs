using Xunit;

namespace Presentation.API;

public class TemplateRpcTests : IClassFixture<IntegrationTestBase>
{
    private readonly IntegrationTestBase _TestBase;

    public TemplateRpcTests(IntegrationTestBase TestBase)
    {
        _TestBase = TestBase;
    }
}