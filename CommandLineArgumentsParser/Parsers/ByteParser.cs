using System;
using System.Collections.Generic;
using System.Text;

namespace CommandLineArgumentsParser.Parsers
{
    public class ByteParser : ICommandLineTokenParser
    {
        #region ICommandLineTokenParser Members

        public object Parse(string[] values)
        {
            return Byte.Parse(values[0]);
        }

        public int TokensRequired
        {
            get { return 1; }
        }

        #endregion
    }
}
