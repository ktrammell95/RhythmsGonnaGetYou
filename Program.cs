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
            var songs = context.Songs;

            var bandCount = bands.Count();
            var albumCount = albums.Count();
            var songCount = songs.Count();


            Console.WriteLine($"There are {bandCount} bands");
            Console.WriteLine($"There are {albumCount} albums");
            Console.WriteLine($"There are {songCount} songs");


        }
    }
}
