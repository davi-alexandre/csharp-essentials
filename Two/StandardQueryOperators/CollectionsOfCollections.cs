using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two.Collection_Interfaces.StandardQueryOperators
{
    class CollectionsOfCollections
    {
        public static void Start()
        {
            SelMany();
        }

        static void SelMany()
        {
            #region Data
            var worldCup2006Finalists = new[]
            {
                new
                {
                    TeamName = "France",
                    Players = new string[]
                    {
                    "Fabien Barthez", "Gregory Coupet",
                    "Mickael Landreau", "Eric Abidal",
                    "Jean-Alain Boumsong", "Pascal Chimbonda",
                    "William Gallas", "Gael Givet",
                    "Willy Sagnol", "Mikael Silvestre",
                    "Lilian Thuram", "Vikash Dhorasoo",
                    "Alou Diarra", "Claude Makelele",
                    "Florent Malouda", "Patrick Vieira",
                    "Zinedine Zidane", "Djibril Cisse",
                    "Thierry Henry", "Franck Ribery",
                    "Louis Saha", "David Trezeguet",
                    "Sylvain Wiltord",
                    }
                },
                new
                {
                    TeamName = "Italy",
                    Players = new string[]
                    {
                    "Gianluigi Buffon", "Angelo Peruzzi",
                    "Marco Amelia", "Cristian Zaccardo",
                    "Alessandro Nesta", "Gianluca Zambrotta",
                    "Fabio Cannavaro", "Marco Materazzi",
                    "Fabio Grosso", "Massimo Oddo",
                    "Andrea Barzagli", "Andrea Pirlo",
                    "Gennaro Gattuso", "Daniele De Rossi",
                    "Mauro Camoranesi", "Simone Perrotta",
                    "Simone Barone", "Luca Toni",
                    "Alessandro Del Piero", "Francesco Totti",
                    "Alberto Gilardino", "Filippo Inzaghi",
                    "Vincenzo Iaquinta",
                    }
                }
            };
            #endregion

            // SelectMany() iterates across each item identified by the
            //      lambda expression (the array selected by Select() earlier) 
            //      and hoists out each item into a new collection that includes
            //      a union of all items within the child collection.
            //  Instead of two arrays of players, SelectMany() combines
            //      each array selected and produces a single collection of all items.
            //
            IEnumerable <string> players = worldCup2006Finalists.
                SelectMany(team => team.Players);
            //
            // Select() would return two items, one for each
            //      team in the original collection. 
            // Select() may project out a transform from the original type,
            //      but the number of items would not change.
            //              For example, teams.Select(team => team.Players)
            //              will return an IEnumerable<string[]>


            foreach (string player in players)
                Console.WriteLine(player);
        }
    }
}
