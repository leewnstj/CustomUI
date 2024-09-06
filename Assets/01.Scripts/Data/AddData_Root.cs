public abstract class AddData_Root
{
    public int Value { get; private set; }

    public virtual void AddValue(int value = 1)
    {
        Value += value;
    }

    public virtual void RemoveValue(int value = 1)
    {
        Value -= value;
    }
}