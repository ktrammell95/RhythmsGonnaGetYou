using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MusicContext();

            var bands = context.Bands;
            var songs = context.Songs;
            var albums = context.Albums;

            var bandCount = bands.Count();
            var songCount = songs.Count();
            var albumCount = albums.Count();

            Console.WriteLine($"There are {bandCount} bands");
            Console.WriteLine($"There are {songCount} songs");
            Console.WriteLine($"There are {albumCount} albums");


            // foreach (var band in context.Bands)
            // {
            //     Console.WriteLine($"There is an band named {band.Name}");
            // }

            // foreach (var song in context.Songs)
            // {
            //     Console.WriteLine($"There is an song named {song.Title}");
            // }

            // foreach (var album in context.Albums)
            // {
            //     Console.WriteLine($"There is an album named {album.Title}");
            // }

            // foreach (var album in context.Albums.Include(album => album.Band))
            // {
            //     Console.WriteLine($"There is an album named {album.Title} by {album.Band.Name}");

            // }

            foreach (var song in context.Songs.Include(song => song.Album))
            {
                Console.WriteLine($"There is an album named {song.Album.Title} with {song.Title}");
            }

        }
    }
}
