internal struct Address { }
internal struct Email { }
internal struct Phone { }


internal interface IArray<T>
{
    T[] Items { get; set; }
}



internal class Person : IArray<Address>,
    IArray<Phone>, IArray<Email>
{
    // Explicit interface implementation
    Address[] IArray<Address>.Items { get; set; }
    Email[] IArray<Email>.Items { get; set; }
    Phone[] IArray<Phone>.Items { get; set; }


    private static T[] Starter<T> ()
    {
        var person = new Person();

        // Can throw exception if Person does not implement an
        //      IArray<T> that has a T[] Items property
        (person as IArray<T>).Items = new T[5];

        return (person as IArray<T>).Items;
    }
}