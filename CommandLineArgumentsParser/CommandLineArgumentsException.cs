using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CommandLineArgumentsParser
{
    public class CommandLineArgumentsException : ApplicationException
    {
        public CommandLineArgumentsException()
            : base()
        { }

        public CommandLineArgumentsException(string message)
            : base(message)
        { }

        public CommandLineArgumentsException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public CommandLineArgumentsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
