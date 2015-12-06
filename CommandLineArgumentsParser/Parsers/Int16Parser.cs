using System;
using System.Collections.Generic;
using System.Text;

namespace CommandLineArgumentsParser.Parsers
{
    public class Int16Parser : ICommandLineTokenParser
    {
        #region ICommandLineTokenParser Members

        public object Parse(string[] values)
        {
            return Int16.Parse(values[0]);
        }

        public int TokensRequired
        {
            get { return 1; }
        }

        #endregion
    }
}
