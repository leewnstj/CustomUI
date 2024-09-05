public abstract class Data_Root
{
    public int ResourceValue { get; private set; }

    public virtual void AddValue(int value = 1)
    {
        ResourceValue += value;
    }

    public virtual void RemoveValue(int value = 1)
    {
        ResourceValue -= value;
    }
}