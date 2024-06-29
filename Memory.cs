namespace bf_interpreter;

internal class Memory
{
    public static int MAX_SIZE = 30000;

    private readonly List<DataCell> mCells;

    internal Memory(int initialSize)
    {
        mCells = new List<DataCell>();

        for (int i = 0; i < initialSize; i++)
        {
            mCells.Add(new DataCell(0));
        }
    }

    internal void Increment(int i)
    {
        if (i >= mCells.Count) return;
        mCells[i].Increment();
    }

    internal void Decrement(int i)
    {
        if (i >= mCells.Count) return;
        mCells[i].Decrement();
    }

    internal void Print()
    {
        foreach (var cell in mCells)
        {
            Console.Write($"{cell.Value}|");
        }

        Console.Write("\n");
    }
}
