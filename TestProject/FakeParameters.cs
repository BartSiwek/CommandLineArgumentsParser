using System;
using System.Collections.Generic;
using System.Text;
using CommandLineArgumentsParser;
using CommandLineArgumentsParser.Parsers;

namespace TestProject
{
    class FakeParameters
    {
        public int m_valueOne;
        public double m_valueTwo;
        public bool m_valueThree;

        [CommandLineOption(typeof(Int32Parser), Required = true)]
        public int ValueOne
        {
            set { m_valueOne = value; }
        }

        [CommandLineOption(typeof(DoubleParser))]
        public double ValueTwo
        {
            get { return m_valueTwo; }
            set { m_valueTwo = value; }
        }

        [CommandLineOption(typeof(BooleanParser))]
        public bool ValueThree
        {
            get { return m_valueThree; }
            set { m_valueThree = value; }
        }
    }
}
