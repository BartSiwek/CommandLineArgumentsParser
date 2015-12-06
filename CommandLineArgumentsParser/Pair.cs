using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CommandLineArgumentsParser
{
    struct Pair<V1, V2>
    {
        public readonly V1 First;
        public readonly V2 Second;

        public Pair(V1 first, V2 second)
        {
            this.First = first;
            this.Second = second;
        }
    }
}
