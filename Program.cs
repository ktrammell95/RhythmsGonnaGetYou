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
            var albums = context.Albums;

            var bandCount = bands.Count();
            var albumCount = albums.Count();


            Console.WriteLine($"There are {bandCount} bands");
            Console.WriteLine($"There are {albumCount} albums");

        }
    }
}
