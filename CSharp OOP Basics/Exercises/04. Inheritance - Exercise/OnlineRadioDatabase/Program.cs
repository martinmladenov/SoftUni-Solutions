namespace OnlineRadioDatabase
{
    using System;
    using Exceptions;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int songsAdded = 0, totalTimeInSeconds = 0;
            for (int i = 0; i < n; i++)
            {
                var songData = Console.ReadLine().Split(';');

                try
                {
                    if (songData.Length != 3)
                        throw new InvalidSongException();


                    string artistName = songData[0];

                    if (artistName.Length < 3 || artistName.Length > 20)
                        throw new InvalidArtistNameException();


                    string songName = songData[1];

                    if (songName.Length < 3 || songName.Length > 30)
                        throw new InvalidSongNameException();


                    try
                    {
                        string[] songTime = songData[2].Split(':');

                        int songMinutes = int.Parse(songTime[0]);
                        int songSeconds = int.Parse(songTime[1]);

                        if (songMinutes < 0 || songMinutes > 14)
                            throw new InvalidSongMinutesException();

                        if (songSeconds < 0 || songSeconds > 59)
                            throw new InvalidSongSecondsException();


                        totalTimeInSeconds += songSeconds + 60 * songMinutes;
                    }
                    catch (Exception ex)
                    {
                        if (ex is FormatException || ex is IndexOutOfRangeException)
                        {
                            throw new InvalidSongLengthException();
                        }

                        throw;

                    }

                    songsAdded++;
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Songs added: {songsAdded}");
            Console.WriteLine("Playlist length: {0}h {1}m {2}s",
                                totalTimeInSeconds / 3600,
                                totalTimeInSeconds / 60 % 60,
                                totalTimeInSeconds % 60);
        }
    }
}
