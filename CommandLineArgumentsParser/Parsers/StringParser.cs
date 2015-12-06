using System;
using System.Collections.Generic;
using System.Text;

namespace CommandLineArgumentsParser.Parsers
{
    public class StringParser : ICommandLineTokenParser
    {
        #region ICommandLineTokenParser Members

        public object Parse(string[] values)
        {
            return values[0];
        }

        public int TokensRequired
        {
            get { return 1; }
        }

        #endregion
    }
}
