using Problem3.Infrastructure;

public class HistoryStoreTests
{
    [Fact]
    public void InitialState_CurrentIsNull()
    {
        var store = new HistoryStore();
        Assert.Null(store.Current());
    }

    [Fact]
    public void Visit_SetsCurrent_AndClearsForward()
    {
        var store = new HistoryStore();
        store.Visit("a");
        store.Visit("b");
        store.Back();
        store.Visit("c");
        Assert.Equal("c", store.Current());
        Assert.Equal("a", store.Back());
        Assert.Equal("a", store.Back());
    }

    [Fact]
    public void Back_AtStart_ReturnsCurrent()
    {
        var store = new HistoryStore();
        store.Visit("a");
        Assert.Equal("a", store.Back());
    }

    [Fact]
    public void Forward_WithoutBack_DoesNothing()
    {
        var store = new HistoryStore();
        store.Visit("a");
        Assert.Equal("a", store.Forward());
    }

    [Fact]
    public void Forward_AfterBack_ReturnsNext()
    {
        var store = new HistoryStore();
        store.Visit("a");
        store.Visit("b");
        store.Back();
        Assert.Equal("b", store.Forward());
    }

    [Fact]
    public void Back_And_Forward_Multiple()
    {
        var store = new HistoryStore();
        store.Visit("a");
        store.Visit("b");
        store.Visit("c");
        store.Back(); // b
        store.Back(); // a
        Assert.Equal("b", store.Forward());
        Assert.Equal("c", store.Forward());
        Assert.Equal("c", store.Forward()); // stays at c
    }
}
