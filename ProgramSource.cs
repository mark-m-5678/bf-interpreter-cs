namespace bf_interpreter;

internal class ProgramSource
{
    internal ProgramSource(string source)
    {
        this.SrcString = source;

        this.ParseSourceString();
    }

    public List<Token> Tokens { get; } = [];

    public bool Initialized { get; private set; } = false;

    public string SrcString { get; }

    private void ParseSourceString()
    {
        try
        {
            foreach (var character in this.SrcString.ToCharArray())
            {
                this.Tokens.Add(CharToToken(character));
            }

            this.Initialized = true;
        }
        catch (InvalidDataException) 
        {
            Console.WriteLine($"Source contains an invalid character.");
        }
    }

    public static Token CharToToken(char input) => input switch
    {
        '>' => new Token(TokenType.MvRight),
        '<' => new Token(TokenType.MvLeft),
        '+' => new Token(TokenType.Increment),
        '-' => new Token(TokenType.Decrement),
        _ => throw new InvalidDataException(),
    };

}
