using System;
using System.Collections.Generic;
using System.Text;

namespace CommandLineArgumentsParser.Parsers
{
    public class Int64Parser : ICommandLineTokenParser
    {
        #region ICommandLineTokenParser Members

        public object Parse(string[] values)
        {
            return Int64.Parse(values[0]);
        }

        public int TokensRequired
        {
            get { return 1; }
        }

        #endregion
    }
}
