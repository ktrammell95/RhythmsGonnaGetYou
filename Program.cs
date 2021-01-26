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

            var userHasChosenToQuit = false;
            while (userHasChosenToQuit == false)
            {
                Console.WriteLine();
                Console.WriteLine("****************************************");
                Console.WriteLine();

                Console.WriteLine("ALBUMS - Add, Update, or View Bands");
                Console.WriteLine("BANDS - Add, Update, or View Bands");
                Console.WriteLine("BANDS - Add, Update, or View Bands");
                Console.WriteLine("QUIT - Leave the program");
                Console.WriteLine();

                Console.Write("Make a selection from our menu options: ");
                var selection = Console.ReadLine().ToUpper().Trim();
                Console.WriteLine();

                if (selection == "BANDS")
                {

                    Console.WriteLine("ADD - Add a New Band");
                    Console.WriteLine("View - View a list of ALL Bands");
                    Console.WriteLine("Search - View a list of ALL Bands");
                    Console.WriteLine();

                    Console.Write("Make a selection from our menu options: ");
                    var bandSelection = Console.ReadLine().ToUpper().Trim();

                    switch (bandSelection)
                    {
                        case "ADD":
                            Console.WriteLine("What Band would you like to add?");
                            var newBandName = Console.ReadLine();
                            Console.WriteLine();

                            Console.WriteLine("What Country is the Band from?");
                            var newCountryOfOrigin = Console.ReadLine();
                            Console.WriteLine();

                            Console.WriteLine("How many Members are in the Band?");
                            var newNumberOfMembersString = Console.ReadLine();
                            var newNumberOfMembers = int.Parse(newNumberOfMembersString);
                            Console.WriteLine();

                            Console.WriteLine("What is the link for the Band's Website?");
                            var newWebsite = Console.ReadLine();
                            Console.WriteLine();

                            Console.WriteLine("What Style of music does the Band play?");
                            var newStyle = Console.ReadLine();
                            Console.WriteLine();

                            Console.WriteLine("Is the Band Signed with a label? (True for Yes, False for No)");
                            var newIsSignedString = Console.ReadLine().ToUpper().Trim();
                            var newIsSignedConvert = bool.Parse(newIsSignedString);

                            // Need to add something for if they enter Yes/No

                            Console.WriteLine("What is the Full Name of the Contact for the Band?");
                            var newContactName = Console.ReadLine();
                            Console.WriteLine();

                            // Need to fix phone number so you can enter 10 digits

                            Console.WriteLine("What is the Phone Number for the Contact for the Band?");
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

                            switch (bandSelection)
                            {
                                case "NAME":

                                    Console.Write("What is the Band Name you would like to search for? ");
                                    var bandNameSearch = Console.ReadLine();

                                    var bandToFind = context.Bands.FirstOrDefault(band => band.Name == bandNameSearch);

                                    if (bandToFind == null)
                                    {
                                        Console.WriteLine("Couldn't find the movie. Uh oh!");
                                        Console.WriteLine();
                                        Console.WriteLine("-----------------------");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{bandToFind.Name}");
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
                    Console.WriteLine("View - View a list of ALL Albums");
                    Console.WriteLine("Search - View a list of ALL Albums");
                    Console.WriteLine();

                    Console.Write("Make a selection from our menu options: ");
                    var albumSelection = Console.ReadLine().ToUpper().Trim();

                    switch (albumSelection)
                    {
                        case "ADD":
                            Console.WriteLine("What is the Album Title?");
                            var newAlbumTitle = Console.ReadLine();
                            Console.WriteLine();

                            Console.WriteLine("Is the Album Explicit?");
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

                            Console.WriteLine("What date was the Album Released on?");
                            var newReleaseDateString = Console.ReadLine().ToUpper().Trim();
                            var newReleaseDate = DateTime.Parse(newReleaseDateString);
                            Console.WriteLine();

                            Console.WriteLine("What Band does the Album belong to?");
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
                    }
                }
            }
        }
    }
}
