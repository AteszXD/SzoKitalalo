using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzoKitalalo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "első", "alma", "kukac", "vizibicikli" };
            Random random = new Random();
            Console.WriteLine(words[random.Next(words.Length)]);
        }
    }
}
