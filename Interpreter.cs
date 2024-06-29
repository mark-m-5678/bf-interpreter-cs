namespace bf_interpreter;

internal class Interpreter
{
    internal Interpreter(int initialMemory) 
    {
        this.ProgramMemory = new Memory(initialMemory);
        this.State = InterpreterState.Idle;
        this.IsRunning = false;
    }

    internal InterpreterState State { get; private set; }

    internal bool IsRunning { get; private set; }

    internal ProgramSource? Source { get; private set; }

    internal Memory ProgramMemory { get; private set; }

    internal int ProgramPointer { get; private set; } = 0;

    internal int InstructionPointer { get; private set; } = 0;

    public void LoadSource(string src)
    {
        if (this.State != InterpreterState.Idle) return;
        
        this.Source = new ProgramSource(src);

        if (this.Source != null && this.Source.Initialized)
        {
            this.State = InterpreterState.Ready;
        }
    }

    public void Start()
    {
        if (this.IsRunning || this.State != InterpreterState.Ready || this.Source == null || !this.Source.Initialized) return;

        this.State = InterpreterState.Running;
        this.IsRunning = true;

        while (this.IsRunning)
        {
            this.Tick();
        }
    }

    public void Finished()
    {
        this.State = InterpreterState.Finished;
        this.IsRunning = false;
        this.PrintMemory();
    }

    public void Tick()
    {
        this.ExecuteNext();
    }

    public void PrintMemory() => this.ProgramMemory.Print();

    private void ExecuteNext()
    {
        if (this.InstructionPointer >= this.Source?.Tokens.Count)
        {
            this.Finished();
            return;
        }

        var token = this.Source?.Tokens[this.InstructionPointer];

        if (token == null)
        {
            this.Finished();
            return;
        }

        switch (token.Type)
        {
            case TokenType.Increment:
                // Incrememnt current cell
                this.ProgramMemory.Increment(this.ProgramPointer);
                break;

            case TokenType.Decrement:
                // Decrement current cell
                this.ProgramMemory.Decrement(this.ProgramPointer);
                break;

            case TokenType.MvRight:
                // Move ProgramPointer right
                this.ProgramPointer++;
                break;

            case TokenType.MvLeft:
                // Move ProgramPointer left
                this.ProgramPointer--;
                break;
        }

        this.InstructionPointer++;
    }
}