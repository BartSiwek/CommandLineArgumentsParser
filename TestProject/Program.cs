using System;
using System.Collections.Generic;
using System.Text;
using CommandLineArgumentsParser;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeParameters parameters = new FakeParameters();
            string[] fakeArgs = { "/ValueOne", "1", "/ValueThree", "/ValueTwo", "1,2" };

            try
            {
                CommandLineOptionsParser parser = new CommandLineOptionsParser(parameters);
                parser.Parse(fakeArgs);
            }
            catch (CommandLineArgumentsException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(parameters.m_valueOne);
            Console.WriteLine(parameters.m_valueTwo);
            Console.WriteLine(parameters.m_valueThree);
        }
    }
}
