using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();


            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries);


                string type = input[0];
                string name = input[1];
                string time = input[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);

            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songs.Where(x => x.TypeList == typeList).ToList();

                foreach  (Song song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
