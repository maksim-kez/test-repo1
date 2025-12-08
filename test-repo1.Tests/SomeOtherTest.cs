using Xunit;

namespace test_repo1.Tests;

public class SomeOtherTest
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
