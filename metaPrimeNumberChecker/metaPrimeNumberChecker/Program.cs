using System;
using System.IO;

namespace metaPrimeNumberChecker
{
    class MainClass
    {
        public static void Main ( string[] args )
        {
            String programSourceHeader =    "using System;\n\n"+
                                            "class PrimeNumberChecker\n"+
                                            "{\n"+
                                            "\tstatic void Main()\n"+
                                            "\t{\n\t\tConsole.WriteLine(\"Input a number\");\n\n\t\tint input = Convert.ToInt32(Console.ReadLine());\n\t\tint primeCount = 0;\n\t\tif (";

            String programSourceBody = "";

            //for ( int i = 2; i < int.MaxValue; ++i )
            for ( int i = int.MaxValue - 1000; i < int.MaxValue; ++i )
            {
                int divisibleNumbers = 0;

                for ( int j = 1; ( j <= i ) && ( divisibleNumbers < 3 ); ++j )
                {
                    if ( i % j == 0 )
                    {
                        divisibleNumbers++;
                    }
                }

                if ( divisibleNumbers == 2 )
                {
                    programSourceBody += "\n\t\t\t(" + i + " == input) ||";
                }
                Console.WriteLine( "Processing: " + i );
            }

            programSourceBody += " false";

            String programSourceFooter = ")\n\t\t{\n\t\t\tConsole.WriteLine( input + \" is prime.\");\n\t\t\tprimeCount++;\n\t\t\tConsole.WriteLine(primeCount + \" total prime numbers found\");\n\t\t}\n\t}\n}";

            String programSourceComplete = programSourceHeader + programSourceBody + programSourceFooter;

            StreamWriter sw = new StreamWriter( "PrimeNumberChecker.cs", false );

            sw.WriteLine( programSourceComplete );

            sw.Close();
        }
    }
}
