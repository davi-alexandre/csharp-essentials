using System;
using System.Collections;
using System.Collections.Generic;

public class EntityBase
{
    public virtual void Print()
    {
        Console.WriteLine("BASE");
    }
}
public class EntityExtension : EntityBase
{
    public override void Print()
    {
        Console.WriteLine("EXTENSION");
    }
}


// The constraint to TValue will work for 
// EntityExtension and EntityBase
public class EntityDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    where TKey : IComparable<TKey>, IFormattable
    where TValue : EntityBase    // A class can only inherit from only one other
{

}