namespace MusicArtists.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using MusicArtists.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicArtistsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "MusicArtists.Data.MusicArtistsDbContext";
        }

        protected override void Seed(MusicArtistsDbContext context)
        {
            if (context.Artists.Any())
            {
                return;
            }

            var artists = SeedArtists(context);
            var enumerable = artists as Artist[] ?? artists.ToArray();
            var album = SeedAlbum(context, enumerable);
            var songs = SeedSongs(context, album, enumerable);
            context.SaveChanges();
        }

        private static List<Song> SeedSongs(MusicArtistsDbContext context, Album album, IEnumerable<Artist> artists)
        {
            var songs = new List<Song>
                            {
                                new Song { Title = "Disclaimer" },
                                new Song { Title = "The Meaning of Life" },
                                new Song { Title = "Mota" },
                                new Song { Title = "Me & My Old Lady" },
                                new Song { Title = "Cool to Hate" },
                                new Song { Title = "Leave It Behind" },
                                new Song { Title = "Gone Away" },
                                new Song { Title = "I Choose" },
                                new Song { Title = "Intermission" },
                                new Song { Title = "All I Want" },
                                new Song { Title = "Way Down the Line" },
                                new Song { Title = "Don't Pick It Up" },
                                new Song { Title = "Amazed" },
                                new Song { Title = "Change the World" },
                            };

            foreach (var song in songs)
            {
                context.Songs.Add(song);
                song.Album = album;
                foreach (var artist in artists)
                {
                    artist.Songs.Add(song);
                }
            }

            return songs;
        }

        private static Album SeedAlbum(MusicArtistsDbContext context, IEnumerable<Artist> artists)
        {
            var ixnayAlbum = new Album
            {
                Title = "Ixnay on the hombre",
                Producer = "Dave Jerden",
                Length = new TimeSpan(0, 42, 17),
                ReleaseDate = new DateTime(1997, 2, 4),
            };


            foreach (var artist in artists)
            {
                ixnayAlbum.Artists.Add(artist);
            }

            return context.Albums.Add(ixnayAlbum);
        }

        private static IEnumerable<Artist> SeedArtists(MusicArtistsDbContext context)
        {
            var artists = new List<Artist>();
            const string Usa = "U.S.A";

            var dexter = new Artist
            {
                Name = "Bryan Keith Holland",
                Nickname = "Dexter",
                DateOfBirth = new DateTime(1965, 12, 29),
                Country = Usa,
            };

            var noodles = new Artist
            {
                Nickname = "Noodles",
                Name = "Kevin John Wasserman",
                DateOfBirth = new DateTime(1963, 2, 4),
                Country = Usa,
            };

            artists.Add(context.Artists.Add(dexter));
            artists.Add(context.Artists.Add(noodles));
            return artists;
        }
    }
}