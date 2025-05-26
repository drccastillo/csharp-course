using Problem2.Domain.Models;

public class PrintJobTests
{
    [Fact]
    public void PrintJob_StoresJobId()
    {
        var job = new PrintJob("J1");
        Assert.Equal("J1", job.JobId);
    }

    [Fact]
    public void PrintJob_Equality_Works()
    {
        var j1 = new PrintJob("A");
        var j2 = new PrintJob("A");
        var j3 = new PrintJob("B");
        Assert.Equal(j1, j2);
        Assert.NotEqual(j1, j3);
    }

    [Fact]
    public void PrintJob_ToString_ContainsJobId()
    {
        var job = new PrintJob("Z");
        Assert.Contains("Z", job.ToString());
    }
}
