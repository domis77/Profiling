using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Profiling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<MemLeak, string> map = new Dictionary<MemLeak, string>();


                /*
                 * Wyciek pamięci powoduje nieskończona pętla 'for' która alokuje pamięć i jej nie zwalnia.
                 * Dodaje kolejne obiekty do kolekcji 'map'.
                 * 
                 * Należy ograniczyć pętle for do skończonej liczby wykonań.
               
                for (;;)
                {
                    map.Add(new MemLeak("key"), "value");
                }
                */

                int exampleNumberOfExecution = 100;
                for (int i = 0; i < exampleNumberOfExecution; i++)
                {
                    map.Add(new MemLeak("key"), "value");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Stack trace: " + ex.StackTrace);
            }
        }
    }

    public class MemLeak
    {
        public readonly String key;

        public MemLeak(String key)
        {
            this.key = key;
        }
    }
}
