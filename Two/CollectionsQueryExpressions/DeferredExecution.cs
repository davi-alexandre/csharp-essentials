using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;

namespace Two.CollectionsQueryExpressions
{
    class DeferredExecution
    {
        public static void Start()
        {
            CountContextualKeywords();
        }

        #region Simple
        private static void ShowContextualKeywords()
        {
            var selection =
                from word in Keywords
                where !word.Contains('*')
                where word.StartsWith("a")
                select new
                {
                    Identifier = word,
                    Length = word.Length
                };

            foreach (var keyword in selection)
                Write(keyword + " - ");
        }
        #endregion

        #region Example 2
        private static void CountContextualKeywords()
        {
            int delegateInvocations = 0;
            Func<string, string> func = text =>
            {
                delegateInvocations++; // side effect -> bad code (used for demonstration)
                return text;
            };

            IEnumerable<string> selection =
                from keyword in Keywords
                where keyword.Contains('*')
                select func(keyword);


            WriteLine($"\t>> delegateInvocations = { delegateInvocations }\n");

            // Executing count should invoke func once for each item selected.
            //
            WriteLine($"1. Contextual keyword count = { selection.Count() }");
            WriteLine($"\t>> delegateInvocations = { delegateInvocations }\n");

            // Executing count should invoke func once for each item selected.
            //
            WriteLine($"2. Contextual keyword count = { selection.Count() }");
            WriteLine($"\t>> delegateInvocations = { delegateInvocations }\n");

            // Cache the value so future counts will not trigger
            // another invocation of the query.
            //
            List<string> selectionCache = selection.ToList();
            WriteLine("3. Selection to list");
            WriteLine($"\t>> delegateInvocations = { delegateInvocations }\n");

            // Retrieve the count from the cached collection.
            //
            WriteLine($"4. Cached collection count = { selectionCache.Count() }");
            WriteLine($"\t>> delegateInvocations = { delegateInvocations }");
        }
        #endregion

 

        #region Data
        public static string[] Keywords = {
            "abstract", "add*", "alias*", "as", "ascending*",
            "async*", "await*", "base","bool", "break",
            "by*", "byte", "case", "catch", "char", "checked",
            "class", "const", "continue", "decimal", "default",
            "delegate", "descending*", "do", "double",
            "dynamic*", "else", "enum", "event", "equals*",
            "explicit", "extern", "false", "finally", "fixed",
            "from*", "float", "for", "foreach", "get*", "global*",
            "group*", "goto", "if", "implicit", "in", "int",
            "into*", "interface", "internal", "is", "lock", "long",
            "join*", "let*", "nameof*", "namespace", "new", "null",
            "object", "on*", "operator", "orderby*", "out",
            "override", "params", "partial*", "private", "protected",
            "public", "readonly", "ref", "remove*", "return", "sbyte",
            "sealed", "select*", "set*", "short", "sizeof",
            "stackalloc", "static", "string", "struct", "switch",
            "this", "throw", "true", "try", "typeof", "uint", "ulong",
            "unsafe", "ushort", "using", "value*", "var*", "virtual",
            "unchecked", "void", "volatile", "where*", "while", "yield*"};
        #endregion
    }
}
