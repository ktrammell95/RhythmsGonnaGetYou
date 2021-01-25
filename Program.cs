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

            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine();

            Console.WriteLine("BANDS - Add, Update, or View Bands");
            // Console.WriteLine("ADD BANDS - Add a new dinosaur");
            // Console.WriteLine("REMOVE - Remove a dinosaur from the inventory");
            // Console.WriteLine("TRANSFER - Move a dinosaur to a new enclosure");
            // Console.WriteLine("SUMMARY - See the number of dinosaurs by diet");
            // Console.WriteLine("QUIT - Leave the program");
            Console.WriteLine();

            Console.Write("Make a selection from our menu options: ");
            var selection = Console.ReadLine().ToUpper().Trim();
            Console.WriteLine();

            if (selection == "BANDS")
            {

                Console.WriteLine("ADD - Add a New Band");
                Console.WriteLine("View - View a list of ALL Bands");
                Console.WriteLine();

                Console.Write("Make a selection from our menu options: ");
                var bandSelection = Console.ReadLine().ToUpper().Trim();

                if (bandSelection == "ADD")
                {

                    Console.WriteLine("What Band would you like to add?");
                    var newBandname = Console.ReadLine();
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
                        Name = newBandname,
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
                }
                if (bandSelection == "VIEW")
                {

                    foreach (var band in context.Bands)
                    {
                        Console.WriteLine($"{band.Name}");

                    }
                }
            }

        }
    }
}
