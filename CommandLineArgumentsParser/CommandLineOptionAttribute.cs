using System;
using System.Collections.Generic;
using System.Text;

namespace CommandLineArgumentsParser
{
    [AttributeUsage( AttributeTargets.Property, AllowMultiple=false, Inherited=false) ]
    public class CommandLineOptionAttribute : Attribute
    {
        private bool m_required = false;
        private Type m_parser;

        public CommandLineOptionAttribute(Type parser)
        {
            if (!typeof(ICommandLineTokenParser).IsAssignableFrom(parser))
            {
                string message = "Invalid command line token parsers type provided " + 
                                 "(must implement ICommandLineTokenParser interface)";
                throw new ArgumentException(message, "parser");
            }

            if(parser.GetConstructor(new Type[0]) == null)
            {
                    string message =
                        String.Format("Parser type {0} must have a default constructor", parser.FullName);
                    throw new ArgumentException(message, "parser");
            }

            this.m_parser = parser;
        }

        public bool Required
        {
            get { return m_required; }
            set { m_required = value; }
        }

        public Type Parser
        {
            get { return m_parser; }
        }
    }
}
