using System;
using System.Collections.Generic;

namespace Two.Generics.Type_Constraints
{
    // This could be instead a class, as a constraint of EntityDictionary
    //      with a constructor that sets the Key property up
    // This class would be extended by others that work on EntityDictionary
    interface IEntity<TKey>
    {
        TKey Key { get; set; }
    }
    interface IFactory<TKey, TValue>
    {
        TValue NewValue(TKey Key);
    }
    
    class EntityDictionary<TKey, TValue, TFactory> : Dictionary<TKey, TValue>
        where TValue : IEntity<TKey>
        where TFactory : IFactory<TKey, TValue>, new()
    {
        public TValue New (TKey key)
        {
            var factory = new TFactory();
            var value = factory.NewValue(key);
            Add(value.Key, value);
            return value;
        }
    }
    
    class Entity : IEntity<int>
    {
        public Entity (int key)
        {
            Key = key;
        }

        #region IEntity Implementation
        public int Key { get; set; }
        #endregion
    }
    class EntityFactory : IFactory<int, Entity>
    {
        public Entity NewValue(int key)
            => new Entity(key);
    }



    class Test
    {
        static void main()
        {
            var dic = new EntityDictionary<int, Entity, EntityFactory>();
            dic.New(22);

            Console.WriteLine(dic.Count);
            foreach (var item in dic)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}