namespace Generics
{
    // Definition: Generics allow us to define a class, method, or interface with a placeholder for any type.
    // They enable us type safety and reusability.

    // Why use generics ?
    // - Avoid code duplication
    // - Catch type errors at compile-time
    // - We don't sacrifice performance

    // Built-in Generic Types in .NET
    // - List<T>
    // - Dictionary<TKey, TValue>
    // - Nullable<T>
    // - Task<T>
    // - IEnumerable<T>
    // - INumber<T> (not common)

    // Common constraints
    // - class
    // - struct
    // - new()
    // - <BaseClass>
    // - <Interaface>
    // - notnull
    public class Program
    {
        public static void Main()
        {
            // var number  = new List<int>(); // list is a generic class
            var intBox = new Box<int> { Value = 1 };
            var stringBox = new Box<string> { Value = "Hello" };

            var printer = new Printer();
            int number = 3;
            printer.PrintItem<int>(number);
            printer.PrintItem<decimal>(1);

            TestClass testClass = null!;
            var safeBox = new SafeBox<TestClass>(testClass);

            // var test = new Creator<IConfigurable>(); it gives error
            var test = new Creator<TestClass>();
        }
    }

    public class TestClass : IConfigurable
    {
        public TestClass() { }

        public TestClass(int param1)
        {
        }

        public void Configure()
        {
            throw new NotImplementedException();
        }
    }
}