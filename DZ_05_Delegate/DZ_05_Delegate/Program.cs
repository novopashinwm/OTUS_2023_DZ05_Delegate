using DZ_05_Delegate.Extentions;
using DZ_05_Delegate.FILES;

public class Program
{
    private async static Task Main(string[] args)
    {
        Console.WriteLine("Delegate demonstration");

        var sample = new SamplesGetMax();
        sample.Demo();
        Console.WriteLine();
        Console.WriteLine(new string('=',80));

        CancellationTokenSource cancelToken = new CancellationTokenSource();
         var fileFinder = new FileFinder(Environment.CurrentDirectory);
        fileFinder.FileFound += OnFileFound;
        Task task = new Task(() => fileFinder.IsFileExists(cancelToken.Token), cancelToken.Token);
        task.Start();

        Console.WriteLine("Press ''Q'' to cancel checking files...");

        ConsoleKey keyInfo = Console.ReadKey().Key;
        if (keyInfo == ConsoleKey.Q)
            cancelToken.Cancel();

        Console.WriteLine();
        Console.WriteLine("End of program (Wait for Task will be canceled)");

        Console.ReadKey();

        fileFinder.FileFound -= OnFileFound;
        fileFinder = null;
        cancelToken.Dispose();
    }

    static void OnFileFound(object? sender, FileArgs e)
    {
        Console.WriteLine($"[Event->OnFileFound] File found: {e.Name}");
        Console.WriteLine();
    }
}