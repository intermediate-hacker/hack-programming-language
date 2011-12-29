using System;

namespace Program
{
    public class MainApp
    {
        public static void Main(string[] args)
        {             
            var x = "Hello!";
            var y = "World!";
            
            var hello = x+y;
            
            System.Console.WriteLine( hello );
            
            var test_num = 5;
            System.Console.WriteLine( "test number: {0}", test_num );
            
            // THIS IS A COMMENT
            /* another damn comment
            of multiple
            lines */
            
            while (true) {
            System.Console.Write( "Enter Name:" );
            
            var name = System.Console.ReadLine( );
            if (name == "me") {
            System.Console.WriteLine( "THIS IS SO AWESOME!!!" );
            System.Console.WriteLine( "I am me!" );
            }
            
            else if(name == "exit") {
            System.Console.WriteLine( "Exiting..." );
            System.Environment.Exit( 0 );
            }
            
            else {
            System.Console.WriteLine( "NOO!!! :(" );
            System.Console.Write( "I am not 'me'..." );
            }
            }

        }
    }
}

