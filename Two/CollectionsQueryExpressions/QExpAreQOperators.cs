using System;
using System.Collections.Generic;
using System.Linq;

namespace Two.CollectionsQueryExpressions
{
    class QExpAreQOperators
    {
        IEnumerable<string> QueryExpression =
            from word in DeferredExecution.Keywords
            where word.Contains('*')
            select word;
        //
        //  Translates to
        //
        IEnumerable<string> StandardQueryOperators = 
            DeferredExecution.Keywords.Where(word => word.Contains('*'));
    }
}
