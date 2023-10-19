using System.Collections.Generic;

public class ObjectPool<T>
{
    public int Capacity;
    public List<T> Items = new List<T>();

    public ObjectPool(int capacity)
    {
        Capacity = capacity;
    }
    
}
