namespace bf_interpreter;

internal class Program
{
    static void Main(string[] args)
    {

        // Specify initial memory size here
        // TODO: Dynamic ???
        var bfInterpreter = new Interpreter(10);

        // Enter BF Source Code here.
        // TODO: Read from a file maybe?
        bfInterpreter.LoadSource("+>++>+<<-");

        Console.WriteLine("Starting program!");

        bfInterpreter.Start();

        Console.WriteLine("Done! Huzzah!");
    }
}
