using System;
using System.Collections.Generic;
using System.Text;

namespace CommandLineArgumentsParser.Parsers
{
    public class SByteParser : ICommandLineTokenParser
    {
        #region ICommandLineTokenParser Members

        public object Parse(string[] values)
        {
            return SByte.Parse(values[0]);
        }

        public int TokensRequired
        {
            get { return 1; }
        }

        #endregion
    }
}
