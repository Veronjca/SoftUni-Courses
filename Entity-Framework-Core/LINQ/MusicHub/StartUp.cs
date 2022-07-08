namespace MusicHub

{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
            Console.WriteLine(ExportSongsAboveDuration(context, 4));

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Include(a => a.Producer)
                .Select(a => new
                {
                    Name = a.Name,
                    ProducerId = a.ProducerId,
                    AlbumId = a.Id,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = context.Songs
                                   .Include(s => s.Album)
                                   .Include(s => s.Writer)
                                   .Select(s => new
                                   {
                                       SongName = s.Name,
                                       AlbumId = s.AlbumId,
                                       Price = $"{s.Price:F2}",
                                       Writer = s.Writer.Name
                                   })
                                   .Where(s => s.AlbumId == a.Id)
                                   .OrderByDescending(s => s.SongName)
                                   .ThenBy(s => s.Writer)
                                   .ToList(),
                    AlbumPrice = a.Price
                })
                .Where(a => a.ProducerId == producerId)
                .ToList()
                .OrderByDescending(a => a.AlbumPrice);
               

            StringBuilder result = new StringBuilder();

            foreach (var album in albums)
            {
                result.AppendLine($"-AlbumName: {album.Name}");
                result.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                result.AppendLine($"-ProducerName: {album.ProducerName}");
                result.AppendLine($"-Songs:");
                int counter = 1;

                foreach (var song in album.Songs)
                {
                    result.AppendLine($"---#{counter++}");
                    result.AppendLine($"---SongName: {song.SongName}");
                    result.AppendLine($"---Price: {song.Price}");
                    result.AppendLine($"---Writer: {song.Writer}");
                }
                result.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }
         
            return result.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(s => s.Album)
                .ThenInclude(a => a.Producer)
                .Select(s => new
                {
                    Name = s.Name,
                    PerformerFullName = s.SongPerformers.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}").FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerFullName);

            StringBuilder result = new StringBuilder();

            int counter = 1;
            foreach (var song in songs)
            {
                result.AppendLine($"-Song #{counter++}");
                result.AppendLine($"---SongName: {song.Name}");
                result.AppendLine($"---Writer: {song.WriterName}");
                result.AppendLine($"---Performer: {song.PerformerFullName}");
                result.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                result.AppendLine($"---Duration: {song.Duration:c}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
