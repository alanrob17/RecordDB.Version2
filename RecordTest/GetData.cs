using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordDAL;
using RecordDAL.Components;
using _ad = RecordDAL.ArtistData;

namespace RecordTest
{
    internal class GetData
    {
        public static async Task Main(string[] args)
        {
            await ShowArtistsAsync();
            // await SelectAsync();
            // await GetArtistNamesAsync();
            // await GetArtistListAsync();
            // await GetSingleArtistAsync(114);
            // await SelectArtistWithNoBioAsync();
            // await InsertAsync();
            // await Insert2Async();
            // await UpdateArtistAsync();
            // await UpdateArtist2Async();
            // await GetArtistIdAsync();
            // await GetArtistId2Async();
            // await UpdateAsync();
            // await Update2Async();
            // await DeleteArtistAsync();
            // await ShowArtistAsync();
            // await GetBiographyAsync();

            // await GetRecordAsync();
            // await InsertRecordAsync();
            // await InsertRecord2Async();
            // await CountDiscsAsync();
            // await GetArtistRecordNumberAsync();
            // await UpdateRecordAsync();  
            // await UpdateRecord2Async();
            // await GetFormattedRecordAsync();
            // await SelectRecordsAsync();
            // SelectRecordsShow();
            // await SelectRecordsByArtistIdAsync();
            // await SelectRecordReviewsAsync();
            // await GetRecordedYearNumberAsync();
            // await NoRecordReviewsAsync();
            // ToShortDate();
            // await DeleteRecordAsync();  
            // await GetTotalsAsync();
        }

        /// <summary>
        /// Get total cost spent on each artist.
        /// </summary>
        private static async Task GetTotalsAsync()
        {
            var recordData = new RecordData();

            var artists = await recordData.GetTotalCostsAsync();

            foreach (var artist in artists)
            {
                Console.WriteLine("{0}: {1}: {2:C}\n", artist.Name, artist.TotalDiscs, artist.TotalCost);
            }
        }

        /// <summary>
        /// Change a string into a short date.
        /// </summary>
        private static void ToShortDate()
        {
            var recordData = new RecordData();
            var myDate = RecordData.ToShortDate("28-12-2015");

            Console.WriteLine(myDate);
        }

        /// <summary>
        /// Get a list of records without reviews.
        /// </summary>
        private static async Task NoRecordReviewsAsync()
        {
            var recordData = new RecordData();

            var records = await recordData.NoRecordReviewsAsync();

            foreach (var record in records)
            {
                Console.WriteLine("{0}: {1} - {2}\n", record.RecordId, record.ArtistName, record.Name);
            }
        }

        /// <summary>
        /// Get the number of discs for a particular year.
        /// </summary>
        private static async Task GetRecordedYearNumberAsync()
        {
            var recordData = new RecordData();
            var year = 1974;
            var count = await recordData.GetRecordedYearNumberAsync(year);

            Console.WriteLine("Count: {0}", count);
        }

        private static async Task SelectRecordReviewsAsync()
        {
            var recordData = new RecordData();

            var records = await recordData.SelectRecordReviewsAsync();

            foreach (var record in records)
            {
                Console.WriteLine("{0} -- {1}\n{2}\n", record.ArtistName, record.Name, record.Review);
            }
        }

        /// <summary>
        /// Select a record list by artist id.
        /// </summary>
        private static async Task SelectRecordsByArtistIdAsync()
        {
            var artistId = 114;

            var recordData = new RecordData();

            var records = await recordData.SelectArtistRecordsAsync(artistId);

            foreach (var record in records)
            {
                Console.WriteLine("{0} -- {1}", record.RecordId, record.Name);
            }
        }

        /// <summary>
        /// Select records based on show parameter.
        /// </summary>
        private static void SelectRecordsShow()
        {
            var show = "r1974";

            var recordData = new RecordData();

            var records = recordData.Select(show);

            foreach (var record in records)
            {
                Console.WriteLine("{0} -- {1} {2} - {3} : {4:d}\n", record.ArtistName, record.Name, record.Recorded, record.Media, record.Bought);
            }
        }

        /// <summary>
        /// Select all artist records.
        /// </summary>
        private static async Task SelectRecordsAsync()
        {
            var recordData = new RecordData();
            var records = await recordData.SelectAsync();

            foreach (var record in records)
            {
                Console.WriteLine("{0} -- {1} {2} - {3}\n", record.ArtistName, record.Name, record.Recorded, record.Media);
            }
        }

        /// <summary>
        /// Get record details from ToString method.
        /// </summary>
        private static async Task GetFormattedRecordAsync()
        {
            var recordData = new RecordData();
            var recordId = 212;
            var record = await recordData.SelectAsync(recordId);
            var recordDetails = await RecordData.ToStringAsync(record);

            Console.WriteLine(recordDetails);
        }

        /// <summary>
        /// Get number of records for an artist.
        /// </summary>
        private static async Task GetArtistRecordNumberAsync()
        {
            var recordData = new RecordData();
            var artistId = 114;
            var count = await recordData.GetArtistNumberOfRecordsAsync(artistId);

            Console.WriteLine("Count: {0}", count);
        }

        /// <summary>
        /// Count the number of discs.
        /// </summary>
        private static async Task CountDiscsAsync()
        {
            var recordData = new RecordData();
            var count = await recordData.CountDiscsAsync("dvds");

            Console.WriteLine("Count: {0}", count);

            count = await recordData.CountDiscsAsync("cd");

            Console.WriteLine("Count: {0}", count);
        }

        /// <summary>
        /// Update a record using an object.
        /// </summary>
        private static async Task UpdateRecord2Async()
        {
            var date = "21-06-2015";

            IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;

            var record = new Record
            {
                RecordId = 5271,
                ArtistId = 850,
                Name = "Laughing In Paradise",
                Recorded = 1991,
                Label = "Whoppo DoDah",
                Pressing = "Eng",
                Field = "Soundtrack",
                Rating = "****",
                Discs = 3,
                Media = "CD",
                Bought = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal),
                Cost = 15.99m,
                CoverName = string.Empty,
                Review = "This is Alan's third album. His last before he turned to religion."
            };

            var recordData = new RecordData();
            var recId = await recordData.UpdateAsync(record);

            Console.WriteLine(recId);
        }

        /// <summary>
        /// Update a record using variables.
        /// </summary>
        private static async Task UpdateRecordAsync()
        {
            IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;

            var recordId = 5272;
            var artistId = 851;
            var name = "Laughter In Paradise";
            var recorded = 1990;
            var label = "Whoppo";
            var pressing = "Eng";
            var field = "Jazz";
            var rating = "***";
            var discs = 2;
            var media = "CD";
            var date = "21-06-2015";
            var bought = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            var cost = 12.99m;
            var coverName = string.Empty;
            var review = "This is Alan's third album. His last before he went mad.";

            var recordData = new RecordData();
            var recId = await recordData.UpdateAsync(recordId, artistId, name, field, recorded, label, pressing, rating, discs, media, bought, cost, coverName, review);

            Console.WriteLine(recId);
        }

        /// <summary>
        /// Insert a new record.
        /// </summary>
        private static async Task InsertRecord2Async()
        {
            var artistId = 851;
            var name = "Laughs In Paradise";
            var recorded = 1989;
            var label = "Whoppo";
            var pressing = "Au";
            var field = "Rock";
            var rating = "****";
            var discs = 1;
            var media = "CD";
            var bought = new DateTime(2015, 06, 06);
            var cost = 13.99m;
            var coverName = string.Empty;
            var review = "This is Chuck's third album.";

            var recordData = new RecordData();
            var recordId = await recordData.InsertAsync(artistId, name, field, recorded, label, pressing, rating, discs, media, bought, cost, coverName, review);

            Console.WriteLine(recordId);
        }

        /// <summary>
        /// Insert a new record.
        /// </summary>
        private static async Task InsertRecordAsync()
        {
            var record = new Record
            {
                ArtistId = 850,
                Name = "Fun In Paradise",
                Recorded = 1986,
                Label = "Whoppo",
                Pressing = "Au",
                Field = "Rock",
                Rating = "****",
                Discs = 1,
                Media = "CD",
                Bought = new DateTime(2015, 05, 06),
                Cost = 10.99m,
                CoverName = string.Empty,
                Review = "This is Alan's second album."
            };

            var recordData = new RecordData();
            var recordId = await recordData.InsertAsync(record);

            Console.WriteLine(recordId);
        }

        /// <summary>
        /// Get record details including the artist biography.
        /// </summary>
        private static async Task GetRecordAsync()
        {
            var recordId = 1135;

            var artistData = new ArtistData();
            var recordData = new RecordData();
            var artist = await artistData.GetArtistByRecordIdAsync(recordId);
            var biography = await artistData.GetBiographyAsync(recordId);
            var record = await recordData.SelectAsync(recordId);

            Console.WriteLine("\nArtistId: {0} - Artist {1}:\n", artist.ArtistId, artist.Name);

            Console.WriteLine("\nRecordId: {0}\nName: {1}\nField: {2}\nRecorded: {3}\nLabel: {4}\nPressing: {5}\nDiscs: {6}\nMedia: {7}\nBought: {8}\nCost: {9}\nReview:\n{10}\n\nBiography:\n{11}", record.RecordId, record.Name, record.Field, record.Recorded, record.Label, record.Pressing, record.Discs, record.Media, record.Bought.ToShortDateString(), record.Cost, record.Review, biography);
        }

        /// <summary>
        /// Delete record.
        /// </summary>
        private static async Task DeleteRecordAsync()
        {
            var recordData = new RecordData();
            var recordId = 5272;
            await recordData.DeleteAsync(recordId);

            Console.WriteLine("Record deleted");
        }

        /// <summary>
        /// Get biography from the current record Id.
        /// </summary>
        private static async Task GetBiographyAsync()
        {
            var artistData = new ArtistData();
            var recordId = 283;
            var biography = await artistData.GetArtistIdAsync(recordId);

            Console.WriteLine(biography);
        }

        /// <summary>
        /// Show an artist as Html.
        /// </summary>
        private static async Task ShowArtistAsync()
        {
            var artistData = new ArtistData();
            var artistId = 114;
            Artist artist = await artistData.SelectAsync(artistId);
            var artistDetails = ArtistData.ToString(artist);

            Console.WriteLine(artistDetails);
        }

        /// <summary>
        /// Delete an artist.
        /// </summary>
        private static async Task DeleteArtistAsync()
        {
            var artistData = new ArtistData();
            var artistId = 851;
            await artistData.DeleteAsync(artistId);

            Console.WriteLine("Artist deleted");
        }

        /// <summary>
        /// Get artist id by firstName, lastName.
        /// </summary>
        private static async Task GetArtistId2Async()
        {
            var artistData = new ArtistData();
            var recordId = 289;
            var artistId = await artistData.GetArtistIdAsync(recordId);

            Console.WriteLine(artistId);
        }

        /// <summary>
        /// Get artist id by firstName, lastName.
        /// </summary>
        private static async Task GetArtistIdAsync()
        {
            // first name, last name
            var artistData = new ArtistData();
            var artistId = await artistData.GetArtistIdAsync("Bob", "Dylan");

            Console.WriteLine(artistId);
        }

        /// <summary>
        /// Update an artist.
        /// </summary>
        private static async Task UpdateArtistAsync()
        {
            var artist = new Artist
            {
                ArtistId = 850,
                FirstName = "Alan",
                LastName = "Robsano",
                Name = "Alan Robsano",
                Biography = "Alan hates country and western. He hates both kinds of music."
            };

            var artistData = new ArtistData();
            var artistId = await artistData.UpdateArtistAsync(artist);

            Console.WriteLine(artistId);
        }

        /// <summary>
        /// Update an artist.
        /// </summary>
        public static async Task UpdateArtist2Async()
        {
            var artistId = 851;
            var firstName = "Chuck";
            var lastName = "Robson-Smith";
            var name = "Chuck Robson-Smith";
            var biography = "<p>Chuck is a superstar Pop singer.</p>";

            var artistData = new ArtistData();

            artistId = await artistData.UpdateAsync(artistId, firstName, lastName, name, biography);

            Console.WriteLine(artistId);
        }

        /// <summary>
        /// Update an artist.
        /// </summary>
        private static async Task UpdateAsync()
        {
            // int aid, string FirstName, string LastName, string name, string biography
            var artist = new Artist
            {
                ArtistId = 852,
                FirstName = "Jamo",
                LastName = "Robson",
                Name = "Jamo Robsano",
                Biography = "<p>Jamo hates country and western. He hates both kinds of music.</p>"
            };

            var artistData = new ArtistData();
            var artistId = await artistData.UpdateArtistAsync(artist);

            Console.WriteLine(artistId);
        }

        /// <summary>
        /// Update an artist.
        /// </summary>
        private static async Task Update2Async()
        {
            var artistId = 850;
            var firstName = "Alan";
            var lastName = "Robson";
            var name = "Alan Robson";
            var biography = "<p>Alan plays a fast Polka dance music and has had success in Sweden and other Scandinavian countries.</p>";

            var artistData = new ArtistData();

            artistId = await artistData.UpdateAsync(artistId, firstName, lastName, name, biography);

            Console.WriteLine(artistId);
        }

        /// <summary>
        /// Insert a new artist entity.
        /// </summary>
        public static async Task InsertAsync()
        {
            var artist = new Artist
            {
                ArtistId = 0,
                FirstName = "Charley",
                LastName = "Robson",
                Biography = "<p>Charley is a country and western singer. He like both kinds of music.</p>"
            };

            var artistData = new ArtistData();
            var artistId = await artistData.InsertAsync(artist);

            Console.WriteLine(artistId);
        }

        /// <summary>
        /// Insert a new artist entity.
        /// </summary>
        public static async Task Insert2Async()
        {
            var artistId = 0;
            var firstName = "James";
            var lastName = "Robson";
            var biography = "James likes Pocopunk.";

            var artistData = new ArtistData();
            var newArtistId = await artistData.InsertAsync(artistId, firstName, lastName, biography);

            Console.WriteLine(newArtistId);
        }

        /// <summary>
        /// Select all artists with no biography.
        /// </summary>
        public static async Task SelectArtistWithNoBioAsync()
        {
            var artistData = new ArtistData();
            var artists = await artistData.SelectArtistWithNoBioAsync();

            foreach (var artist in artists)
            {
                Console.WriteLine($"{artist.ArtistId}: {artist.Name}");
            }
        }

        /// <summary>
        /// Get an artists details.
        /// </summary>
        /// <param name="artistId">The artist Id.</param>
        public static async Task GetSingleArtistAsync(int artistId)
        {
            var artistData = new ArtistData();
            var artist = await artistData.SelectAsync(artistId);

            Console.WriteLine("{0}: {1} -- {2}, {3}\n{4}\n", artist.ArtistId, artist.Name, artist.LastName, artist.FirstName, artist.Biography);
        }

        /// <summary>
        /// Show a list of artist Names.
        /// </summary>
        private static async Task ShowArtistsAsync()
        {
            var artists = await _ad.GetArtistsAsync();

            foreach (var record in artists)
            {
                Console.WriteLine(record.Name);
            }
        }

        /// <summary>
        /// Select all artist records.
        /// </summary>
        private static async Task SelectAsync()
        {
            var artists = await _ad.GetArtistsAsync();

            foreach (var artist in artists)
            {
                var bio = string.IsNullOrEmpty(artist.Biography) ? "No Biography" : (artist.Biography.Length > 60 ? artist.Biography.Substring(0, 60) + "..." : artist.Biography);
                Console.WriteLine("{0} -- {1}\n{2}\n", artist.ArtistId, artist.Name, bio);
            }
        }

        /// <summary>
        /// Select all artists name and Id.
        /// </summary>
        private static async Task GetArtistListAsync()
        {
            var artist = new ArtistData();
            var artists = await artist.GetArtistListAsync();

            foreach (var record in artists)
            {
                Console.WriteLine("{0} -- {1}", record.ArtistId, record.Name);
            }
        }

        /// <summary>
        /// Show a list of artist Names.
        /// </summary>
        private static async Task GetArtistNamesAsync()
        {
            var artists = await _ad.GetArtistsAsync();

            foreach (var artist in artists)
            {
                Console.WriteLine(artist.Name);
            }
        }
    }
}
