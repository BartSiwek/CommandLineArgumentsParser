using System;
using System.Collections.Generic;
using System.Text;

namespace CommandLineArgumentsParser
{
    public interface ICommandLineTokenParser
    {
        object Parse(string[] values);
        int TokensRequired
        {
            get;
        }
    }
}
