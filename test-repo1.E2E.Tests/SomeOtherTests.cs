using Xunit;

namespace test_repo1.E2E.Tests;

public class SomeOtherTests
{
    [Fact]
    public void TestPass()
    {
        Assert.True(true);
    }
    
    [Fact]
    public void TestFail()
    {
        Assert.True(false);
    }
    
    [Fact]
    public void TestSkip()
    {
        Assert.True(true);
    }
}