using System;
using System.Linq;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MusicContext();

            var bands = context.Bands;

            var bandCount = bands.Count();

            Console.WriteLine($"There are {bandCount} bands");
        }
    }
}
