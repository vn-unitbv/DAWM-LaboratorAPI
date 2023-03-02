using System.Runtime.CompilerServices;
using static TestDrive.DelegateExamples;

namespace TestDrive;

public class Program
{
    public const int number = 10;
    /*
     * string result;

        var delegateExamples = new DelegateExamples();
        var myDelegate = new MyMethodDelegate(delegateExamples.MyMethod);

        result = myDelegate(number);
        Console.WriteLine(result);

        myDelegate = delegateExamples.MySecondMethod;

        result = myDelegate(number);
        Console.WriteLine(result);
     */
    public static void Main(string[] args)
    {
        // IEnumerable

        List<string> strings = new List<string>() { "a", "b", "c", "d", "e"};

        var result = strings.ParseList();

    }
}

public static class ExtensionMethods
{
    public static IEnumerable<string> ParseList(this List<string> strings)
    {
        return strings
            .Where(x => x != "a")
            .Where(x => x != "b")
            .Where(x => x != "c")
            .Select(x => x + "_")
            .Select(x => x.ToUpper())
            .OrderByDescending(x => x);
    }
}