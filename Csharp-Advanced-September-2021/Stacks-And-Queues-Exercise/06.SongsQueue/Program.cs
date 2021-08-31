using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string songFromTheCommand = String.Empty;

                for (int i = 1; i < commands.Length; i++)
                {
                    songFromTheCommand += $"{commands[i]} ";
                }

                songFromTheCommand = songFromTheCommand.Trim();

                if (commands[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (commands[0] == "Add")
                {
                    if (songs.Contains(songFromTheCommand))
                    {
                        Console.WriteLine($"{songFromTheCommand} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songFromTheCommand);
                    }
                }
                else if (commands[0] == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");

        }
    }
}
