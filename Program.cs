﻿using System;
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

            var userHasChosenToQuit = false;
            while (userHasChosenToQuit == false)
            {

                Console.WriteLine("ALBUMS - Add, Update, or View Bands");
                Console.WriteLine("BANDS - Add, Update, or View Bands");
                Console.WriteLine("SONGS - Add, Update, or View Songs");
                Console.WriteLine("QUIT - Leave the program");
                Console.WriteLine();

                Console.Write("Make a selection from our menu options: ");
                var selection = Console.ReadLine().ToUpper().Trim();
                Console.WriteLine();

                if (selection == "BANDS")
                {
                    Console.WriteLine("ADD - Add a New Band");
                    Console.WriteLine("UPDATE - Update Band Information");
                    Console.WriteLine("View - View ALL Bands");
                    Console.WriteLine("Search - View for a Band and their Albums");
                    Console.WriteLine();

                    Console.Write("Make a selection from our menu options: ");
                    var bandSelection = Console.ReadLine().ToUpper().Trim();

                    switch (bandSelection)
                    {
                        case "ADD":
                            Console.Write("What Band would you like to add?  ");
                            var newBandName = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("What Country is the Band from?  ");
                            var newCountryOfOrigin = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("How many Members are in the Band?  ");
                            var newNumberOfMembersString = Console.ReadLine();
                            var newNumberOfMembers = int.Parse(newNumberOfMembersString);
                            Console.WriteLine();

                            Console.Write("What is the link for the Band's Website?  ");
                            var newWebsite = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("What Style of music does the Band play? ");
                            var newStyle = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("Is the Band Signed with a label?  ");
                            var newIsSignedString = Console.ReadLine().ToUpper().Trim();
                            switch (newIsSignedString)
                            {
                                case "YES":
                                    newIsSignedString = "TRUE";
                                    break;
                                case "NO":
                                    newIsSignedString = "FALSE";
                                    break;
                            }

                            var newIsSignedConvert = bool.Parse(newIsSignedString);


                            // Need to add something for if they enter Yes/No

                            Console.Write("What is the Full Name of the Contact for the Band?  ");
                            var newContactName = Console.ReadLine();
                            Console.WriteLine();

                            // Need to fix phone number so you can enter 10 digits

                            Console.Write("What is the Phone Number for the Contact for the Band?  ");
                            var newContactPhoneNumberString = Console.ReadLine();
                            var newContactPhoneNumber = char.Parse(newContactPhoneNumberString);
                            Console.WriteLine();

                            var newBand = new Band()
                            {
                                Name = newBandName,
                                CountryOfOrigin = newCountryOfOrigin,
                                NumberOfMembers = newNumberOfMembers,
                                Website = newWebsite,
                                Style = newStyle,
                                IsSigned = newIsSignedConvert,
                                ContactName = newContactName,
                                ContactPhoneNumber = newContactPhoneNumber,
                            };
                            context.Bands.Add(newBand);
                            context.SaveChanges();
                            break;

                        case "UPDATE":
                            Console.Write("What is the Band you would like to Update?  ");
                            var nameOfBandToUpdate = Console.ReadLine();
                            var existingBandToUpdate = context.Bands.FirstOrDefault(band => band.Name == nameOfBandToUpdate);

                            if (existingBandToUpdate != null)
                            {
                                Console.Write("What is the new Band Name?  ");
                                existingBandToUpdate.Name = Console.ReadLine();

                                Console.Write("How many Members are in the Band?  ");
                                var updateNumberOfMembersString = Console.ReadLine();
                                var updateNumberOfMembers = int.Parse(updateNumberOfMembersString);
                                existingBandToUpdate.NumberOfMembers = updateNumberOfMembers;

                                Console.Write("What is the link for the Band's Website?  ");
                                existingBandToUpdate.Website = Console.ReadLine();

                                Console.Write("What Style of music does the Band play?  ");
                                existingBandToUpdate.Style = Console.ReadLine();

                                Console.Write("Is the Band Signed with a label?  ");
                                var updateIsSignedString = Console.ReadLine().ToUpper().Trim();
                                switch (updateIsSignedString)
                                {
                                    case "YES":
                                        updateIsSignedString = "TRUE";
                                        break;
                                    case "NO":
                                        updateIsSignedString = "FALSE";
                                        break;
                                }
                                existingBandToUpdate.IsSigned = bool.Parse(updateIsSignedString);

                                // Need to add something for if they enter Yes/No
                                Console.Write("What is the Full Name of the Contact for the Band?  ");
                                existingBandToUpdate.ContactName = Console.ReadLine();

                                // Need to fix phone number so you can enter 10 digits

                                Console.Write("What is the Phone Number for the Contact for the Band?  ");
                                var updateContactPhoneNumberString = Console.ReadLine();
                                existingBandToUpdate.ContactPhoneNumber = char.Parse(updateContactPhoneNumberString);

                                context.SaveChanges();
                            }

                            Console.WriteLine();
                            break;

                        case "VIEW":

                            foreach (var band in context.Bands)
                            {
                                Console.WriteLine($"{band.Name}");

                            }
                            break;

                        case "SEARCH":

                            Console.WriteLine("Name");
                            Console.WriteLine("Signed");
                            Console.WriteLine("Not Signed");
                            Console.WriteLine();

                            Console.Write("What would you like to search by? ");
                            var bandSearchSelection = Console.ReadLine().ToUpper().Trim();

                            switch (bandSearchSelection)
                            {
                                case "NAME":

                                    Console.Write("What is the Band Name you would like to search for? ");
                                    var bandNameSearch = Console.ReadLine();

                                    var bandToFind = context.Bands.FirstOrDefault(band => band.Name == bandNameSearch);
                                    var bandToFindId = bandToFind.Id;


                                    if (bandToFind == null)
                                    {
                                        Console.WriteLine("Couldn't find the Band. Uh oh!");
                                        Console.WriteLine();
                                        Console.WriteLine("-----------------------");
                                    }
                                    else
                                    {
                                        var albumsToShow = context.Albums.Where(album => album.BandId == bandToFindId);
                                        var albumTitles = albumsToShow.Select(album => album.Title);

                                        foreach (var album in albumTitles)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine($"Album: {album} belongs to the band {bandToFind.Name}");

                                        }
                                        Console.WriteLine();
                                        Console.WriteLine("-----------------------");
                                    }
                                    break;
                                case "SIGNED":
                                    var signedBands = context.Bands.Where(band => band.IsSigned == true);
                                    foreach (var band in signedBands)
                                    {
                                        Console.WriteLine($"{band.Name} has been signed");

                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("-----------------------");
                                    break;

                                case "NOT SIGNED":

                                    signedBands = context.Bands.Where(band => band.IsSigned == false);
                                    foreach (var band in signedBands)
                                    {
                                        Console.WriteLine($"{band.Name} has NOT been signed");

                                    }
                                    Console.WriteLine();

                                    Console.WriteLine("-----------------------");
                                    break;
                            }
                            break;

                        case "QUIT":
                            userHasChosenToQuit = true;
                            Console.WriteLine("Thanks for stopping by!");
                            break;
                    }
                }
                if (selection == "ALBUMS")
                {
                    Console.WriteLine("ADD - Add a New Album");
                    Console.WriteLine("View - View a list of Albums by Release Date");
                    Console.WriteLine();

                    Console.Write("Make a selection from our menu options: ");
                    var albumSelection = Console.ReadLine().ToUpper().Trim();

                    switch (albumSelection)
                    {
                        case "ADD":
                            Console.Write("What is the Album Title?  ");
                            var newAlbumTitle = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("Is the Album Explicit?  ");
                            var newIsExplicitString = Console.ReadLine().ToUpper().Trim();

                            switch (newIsExplicitString)
                            {
                                case "YES":
                                    newIsExplicitString = "TRUE";
                                    break;
                                case "NO":
                                    newIsExplicitString = "FALSE";
                                    break;
                            }

                            var newIsExplicit = bool.Parse(newIsExplicitString);
                            Console.WriteLine();

                            Console.Write("What date was the Album Released on?  ");
                            var newReleaseDateString = Console.ReadLine().ToUpper().Trim();
                            var newReleaseDate = DateTime.Parse(newReleaseDateString);
                            Console.WriteLine();

                            Console.Write("What Band does the Album belong to?  ");
                            var bandNameToFindResponse = Console.ReadLine();
                            var bandNameToFind = context.Bands.FirstOrDefault(band => band.Name == bandNameToFindResponse);
                            var newBandId = bandNameToFind.Id;

                            if (bandNameToFind == null)
                            {
                                Console.WriteLine("Sorry this band doesn't exist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------");
                            }
                            else
                            {
                                Console.WriteLine($"{bandNameToFindResponse}");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------");
                            }

                            Console.WriteLine();

                            var newAlbum = new Album()
                            {
                                Title = newAlbumTitle,
                                IsExplicit = newIsExplicit,
                                ReleaseDate = newReleaseDate,
                                BandId = newBandId,
                            };
                            context.Albums.Add(newAlbum);
                            context.SaveChanges();
                            break;
                        case "VIEW":

                            foreach (var album in context.Albums)
                            {
                                Console.WriteLine($"{album.Title} was released on {album.ReleaseDate}");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------");
                            }
                            break;
                    }

                }
                if (selection == "SONGS")
                {
                    Console.WriteLine("ADD - Add a New Song");
                    // Console.WriteLine("View - View a list of ALL Albums");
                    // Console.WriteLine("Search - View a list of ALL Albums");
                    Console.WriteLine();

                    Console.Write("Make a selection from our menu options: ");
                    var songSelection = Console.ReadLine().ToUpper().Trim();

                    switch (songSelection)
                    {
                        case "ADD":
                            Console.Write("What is the Song Title?  ");
                            var newSongTitle = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("What Album does the Song belong to?  ");
                            var albumTitleToFindResponse = Console.ReadLine();
                            var albumTitleToFind = context.Albums.FirstOrDefault(album => album.Title == albumTitleToFindResponse);
                            var newAlbumId = albumTitleToFind.Id;
                            if (albumTitleToFind == null)
                            {
                                Console.WriteLine("Sorry this band doesn't exist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------");
                            }
                            else
                            {
                                Console.WriteLine($"{albumTitleToFindResponse}");
                                Console.WriteLine();

                                Console.WriteLine("-----------------------");
                            }

                            Console.Write("What is the Song's Track number?  ");
                            var newSongTrackNumberString = Console.ReadLine();
                            var newSongTrackNumber = int.Parse(newSongTrackNumberString);
                            Console.WriteLine();

                            Console.Write("How long is the song (in seconds)?  ");
                            var newSongDurationString = Console.ReadLine();
                            var newSongDuration = int.Parse(newSongDurationString);
                            Console.WriteLine();

                            var newSong = new Song()
                            {
                                Title = newSongTitle,
                                AlbumId = newAlbumId,
                                TrackNumber = newSongTrackNumber,
                                Duration = newSongDuration,
                            };
                            context.Songs.Add(newSong);
                            context.SaveChanges();
                            break;
                    }
                }
            }
        }
    }
}
