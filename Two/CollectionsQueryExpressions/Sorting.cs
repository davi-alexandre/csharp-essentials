using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using static System.Console;

namespace Two.CollectionsQueryExpressions
{
    class Sorting
    {
        public static void Start ()
        {
            ListMemberNames();
        }


        #region DISTINCT() and query expressions (contains reflection code)
        public static void ListMemberNames()
        {
            // To apply a query operator to a query expression, the expression must be
            //      enclosed in parentheses so that the compiler does not think that the
            //      call to Distinct() is a part of the select clause.
            //
            IEnumerable<string> enumerableMethodNames = (
                from method in typeof(Enumerable).GetMembers(BindingFlags.Static | BindingFlags.Public)
                orderby method.Name
                select method.Name).
                Distinct();
            //
            // Many of these members are overloaded, sometimes more than once.
            // Rather than displaying the same member multiple times, Distinct()
            //      is called from the query expression.This eliminates the 
            //      duplicate names from the list.

            foreach (string method in enumerableMethodNames)
                Write($"{ method }, ");
        }
        #endregion

        #region FlatteningSequencesOfSequences (MULTI FROM CLAUSES)
        // It is often desirable to “flatten” a sequence of sequences into a single sequence.
        // For example, each member of a sequence of customers might ave an associated
        //      sequence of orders, or each member of a sequence of directories might have
        //      an associated sequence of files.
        // The SelectMany sequence  operator concatenates together all the subsequences; to
        // do the same thing with query expression syntax, you can use multiple from clauses
        //
        static void FlatteningSequencesOfSequences ()
        {
            var selection =
                from word in new string[] { "Davi", "Alexandre" }
                from character in word
                select character;

            var numbers = new[] { 1, 2, 3 };
            var words = new[] { "Word", "Another" };
            var cartesianProduct =
                from word in words
                from number in numbers
                select new { word, number } // flattening
                into type
                orderby type.number descending
                group type by type.word
                into currentGroup
                select new
                {
                    GroupName = currentGroup.Key,
                    Items = currentGroup.ToArray()
                };


            foreach (var currentGroup in cartesianProduct)
            {
                WriteLine(currentGroup.GroupName);
                foreach(var item in currentGroup.Items)
                    WriteLine(item);
            }
                
        }
        #endregion


        #region QueryContinuation (INTO)
        static void QueryContinuation ()
        {
            var selection =
                from word in DeferredExecution.Keywords
                group word by word.Contains('*')
                into conclusion
                select new
                {
                    IsOfContextualKeyword = conclusion.Key,
                    Items = conclusion.ToArray()
                };

            foreach (var group in selection)
            {
                WriteLine(group.IsOfContextualKeyword ?
                    $"Contextual Keywords ({group.Items.Length}):\n" :
                    $"Keywords ({group.Items.Length}):\n");
                foreach (string word in group.Items)
                {
                    Write(word + " - ");
                }
            }
        }
        #endregion


        #region Grouping
        static void GroupKeywords()
        {
            IEnumerable<IGrouping<bool, string>> keywordGroups =
                from word in DeferredExecution.Keywords
                group word by word.Contains('*'); // by [group key]

            var selection =
                from singleGroup in keywordGroups
                select new // cached to anonymous type
                {
                    IsOfContextualKeywords = singleGroup.Key,
                    Items = singleGroup.ToArray(),
                    Length = singleGroup.Count()
                };


            foreach (var wordGroup in selection)
            {
                WriteLine("\n{0} ({1}):", wordGroup.IsOfContextualKeywords ?
                    "Contextual Keywords" : "Keywords", wordGroup.Length);

                foreach (var keyword in wordGroup.Items)
                    Write(" " + keyword.Replace("*", null));
            }
        }
        #endregion


        #region OrderBy
        static void OrderByFileSize (string directory, string searchPattern)
        {
            IEnumerable<FileInfo> FileInfoCollection =
                GetOrderedFilesWithLet(directory, searchPattern);

            long spacing = FileInfoCollection.Select(file => file.Name.Length).Max();
            spacing += 10;

            foreach (FileInfo fileInfo in FileInfoCollection)
                WriteLine(Hold(0, spacing) + " | {1}", 
                    fileInfo.Name, fileInfo.Length+" bytes");
        }

        
        static IEnumerable<FileInfo> GetOrderedFilesWithLet(string directory, string searchPattern)
        {
            // You can add as many let clauses as you like; simply add each as an
            //      additional clause to the query after the first from clause but
            //      before the final select / group by clause.
            //
            IEnumerable<FileInfo> files =
                from filepath in Directory.EnumerateFiles(directory, searchPattern)
                let file = new FileInfo(filepath)   // declares another range variable
                orderby file.Length descending, file.Name
                select file;

            return files;
        }
        static IEnumerable<FileInfo> GetOrderedFilesWithoutLet (string directory, string searchPattern)
        {
            // Instantiating a new FileInfo twice for each item in the source 
            // collection is redundant (use the let clause)
            //
            IEnumerable<FileInfo> resultCollection =
                from filename in Directory.EnumerateFiles(directory, searchPattern)
                orderby (new FileInfo(filename)).Length descending, filename // orderby-thenby
                select new FileInfo(filename);  // Length gets the file's size

            return resultCollection;
        }
        #endregion


        #region Milionarios Conterraneos
        class Conta
        {
            public int numero = 0;
            public string titulo = "";
            public decimal saldo = 0M;
            public string endereco = "";
        }
        static void MilionariosConterraneos()
        {
            IEnumerable<Conta> MilharesDeContasNoBanco = new Conta[1];

            var gruposDeMilionariosDaMesmaCidade =
                from conta in MilharesDeContasNoBanco
                where conta.saldo >= 1000000
                group conta by conta.endereco
                into grupoResultante
                select new // transforme o grupo numa forma mais organizada
                {
                    NomeDaCidade = grupoResultante.Key,
                    MilionariosConterraneos = grupoResultante.ToArray()
                };


            Conta contaDoDavi = new Conta();

            foreach (var grupo in gruposDeMilionariosDaMesmaCidade)
                foreach (Conta milionario in grupo.MilionariosConterraneos)
                {
                    contaDoDavi.saldo += milionario.saldo;
                    milionario.saldo = 0;
                }
        }
        #endregion



        static string Hold(int position, long spacing)
            => "{" + position + ", " + spacing + "}";
    }
}
