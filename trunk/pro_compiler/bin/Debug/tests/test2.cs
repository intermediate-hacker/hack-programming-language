using System;

namespace Program
{
    public class MainApp
    {
        public static void Main(string[] args)
        {             
            
            Main:
            System.Console.WriteLine( "Enter 'exit' to exit" );
            var rtn = System.Console.ReadLine( );;
            
            if(rtn != "exit") {
            goto Main;
            }

        }
    }
}

