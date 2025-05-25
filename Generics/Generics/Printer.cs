namespace Generics
{
    public class Printer
    {
        // A method that accepts a generic type parameter.
        public void PrintItem<U>(U item) where U : struct
        {
            Console.WriteLine(item.ToString());
        }

        // Use default(T) to assign the default value for a type
        public T GetOrDefault<T>(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default) ? default : value;
        }
    }
}
