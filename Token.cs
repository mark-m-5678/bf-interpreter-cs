namespace bf_interpreter;

internal class Token
{
    internal Token(TokenType type)
    {
        this.Type = type;
    }

    internal TokenType Type { get; }

    public string String()
    {
        return this.Type.ToString();
    }
}
