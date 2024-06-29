namespace bf_interpreter;

internal class DataCell
{
    internal DataCell(int value)
    {
        this.Value = value;
    }

    internal int Value { get; set; }

    internal void Increment()
    {
        this.Value += 1;
    }

    internal void Decrement()
    {
        this.Value -= 1;
    }
}
