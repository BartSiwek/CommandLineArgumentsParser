using System;
using System.Collections.Generic;
using System.Text;

namespace CommandLineArgumentsParser.Parsers
{
    public class BooleanParser : ICommandLineTokenParser
    {
        #region ICommandLineTokenParser Members

        public object Parse(string[] values)
        {
            return true;
        }

        public int TokensRequired
        {
            get { return 0; }
        }

        #endregion
    }
}
