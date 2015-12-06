using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using PropertyDescription = CommandLineArgumentsParser.Pair<System.Reflection.PropertyInfo, CommandLineArgumentsParser.CommandLineOptionAttribute>;

namespace CommandLineArgumentsParser
{
    public class CommandLineOptionsParser
    {
        private object m_parametersObject;
        private Dictionary<string, PropertyDescription> m_parameters;

        public CommandLineOptionsParser(object parametersObject)
        {
            this.m_parametersObject = parametersObject;
            GetParameters(m_parametersObject.GetType());
        }

        private void GetParameters(Type parametersObjectType)
        {
            PropertyInfo[] parametersObjectProperties = parametersObjectType.GetProperties();

            m_parameters = new Dictionary<string, PropertyDescription>();

            foreach (PropertyInfo property in parametersObjectProperties)
            {
                object[] attributes = property.GetCustomAttributes(typeof(CommandLineOptionAttribute), false);

                if (attributes.Length > 0)
                {
                    CommandLineOptionAttribute commandLineOptionAttribute =
                        (CommandLineOptionAttribute)attributes[0];
                    m_parameters.Add(property.Name, new Pair<PropertyInfo, CommandLineOptionAttribute>(property, commandLineOptionAttribute));

                    if (!property.CanWrite)
                    {
                        string message = String.Format("Property {0} must have a public setter", property.Name);
                        throw new ArgumentException(message, "parametersObject");
                    }
                }
            }
        }

        public void Parse(string[] arguments)
        {
            int i = 0;
            while (i < arguments.Length)
            {
                //Get parameter
                if (!arguments[i].StartsWith("/"))
                    throw new CommandLineArgumentsException(String.Format("Invalid option format: {0}", arguments[i]));

                //Get parameter info
                string parameterName = arguments[i++].Substring(1);
                if(!m_parameters.ContainsKey(parameterName))
                    throw new CommandLineArgumentsException(String.Format("Unknown parameter name: {0}", parameterName));

                Pair<PropertyInfo, CommandLineOptionAttribute> parameterDescription = m_parameters[parameterName];
                m_parameters.Remove(parameterName);

                //Get parser
                ICommandLineTokenParser parser = GetParser(parameterDescription.Second);

                //Prepare tokens
                int count = 0;
                string[] tokens = new string[parser.TokensRequired];
                while (i < arguments.Length && count < parser.TokensRequired)
                {
                    tokens[count] = arguments[i];
                    count++;
                    i++;
                }

                if(count < parser.TokensRequired)
                    throw new CommandLineArgumentsException("Not enough command line tokens specified");

                //Get the value
                object value = parser.Parse(tokens);

                //Assing value
                MethodInfo parameterSetter = parameterDescription.First.GetSetMethod();
                parameterSetter.Invoke(m_parametersObject, new object[] { value });
            }

            //Check if there are any required parameters left
            CheckRequiredParameters();
        }

        private ICommandLineTokenParser GetParser(CommandLineOptionAttribute commandLineOptionAttribute)
        {
            Type parserType = commandLineOptionAttribute.Parser;
            ConstructorInfo parserTypeConstructor = parserType.GetConstructor(new Type[0]);

            ICommandLineTokenParser parser = 
                (ICommandLineTokenParser)parserTypeConstructor.Invoke(new object[0]);

            return parser;
        }

        private void CheckRequiredParameters()
        {
            foreach (PropertyDescription propertyDesc in m_parameters.Values)
            {
                if (propertyDesc.Second.Required)
                {
                    string message = 
                        String.Format("Parameter {0} is required", propertyDesc.First.Name);
                    throw new CommandLineArgumentsException(message);
                }
            }
        }
    }
}
