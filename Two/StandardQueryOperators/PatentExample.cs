using System;
using System.Collections.Generic;
using System.Linq;

namespace Two.Collection_Interfaces.StandardQueryOperators
{
    public class Patent
    {
        public string Title { get; set; }
        public string YearOfPublication { get; set; }
        public string ApplicationNumber { get; set; } // A unique number assigned to published applications
        public long[] InventorIds { get; set; }
        public override string ToString()
            => $"{ Title } ({ YearOfPublication })";
    }

    public class Inventor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public override string ToString()
            => $"{ Name } ({ City }, { State })";
    }

    public class ProgramInit
    {
        public static void FilterSelect()
        {
            IEnumerable<Patent> patentsOf1800 = PatentData.Patents;
            int numOfEighteen = patentsOf1800.Count(patent => patent.YearOfPublication.StartsWith("18"));
            Console.WriteLine(numOfEighteen);

            patentsOf1800 = patentsOf1800.Where // Where() => filtering
                (patent => patent.YearOfPublication.StartsWith("18"));


            // return a collection converted to string
            IEnumerable<string> transformedCollection = patentsOf1800.Select // Select() => projection
                (patent => patent.ToString());


            Print(transformedCollection);
        }

        public static void OrderThenBy()
        {
            IEnumerable<Patent> items;
            Patent[] patents = PatentData.Patents;

            // Calling OrderBy() again would undo the 
            // work done by the first call
            // Use ThenBy() to add aditional sorting criteria
            items = patents.OrderBy(
                patent => patent.YearOfPublication).ThenBy(
                patent => patent.Title);
            Print(items);

            Console.WriteLine();

            items = patents.OrderByDescending(
                patent => patent.YearOfPublication).ThenByDescending(
                patent => patent.Title);
            Print(items);

            /*
            First, 
                the actual sort doesn’t occur until you begin to access the  members
                in the collection, at which point the entire query is processed.
                (due to deferred execution)
            
            Second,
                each subsequent call to sort the data (Orderby() followed by ThenBy() followed
                by ThenByDescending(), for example) does involve additional calls
                to the keySelector lambda expression of the earlier sorting calls
                    In other words, a call to OrderBy() will call its corresponding keySelector lambda
                    expression once you iterate over the collection. Furthermore, a subsequent
                    call to ThenBy() will again make calls to OrderBy()’s keySelector.
            */
        }

        public static void Print<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
                Console.WriteLine(item);
        }
    }

    public static class PatentData
    {
        public static readonly Inventor[] Inventors = new Inventor[]
        {
            new Inventor(){
                Name="Benjamin Franklin", City="Philadelphia",
                State="PA", Country="USA", Id=1 },
            new Inventor(){
                Name="Orville Wright", City="Kitty Hawk",
                State="NC", Country="USA", Id=2},
            new Inventor(){
                Name="Wilbur Wright", City="Kitty Hawk",
                State="NC", Country="USA", Id=3},
            new Inventor(){
                Name="Samuel Morse", City="New York",
                State="NY", Country="USA", Id=4},
            new Inventor(){
                Name="George Stephenson", City="Wylam",
                State="Northumberland", Country="UK", Id=5},
            new Inventor(){
                Name="John Michaelis", City="Chicago",
                State="IL", Country="USA", Id=6},
            new Inventor(){
                Name="Mary Phelps Jacob", City="New York",
                State="NY", Country="USA", Id=7},
        };

        public static readonly Patent[] Patents = new Patent[]
        {
            new Patent(){
                Title="Bifocals", YearOfPublication="1784",
                InventorIds=new long[] {1}},
            new Patent(){
                Title="Phonograph", YearOfPublication="1877",
                InventorIds=new long[] {1}},
            new Patent(){
                Title="Kinetoscope", YearOfPublication="1888",
                InventorIds=new long[] {1}},
            new Patent(){
                Title="Electrical Telegraph",
                YearOfPublication ="1837",
                InventorIds=new long[] {4}},
            new Patent(){
                Title="Flying Machine", YearOfPublication="1903",
                InventorIds=new long[] {2,3}},
            new Patent(){
                Title="Steam Locomotive", YearOfPublication="1815",
                InventorIds=new long[] {5}},
            new Patent(){
                Title="Droplet Deposition Apparatus",
                YearOfPublication ="1989",
                InventorIds=new long[] {6}},
            new Patent(){
                Title="Backless Brassiere",
                YearOfPublication="1914",
                InventorIds=new long[] {7}},
        };
    }
}